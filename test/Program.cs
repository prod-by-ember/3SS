namespace test;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine(Affine("Hello, world.", 5, 10));
	}
	static string Affine(string p, int a, int b)
	{
		string t = "abcdefghijklmnopqrstuvwxyz ,.";
		string c = "";
		for (int i = 0; i < p.Length; i++)
		{
			int n = (t.IndexOf(Char.ToLower(p[i])) * a + b) % 29;
			c += Char.IsLower(p[i]) ? t[n] : Char.ToUpper(t[n]);
		}
		return c;
	}
}
