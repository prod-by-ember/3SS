using System;
namespace main
{
	public class Dict
	{
        private static Vars vars = new Vars();

        // Comkey
        public string askCk()
        {
            Console.Write("Communication key (in Hex Format): ");
            string k = Console.ReadLine().ToUpper();

            string[] p = { "ABCDE", "0123456789", "ABCDE", "01", "ABC", "01234" };

            if (k.Length == 8 && // Length
                Convert.ToInt64(k, 16) >= 2694885536 && // Lowest Dec
                Convert.ToInt64(k, 16) <= 3923890628 && // Highest Dec
                k != "" && // Null
                p[0].Contains(k[0]) && p[1].Contains(k[1]) && // Matrix
                p[2].Contains(k[2]) && p[3].Contains(k[3]) && // Sender 1
                p[2].Contains(k[4]) && p[3].Contains(k[5]) && // Sender 2
                k[2] != k[4] && // Different Senders
                p[4].Contains(k[6]) && p[5].Contains(k[7]) // Plaintext
                ) {  return k; }
            Console.WriteLine("Invalid Key!");
            return askCk();
        }

        // Matrix
        public int[,] getMx(string mx)
        {
            switch (mx[0])
            {
                case 'A':
                    return mxdA[int.Parse(mx[1].ToString())];
                case 'B':
                    return mxdB[int.Parse(mx[1].ToString())];
                case 'C':
                    return mxdC[int.Parse(mx[1].ToString())];
                case 'D':
                    return mxdD[int.Parse(mx[1].ToString())];
                case 'E':
                    return mxdE[int.Parse(mx[1].ToString())];
                default:
                    return mxdA[0];
            }
        }

        private static int[][,] mxdA =
        {
            new int[,] { { 2, 26 }, { 18, 28 } },
            new int[,] { { 12, 19 }, { 13, 18 } },
            new int[,] { { 8, 27 }, { 20, 17 } },
            new int[,] { { 15, 22 }, { 15, 21 } },
            new int[,] { { 8, 8 }, { 21, 2 } },
            new int[,] { { 23, 1 }, { 20, 20 } },
            new int[,] { { 14, 5 }, { 21, 7 } },
            new int[,] { { 1, 10 }, { 1, 17 } },
            new int[,] { { 25, 20 }, { 7, 16 } },
            new int[,] { { 0, 28 }, { 25, 0 } },
        };
        private static int[][,] mxdB =
        {
            new int[,] { { 7, 18 }, { 27, 6 } },
            new int[,] { { 22, 9 }, { 3, 12 } },
            new int[,] { { 4, 11 }, { 6, 27 } },
            new int[,] { { 22, 16 }, { 6, 28 } },
            new int[,] { { 8, 5 }, { 21, 10 } },
            new int[,] { { 25, 12 }, { 1, 7 } },
            new int[,] { { 11, 1 }, { 24, 24 } },
            new int[,] { { 10, 28 }, { 13, 0 } },
            new int[,] { { 0, 10 }, { 4, 22 } },
            new int[,] { { 22, 7 }, { 9, 4 } },
        };
        private static int[][,] mxdC =
        {
            new int[,] { { 5, 26 }, { 28, 21 } },
            new int[,] { { 27, 19 }, { 14, 26 } },
            new int[,] { { 11, 3 }, { 2, 16 } },
            new int[,] { { 3, 12 }, { 14, 7 } },
            new int[,] { { 5, 22 }, { 27, 7 } },
            new int[,] { { 4, 22 }, { 17, 1 } },
            new int[,] { { 9, 8 }, { 8, 22 } },
            new int[,] { { 26, 19 }, { 25, 4 } },
            new int[,] { { 1, 18 }, { 23, 16 } },
            new int[,] { { 27, 23 }, { 14, 0 } },
        };
        private static int[][,] mxdD =
        {
            new int[,] { { 4, 4 }, { 7, 5 } },
            new int[,] { { 15, 28 }, { 28, 6 } },
            new int[,] { { 0, 16 }, { 23, 21 } },
            new int[,] { { 15, 27 }, { 6, 15 } },
            new int[,] { { 12, 10 }, { 13, 8 } },
            new int[,] { { 11, 25 }, { 24, 25 } },
            new int[,] { { 13, 25 }, { 19, 26 } },
            new int[,] { { 18, 7 }, { 3, 28 } },
            new int[,] { { 11, 6 }, { 8, 12 } },
            new int[,] { { 1, 1 }, { 6, 18 } },
        };
        private static int[][,] mxdE =
        {
            new int[,] { { 28, 11 }, { 13, 18 } },
            new int[,] { { 20, 2 }, { 0, 16 } },
            new int[,] { { 15, 11 }, { 14, 7 } },
            new int[,] { { 14, 10 }, { 3, 0 } },
            new int[,] { { 6, 21 }, { 2, 18 } },
            new int[,] { { 18, 2 }, { 21, 6 } },
            new int[,] { { 7, 21 }, { 1, 2 } },
            new int[,] { { 8, 16 }, { 21, 23 } },
            new int[,] { { 16, 16 }, { 17, 22 } },
            new int[,] { { 10, 0 }, { 11, 15 } },
        };

        // Sender
        public int askSr()
        {
            Console.Write("Sender (1 or 2): ");
            string s = Console.ReadLine();

            if (s.Length == 1 && "12".Contains(s) && s != "") { return Convert.ToInt32(s) - 1; }
            Console.WriteLine("Invalid Sender!");
            return askSr();
        }

        // Text Validation
        public string askPt()
        {
            Console.Write("Plaintext: ");
            string p = Console.ReadLine();

            for (int x = 0; x < p.Length; x++)
            {
                if (!vars.Alphabet.Contains(p.ToUpper()[x]))
                {
                    Console.WriteLine("Invalid Plaintext!");
                    return askPt();
                }
            }
            return p;
        }
        public string askCt()
        {
            Console.Write("Ciphertext: ");
            string c = Console.ReadLine();

            for (int x = 0; x < c.Length; x++)
            {
                if (!vars.Alphabet.Contains(c.ToUpper()[x]) || c.Length % 2 != 0)
                {
                    Console.WriteLine("Invalid Ciphertext!");
                    return askPt();
                }
            }
            return c;
        }

        // Time Validation
        public string askTm()
        {
            Console.Write("Time (in UTC): ");
            string t = Console.ReadLine();

            string[] p = { "012", "0123456789", "012345" };

            if (t.Length == 8 &&
                t != "" &&
                p[0].Contains(t[0]) &&
                p[1].Contains(t[1]) &&
                t[2] == ':' &&
                p[2].Contains(t[3]) &&
                p[1].Contains(t[4]) &&
                t[5] == ':' &&
                p[2].Contains(t[6]) &&
                p[1].Contains(t[7])
                ) { return t; }
            Console.WriteLine("Invalid Time!");
            return askTm();
        }

        // Team Validation
        public string askED()
        {
            Console.Write("Team (E/D): ");
            string t = Console.ReadLine();

            if (t.Length == 1 && "ED".Contains(t.ToUpper())) { return t; }
            Console.WriteLine("Invalid Team!");
            return askED();
        }
    }
}