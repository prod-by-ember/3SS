using System;
namespace main
{
	public class Dec
	{
		private static Vars vars = new Vars();
		private static string time;
		public string Time { set { time = value; } }

		private static int Inv(int n)
		{
			while (n < 0) { n += 29; }
			for (int x = 1; x < 29; x++)
			{
				if (x * (n % 29) % 29 == 1) { return x; }
			}
			return 0;
		}

		private static string S1(string c)
		{
			int a = int.Parse(time[time.Length - 1].ToString());
			if (a % 29 == 0) { a++; }
			a = Inv(a);
			int b = (int.Parse(time.Substring(0, 2)) + vars.TzCode[vars.Sender]) % 29;
			int n;
			string p = "";

			for (int i = 0; i < c.Length; i++)
			{
				n = vars.Alphabet.IndexOf(c[i]) - b;
				while (n < 0) { n += 29; }
				n = n * a % 29;
				p += vars.Alphabet[n];
			}
			return p;
		}
		private static string S2(string c)
		{

            if (vars.TzCode[vars.Sender] != 1)
			{
                char[] p = new char[c.Length];
                int n = 0;

				for (int i = 0; i < Math.Abs(vars.TzCode[vars.Sender]); i++)
                {
					int r = 0;
                    bool dir = false;
                    for (int j = 0; j < c.Length; j++)
                    {
                        if (r == i) { p[j] = c[n]; n++; }

                        if (dir) { r--; } else { r++; }
                        dir = r == 0 || r == Math.Abs(vars.TzCode[vars.Sender]) - 1 ? !dir : dir;
                    }
                }
				return new string(p);

            }
            return c;
        }
		private static string S3(string c)
		{
			int l = c.Length / 2;
			string p = "";

			int invSc = Inv((vars.Matrix[0, 0] * vars.Matrix[1, 1]) -
				(vars.Matrix[0, 1] * vars.Matrix[1, 0]));

			int[,] invMatrix =
			{
				{ invSc * vars.Matrix[1,1], invSc * -1 * vars.Matrix[0,1] },
				{ invSc * -1 * vars.Matrix[1,0], invSc * vars.Matrix[0,0] }
			};
			while (invMatrix[0, 1] < 1) { invMatrix[0, 1] += 29; }
            while (invMatrix[1, 0] < 1) { invMatrix[1, 0] += 29; }

			for (int i = 0; i < l; i++)
			{
                int c1 = vars.Alphabet.IndexOf(c.ToUpper()[i * 2]);
                int c2 = vars.Alphabet.IndexOf(c.ToUpper()[i * 2 + 1]);
                char p1 = vars.Alphabet[((c1 * invMatrix[0, 0]) + (c2 * invMatrix[0, 1])) % 29];
                char p2 = vars.Alphabet[((c1 * invMatrix[1, 0]) + (c2 * invMatrix[1, 1])) % 29];

				p += p1;
				p += p2;
            }
			return p;
        }

		public void Out(string c) { Console.WriteLine(S3(S2(S1(c.ToUpper())))); }
	}
}

