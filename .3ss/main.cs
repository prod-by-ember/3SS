namespace _3ss;
private static string t = "abcdefghijklmnopqrstuvwxyz ,.";
private static var time = DateTime.UtcNow;
public class encode
{
	// Split Communication Key
	static object Split(string k)
	{

	}

	// static string HI(string)

	// Step 3
	static string AF(string p)
	{
		int a = Convert.ToInt32(Convert.ToString(DateTime.UtcNow.Second).Substring(1));
		int b = DateTime.UtcNow.Hour;
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