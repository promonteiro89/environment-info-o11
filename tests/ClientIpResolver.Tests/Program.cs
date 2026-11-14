using System;
using System.Collections.Generic;
using OutSystems.NssEnvironmentInfo_Ext;

namespace OutSystems.NssEnvironmentInfo_Ext.Tests {

	// Tiny assertion runner: no packages, C# 6 only.
	internal static class Program {

		private static int _passed;
		private static int _failed;

		public static int Main(string[] args) {
			RunTestTable();
			RunNormalizeIpExtras();
			RunIsCloudFrontExtras();

			Console.WriteLine();
			Console.WriteLine(string.Format("Summary: {0} passed, {1} failed, {2} total",
				_passed, _failed, _passed + _failed));
			Console.WriteLine(_failed == 0 ? "RESULT: ALL PASSED" : "RESULT: FAILURES PRESENT");
			return _failed == 0 ? 0 : 1;
		}

		// ---- test table (fake platform predicate: trusted iff inside 10.0.0.0/8) ----

		private static void RunTestTable() {
			Console.WriteLine("== Resolve: test table ==");

			Row("1", false, false, null, "10.1.1.1", "10.1.1.1");
			Row("2", false, false, "203.0.113.7, 198.51.100.9", "10.1.1.1", "203.0.113.7");
			Row("3", false, false, "unknown", "10.1.1.1", "10.1.1.1");
			Row("4", false, false, "203.0.113.7:5555", "10.1.1.1", "203.0.113.7");
			Row("5", false, false, "[2001:db8::1]:443", "10.1.1.1", "2001:db8::1");
			Row("6", false, false, "12345", "10.1.1.1", "10.1.1.1");
			Row("7", true, false, "149.90.227.76, 64.252.126.100", "10.0.0.5", "149.90.227.76");
			Row("8", true, false, "203.0.113.7, 149.90.227.76, 64.252.126.201", "10.0.0.5", "149.90.227.76");
			Row("9", true, false, "1.2.3.4", "203.0.113.50", "203.0.113.50");
			Row("10", true, false, "198.51.100.9, 64.252.126.100", "10.0.0.5", "198.51.100.9");
			Row("11a", true, true, "10.0.0.7, 64.252.126.100", "10.0.0.5", "10.0.0.7");
			Row("11b", true, false, "10.0.0.7, 64.252.126.100", "10.0.0.5", "10.0.0.5");
			Row("12", true, false, null, "10.0.0.5", "10.0.0.5");
			Row("13", true, false, "garbage, 64.252.126.100", "10.0.0.5", "10.0.0.5");

			// Row 14: IPv6 address taken from the first IPv6 CloudFront prefix (never hard-coded).
			Check("row 14 (first IPv6 CloudFront prefix in chain)", "149.90.227.76", delegate {
				return ClientIpResolver.Resolve("149.90.227.76, " + FirstIPv6PrefixNetwork(),
					"10.0.0.5", true, false, IsInside10);
			});

			Row("15", true, false, "149.90.227.76, ::ffff:64.252.126.100", "10.0.0.5", "149.90.227.76");
			Row("16", false, false, "2001:DB8::1", "10.1.1.1", "2001:db8::1");
			Row("17", true, false, "149.90.227.76, 64.252.126.100", "::ffff:10.0.0.5", "149.90.227.76");
			Row("18", true, false, "149.90.227.76,64.252.126.100", "10.0.0.5", "149.90.227.76");

			// Row 19: platform predicate throws on every call.
			Check("row 19 (predicate throws)", "10.0.0.5", delegate {
				return ClientIpResolver.Resolve("149.90.227.76, 64.252.126.100",
					"10.0.0.5", true, false, ThrowingPredicate);
			});

			RunCloudFrontHopTable();
		}

		// ---- at most one CloudFront hop that the platform doesn't trust ----

		private static void RunCloudFrontHopTable() {
			Console.WriteLine("== Resolve: one CloudFront hop ==");

			// Normal OutSystems Cloud chain: visitor, then OutSystems' CloudFront.
			Row("cf1", true, false, "149.90.227.76, 64.252.126.100", "10.0.0.5", "149.90.227.76");

			// A second CloudFront distribution in front: its address is returned, not the forged entry.
			Row("cf2", true, false, "203.0.113.7, 64.252.126.100, 64.252.126.201", "10.0.0.5", "64.252.126.100");

			Check("row cf3 (two IPv6 CloudFront hops)", ClientIpResolver.NormalizeIp(IPv6PrefixNetwork(0)), delegate {
				return ClientIpResolver.Resolve("203.0.113.7, " + IPv6PrefixNetwork(0) + ", " + IPv6PrefixNetwork(1),
					"10.0.0.5", true, false, IsInside10);
			});

			// The connection address itself is CloudFront and not platform-trusted: it uses the hop.
			Row("cf4", true, false, "203.0.113.7, 64.252.126.100", "64.252.126.201", "64.252.126.100");
			Row("cf4b", true, false, null, "64.252.126.201", "64.252.126.201");

			// Platform-trusted proxies on both sides of one CloudFront hop.
			Row("cf5", true, false, "149.90.227.76, 64.252.126.100, 10.0.0.9", "10.0.0.5", "149.90.227.76");

			// All entries platform-trusted: fallback behaviour unchanged.
			Row("cf6a", true, true, "10.0.0.7, 10.0.0.8", "10.0.0.5", "10.0.0.7");
			Row("cf6b", true, false, "10.0.0.7, 10.0.0.8", "10.0.0.5", "10.0.0.5");
			Row("cf6c", true, true, "10.0.0.7, 64.252.126.100, 10.0.0.8", "10.0.0.5", "10.0.0.7");

			// A CloudFront address the platform also trusts doesn't use up the hop.
			Check("row cf7 (platform-trusted CloudFront address)", "203.0.113.7", delegate {
				return ClientIpResolver.Resolve("203.0.113.7, 64.252.126.100, 64.252.126.201",
					"10.0.0.5", true, false, IsInside10Or64_252_126_201);
			});

			// An IPv4 address with a %scope is invalid, so the connection address is returned.
			Row("cf8", true, false, "1.2.3.4%eth0", "10.0.0.5", "10.0.0.5");
			Row("cf9", false, false, "1.2.3.4%eth0", "10.1.1.1", "10.1.1.1");
		}

