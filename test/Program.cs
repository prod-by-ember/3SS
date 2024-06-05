using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Security.Cryptography;

namespace test;

class Program
{
	private static Vars v = new Vars();
	static void Main(string[] args)
	{
		Out(Alg("Red Bubble", "A0A0E0C4", 1));
		Console.WriteLine(S1("Red Bubble"));
	}
	static string S1(string p)
	{
		p += p.Length % 2 == 1 ? "Z" : "";
		int l = p.Length / 2;
		string c = "";

		for (int i = 0; i < l; i++)
		{
			int p1 = v.Alphabet.IndexOf(p.ToUpper()[i * 2]);
			int p2 = v.Alphabet.IndexOf(p.ToUpper()[i * 2 + 1]);
			char c1 = v.Alphabet[((p1 * v.Matrix[0, 0]) + (p2 * v.Matrix[0, 1])) % 29];
			char c2 = v.Alphabet[((p1 * v.Matrix[1, 0]) + (p2 * v.Matrix[1, 1])) % 29];

			c += c1;
			c += c2;
		}
		return c;
	}
	static string S2(string p)
	{
		if (v.TzCode[v.Sender] != 1)
		{
			string[] c = new string[Math.Abs(v.TzCode[v.Sender])];
			bool dir = v.TzCode[v.Sender] < 0;
			int r = dir ? Math.Abs(v.TzCode[v.Sender]) - 1 : 0;

			for (int i = 0; i < p.Length; i++)
			{
				c[r] += p[i];
				if (dir) { r--; } else { r++; }

				dir = r == 0 || r == Math.Abs(v.TzCode[v.Sender]) - 1 ? !dir : dir;
			}
			return String.Join("", c);
		}
		return p;
	}
	static string S3(string p)
	{
		string _a = DateTime.UtcNow.ToString("ss");
		int a = Convert.ToInt32(Convert.ToString(_a[1]));
		if (a == 0) { a++; }
		int b = (DateTime.UtcNow.Hour + v.TzCode[v.Sender]) % 24;
		int n;
		string c = "";

		for (int i = 0; i < p.Length; i++)
		{
			n = (v.Alphabet.IndexOf(p[i]) * a + b) % 29;
			c += v.Alphabet[n];
		}
		return c;
	}
	static void Out(string p)
	{
		Console.WriteLine($"{DateTime.UtcNow.ToString("HH:mm:ss")} / {v.Sender + 1}");
		for (int i = 0; i < 3; i++)
		{
			Console.Write($"{v.Alphabet[i]}: ");
			if (i == v.PlainCode) { Console.WriteLine(p); }
			else
			{
				for (int j = 0; j < p.Length; j++)
				{
					Console.Write(v.Alphabet[v.random.Next(0, 29)]);
				}
				Console.WriteLine();
			}
		}
	}
	static string Alg(string p, string comkey, int sender)
	{
		v.ComKey = comkey;
		v.Sender = sender;
		return S3(S2(S1(p)));
	}
}

class Vars
{
	// Alphabet
	private static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ,.";
	public string Alphabet { get { return alphabet; } }

	private static string comkey = "A0A0A0A0";
	// Communication Key
	public string ComKey
	{
		get { return comkey; }
		set { comkey = value; }
	}

	// Matrix
	private static int[,] matrix = { { 12, 19 }, { 13, 18 } };
	public int[,] Matrix { get { return matrix; } }

	private int[] _tzcs = { 8, 1, -4, -5, 2 };
	// Timezone Code
	public int[] TzCode
	{
		get { return new int[] { _tzcs[alphabet.IndexOf(comkey[2])] + (comkey[3] == '1' ? 1 : 0), _tzcs[alphabet.IndexOf(comkey[4])] + (comkey[5] == '1' ? 1 : 0) }; }
	}

	// Sender
	private static int sender;
	public int Sender
	{
		get { return sender; }
		set { sender = value; }
	}

	// Plaintext Code
	private static int[,] _pcs = { { 0, 1, 1, 2, 2 }, { 2, 0, 2, 0, 1 }, { 1, 2, 0, 1, 0 } };
	public int PlainCode { get { return _pcs[(int)Char.ToUpper(comkey[6]) - 65, Convert.ToInt32(Convert.ToString(comkey[7]))]; } }

	// Random
	public Random random = new Random();
}