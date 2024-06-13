using System;
namespace main
{
	public class Enc
	{
        private static Vars vars = new Vars();

        private static string S1(string p)
        {
            if (p.Length % 2 == 1) { p += "Z"; }
            int l = p.Length / 2;
            string c = "";

            for (int i = 0; i < l; i++)
            {
                int p1 = vars.Alphabet.IndexOf(p.ToUpper()[i * 2]);
                int p2 = vars.Alphabet.IndexOf(p.ToUpper()[i * 2 + 1]);
                char c1 = vars.Alphabet[((p1 * vars.Matrix[0, 0]) + (p2 * vars.Matrix[0, 1])) % 29];
                char c2 = vars.Alphabet[((p1 * vars.Matrix[1, 0]) + (p2 * vars.Matrix[1, 1])) % 29];

                c += c1;
                c += c2;
            }
            return c;
        }
        private static string S2(string p)
        {
            if (vars.TzCode[vars.Sender] != 1)
            {
                string[] c = new string[Math.Abs(vars.TzCode[vars.Sender])];
                bool dir = false;
                int r = 0;

                for (int i = 0; i < p.Length; i++)
                {
                    c[r] += p[i];
                    if (dir) { r--; } else { r++; }

                    dir = r == 0 || r == Math.Abs(vars.TzCode[vars.Sender]) - 1 ? !dir : dir;
                }
                return String.Join("", c);
            }
            return p;
        }
        private static string S3(string p)
        {
            string _a = DateTime.UtcNow.ToString("ss");
            int a = Convert.ToInt32(Convert.ToString(_a[1]));
            if (a % 29 == 0) { a++; }
            int b = (DateTime.UtcNow.Hour + vars.TzCode[vars.Sender]) % 24;
            int n;
            string c = "";
            
            for (int i = 0; i < p.Length; i++)
            {
                n = (vars.Alphabet.IndexOf(p[i]) * a + b) % 29;
                c += vars.Alphabet[n];
            }
            return c;
        }

        private string Alg(string p) { return S3(S2(S1(p.ToUpper()))); }

        public void Out(string p)
        {
            Console.WriteLine($"{DateTime.UtcNow.ToString("HH:mm:ss")} / {vars.Sender + 1}");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{vars.Alphabet[i]}: ");
                if (i == vars.PlainCode) { Console.WriteLine(Alg(p)); }
                else
                {
                    for (int j = 0; j < (p.Length % 2 == 1? p.Length + 1 : p.Length) ; j++) { Console.Write(vars.Alphabet[vars.random.Next(0, 29)]); }
                    Console.WriteLine();
                }
            }
        }
    }
}