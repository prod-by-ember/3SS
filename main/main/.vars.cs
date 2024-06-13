using System;
namespace main
{
	public class Vars
	{
        // Setup
        private static Dict dict = new Dict();

        private static string comkey;
        private static int sender;

        public string ComKey
        {
            get { return comkey; }
            set { comkey = value; }
        }
        public int Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        // Alphabet
        private static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ,.";
        public string Alphabet { get { return alphabet; } }

        // Matrix
        public int[,] Matrix { get { return dict.getMx(comkey.Substring(0, 2)); } }

        // Timezone Code
        private int[] _tzcs = { 8, 1, -4, -5, 2 };
        public int[] TzCode
        {
            get { return new int[] { _tzcs[alphabet.IndexOf(comkey[2])] + (comkey[3] == '1' ? 1 : 0), _tzcs[alphabet.IndexOf(comkey[4])] + (comkey[5] == '1' ? 1 : 0) }; }
        }

        // Plaintext Code
        private static int[,] _pcs = { { 0, 1, 1, 2, 2 }, { 2, 0, 2, 0, 1 }, { 1, 2, 0, 1, 0 } };
        public int PlainCode { get { return _pcs[(int)Char.ToUpper(comkey[6]) - 65, Convert.ToInt32(Convert.ToString(comkey[7]))]; } }

        // Random
        public Random random = new Random();
    }
}