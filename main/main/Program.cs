using System;

namespace main;

class Program
{
    private static Vars vars = new Vars();
    private static Dict dict = new Dict();

    static void Main(string[] args)
    {
        vars.ComKey = dict.askCk();

        switch (dict.askED())
        {
            case "E":
                Console.Clear();
                teamE();
                break;
            case "D":
                Console.Clear();
                teamD();
                break;
        }
    }

    static void teamE()
    {
        Enc enc = new Enc();

        while (true)
        {
            vars.Sender = dict.askSr();
            string pt = dict.askPt();
            enc.Out(pt);
        }
    }

    static void teamD()
    {
        Dec dec = new Dec();

        while (true)
        {
            vars.Sender = dict.askSr();
            string ct = dict.askCt();
            dec.Time = dict.askTm();
            dec.Out(ct);
        }
    }
}