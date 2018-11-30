public static string Password(string input)
{
	input = input.ToLower();
	//leet
	input = input.Replace('a', '4');
	input = input.Replace('o', '0');
	input = input.Replace('i', '1');
	input = input.Replace('e', '3');
	input = input.Replace('t', '7');
	input = input.Replace('g', '6');
	input = input.Replace('s', '5');
	input = input.Replace('z', '2');
	//random symbols
	char[] sym = "~!@#$%^&*()_+{}|:\"<>?`-=[]\\;\',./".ToCharArray();
	Random rng = new Random();
	for (int i = 0; i != 10; i++)
	{
		int r1 = rng.Next(0, input.Length);
		System.Threading.Thread.Sleep(1);
		int r2 = rng.Next(0, sym.Length);
		System.Threading.Thread.Sleep(1);
		char[] zz = input.ToCharArray();		
		zz[r1] = sym[r2];
		input = new string(zz);
	}
	//random caps
	for (int i = 0; i != input.Length/4; i++)
	{
		char z = char.ToUpper(input[i]);
		char[] zz = input.ToCharArray();	
		zz[i] = z;
		input = new string(zz);
	}
	//add more symbols
	input = string.Format("{2}{1}{0}{3}{4}", input, sym[rng.Next(0, sym.Length)], sym[rng.Next(0, sym.Length)], sym[rng.Next(0, sym.Length)], sym[rng.Next(0, sym.Length)]);
	//salt 3 times
	for (int zzz = 0; zzz < 3; zzz++)
	{
		string salt = RandStr(rng.Next(5, 11));
		List<string> x = new List<string>();
		foreach(char i in input)
		{
			x.Add(i.ToString());
		}
		int[] index = {rng.Next(0, input.Length), new Random().Next(0, input.Length), new Random().Next(0, input.Length), new Random().Next(0, input.Length)};
		input = "";
		foreach (int i in index)
		{
			x.Insert(i, salt);
		}
		foreach (string i in x)
		{
			input += i;
		}
	}
	for (int i = 0; i != 10; i++)
	{
		int r1 = rng.Next(0, input.Length);
		System.Threading.Thread.Sleep(1);
		int r2 = rng.Next(0, sym.Length);
		System.Threading.Thread.Sleep(1);
		char[] zz = input.ToCharArray();		
		zz[r1] = sym[r2];
		input = new string(zz);
	}
	//random caps
	for (int i = 0; i != input.Length/4; i++)
	{
		char z = char.ToUpper(input[i]);
		char[] zz = input.ToCharArray();	
		zz[i] = z;
		input = new string(zz);
	}
	//add more symbols
	input = string.Format("{2}{1}{0}{3}{4}", input, sym[rng.Next(0, sym.Length)], sym[rng.Next(0, sym.Length)], sym[rng.Next(0, sym.Length)], sym[rng.Next(0, sym.Length)]);
	return input;
}
public static string RandStr(int length)
{
    string result = string.Empty;
    Random random = new Random((int)DateTime.Now.Ticks);
    List<string> characters = new List<string>();
    for (int i = 21; i < 127; i++)
    {
        characters.Add(((char)i).ToString());
    }
	for (int i = 0; i < length; i++)
	{
		result += characters[random.Next(0, characters.Count)];
		System.Threading.Thread.Sleep(1);
	}
    return result;
}
