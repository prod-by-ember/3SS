namespace _3ss;
private static string t = "abcdefghijklmnopqrstuvwxyz ,.";
public class encode
{
	// Step 3
	static string AF(string p, int a, int b)
	{
		string c = "";
		for (int i = 0; i < p.Length; i++)
		{
			int n = (t.IndexOf(Char.ToLower(p[i])) * a + b) % 29;
			c += Char.IsLower(p[i]) || !t.ToUpper().Substring(0, 26).Contains(p[i]) ? t[n] : Char.ToUpper(t[n]);
		}
		return c;
	}
}
public class decode
{

}