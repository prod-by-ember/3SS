namespace _3ss;

public class encode
{
    static string Affine(string m, int a, int b)
    {
        string t = "abcdefghijklmnopqrstuvwxyz ,.";
        string o = "";
        for (int i = 0; i < m.Length; i++)
        {
            int n = (t.IndexOf(Char.ToLower(m[i])) * a + b) % 29;
            o += Char.IsLower(m[i]) || !t.Substring(0, 26).Contains(m[i]) ? t[n] : Char.ToUpper(t[n]);
        }
        return o;
    }
}
public class decode
{

}