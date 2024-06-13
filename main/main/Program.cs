using System;

namespace main;

class Program
{
    private static Vars vars = new Vars();
    private static Dict dict = new Dict();

    static void Main(string[] args)
    {
        vars.ComKey = dict.askCk();
        vars.Sender = dict.askSr();

        teamD();
    }

    static void teamE()
    {
        Enc enc = new Enc();
        string pt = dict.askPt();
        enc.Out(pt);
    }

    static void teamD()
    {
        Dec dec = new Dec();
        string ct = dict.askCt();
        dec.Time = dict.askTm();
        dec.Out(ct);
    }
}