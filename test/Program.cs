using System.Runtime.InteropServices;

namespace test;

class Program
{
	private static string t = "abcdefghijklmnopqrstuvwxyz ,.";
	static void Main(string[] args)
	{
		string comKey = "A1A0B1B1";
	}
	static string HI()
	{

	}
	static string RF()
	{

	}
	static string AF(string p, int a, int b)
	{
		string c = "";
		for (int i = 0; i < p.Length; i++)
		{
			int n = (t.IndexOf(Char.ToLower(p[i])) * a + b) % 29;
			c += Char.IsLower(p[i]) || !t.ToUpper().Substring(0, 26).Contains(p[i]) ? t[n] : Char.ToUpper(t[n]);
		}
		return c;
	}
}
