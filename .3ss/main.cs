namespace _3ss;

public class encode
{
    static string Affine(string p, int a, int b)
    {
        string t = "abcdefghijklmnopqrstuvwxyz ,.";
        string c = "";
        for (int i = 0; i < p.Length; i++)
        {
            int n = (t.IndexOf(Char.ToLower(p[i])) * a + b) % 29;
            c += Char.IsLower(p[i]) || !t.Substring(0, 26).Contains(p[i]) ? t[n] : Char.ToUpper(t[n]);
        }
        return c;
    }
}
public class decode
{

}