		// ---- NormalizeIp extras ----

		private static void RunNormalizeIpExtras() {
			Console.WriteLine("== NormalizeIp extras ==");

			NormCase(" 1.2.3.4 ", "1.2.3.4");
			NormCase("1.2.3", "");
			NormCase("999.1.1.1", "");
			NormCase("[::1]", "::1");
			NormCase("[::1]:0", "");
			NormCase("1.2.3.4:70000", "");
			NormCase("fe80::1%eth0", "fe80::1");
			NormCase("[fe80::1%eth0]:443", "fe80::1");
			NormCase("1.2.3.4%eth0", "");
			NormCase("1.2.3.4%eth0:80", "");
			NormCase("[1.2.3.4%eth0]", "");
			NormCase("UNKNOWN", "");
			NormCase("::ffff:1.2.3.4", "1.2.3.4");
			// Extra guards beyond the spec list.
			NormCase(null, "");
			NormCase("   ", "");
		}

		private static void NormCase(string input, string expected) {
			Check("NormalizeIp(" + Show(input) + ")", expected, delegate {
				return ClientIpResolver.NormalizeIp(input);
			});
		}

		// ---- IsCloudFrontOriginFacing extras ----

		private static void RunIsCloudFrontExtras() {
			Console.WriteLine("== IsCloudFrontOriginFacing extras ==");

			CfCase("64.252.126.100", true);
			CfCase("64.252.63.255", false);
			CfCase("149.90.227.76", false);
			CfCase("::ffff:64.252.126.100", true);
			CfCase("2001:db8::1", false);

			Check("IsCloudFrontOriginFacing(first IPv6 prefix network address)", "true", delegate {
				return ClientIpResolver.IsCloudFrontOriginFacing(FirstIPv6PrefixNetwork()) ? "true" : "false";
			});
		}

		private static void CfCase(string ip, bool expected) {
			Check("IsCloudFrontOriginFacing(" + ip + ")", expected ? "true" : "false", delegate {
				return ClientIpResolver.IsCloudFrontOriginFacing(ip) ? "true" : "false";
			});
		}

		// ---- helpers ----

		private static void Row(string id, bool trusted, bool fallback, string forwardedFor,
			string remote, string expected) {
			Check("row " + id, expected, delegate {
				return ClientIpResolver.Resolve(forwardedFor, remote, trusted, fallback, IsInside10);
			});
		}

		// Fake platform predicate: trusted iff the address is inside 10.0.0.0/8.
		private static bool IsInside10(string ip) {
			System.Net.IPAddress addr;
			if (!System.Net.IPAddress.TryParse(ip ?? "", out addr)) {
				return false;
			}
			byte[] b = addr.GetAddressBytes();
			return b.Length == 4 && b[0] == 10;
		}

		// Like IsInside10, and also trusts one CloudFront address.
		private static bool IsInside10Or64_252_126_201(string ip) {
			return IsInside10(ip) || ip == "64.252.126.201";
		}

		private static bool ThrowingPredicate(string ip) {
			throw new InvalidOperationException("platform predicate exploded for " + ip);
		}

		// Network address of the first CloudFrontRanges prefix that contains ':'.
		private static string FirstIPv6PrefixNetwork() {
			return IPv6PrefixNetwork(0);
		}

		// Network address of the CloudFrontRanges prefix that is the n-th (0-based) to contain ':'.
		private static string IPv6PrefixNetwork(int n) {
			foreach (string prefix in CloudFrontRanges.Prefixes) {
				if (prefix != null && prefix.IndexOf(':') >= 0) {
					if (n-- > 0) {
						continue;
					}
					int slash = prefix.IndexOf('/');
					return slash >= 0 ? prefix.Substring(0, slash) : prefix;
				}
			}
			throw new InvalidOperationException("not enough IPv6 prefixes in CloudFrontRanges.Prefixes");
		}

		private static string Show(string s) {
			return s == null ? "<null>" : "\"" + s + "\"";
		}

		private static void Check(string name, string expected, Func<string> actual) {
			string got;
			try {
				got = actual();
			} catch (Exception ex) {
				got = "EXCEPTION " + ex.GetType().Name + ": " + ex.Message;
			}

			bool ok = string.Equals(expected, got, StringComparison.Ordinal);
			if (ok) {
				_passed++;
			} else {
				_failed++;
			}
			Console.WriteLine(string.Format("{0} {1} | expected={2} actual={3}",
				ok ? "PASS" : "FAIL", name, Show(expected), Show(got)));
		}
	}
}
