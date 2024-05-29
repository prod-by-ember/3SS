using System.Runtime.InteropServices;
using System.IO;

namespace test;

class Program
{
	private static string comkey = "A1D1B1B1";
	private static int[,] matrix = { { 12, 19 }, { 13, 18 } };
	private static int[] tzc = { 8, 1, -4, -5, 2 };
	private static int tzcode = tzc[(int)Char.ToUpper(comkey[2]) - 65] + (comkey[3] == '1' ? 1 : 0);

	private static string t = "abcdefghijklmnopqrstuvwxyz ,.";

	static void Main(string[] args)
	{
		Console.WriteLine(DateTime.UtcNow.Second);
		Console.WriteLine((DateTime.UtcNow.Hour + tzcode) % 24);
		Console.WriteLine(S3("This is a test"));
	}
	static string[] S2(string p)
	{
	}
	static string S3(string p)
	{
		int a = Convert.ToInt32(Convert.ToString(DateTime.UtcNow.Second)[1]);
		if (a == 0) { a++; }
		int b = (DateTime.UtcNow.Hour + tzcode) % 24;
		string c = "";
		for (int i = 0; i < p.Length; i++)
		{
			int n = (t.IndexOf(Char.ToLower(p[i])) * a + b) % 29;
			c += Char.IsLower(p[i]) || !t.ToUpper().Substring(0, 26).Contains(p[i]) ? t[n] : Char.ToUpper(t[n]);
		}
		return c;
	}
}