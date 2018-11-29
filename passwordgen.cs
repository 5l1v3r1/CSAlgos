public static string Password(string input)
{
	input = input.ToLower();
	//leet
	input.Replace('a', '4');
	input.Replace('i', '1');
	input.Replace('e', '3');
	input.Replace('l', '7');
	input.Replace('g', '6');
	input.Replace('s', '5');
	input.Replace('z', '2');
	Console.WriteLine(input);
	//random symbols
	char[] sym = "~!@#$%^&*()_+{}|:\"<>?`-=[]\\;\',./".ToCharArray();
	Random rng = new Random();
	for (int i = 0; i != 10; i++)
	{
		int r1 = rng.Next(0, input.Length);
		int r2 = rng.Next(0, input.Length);
		char[] zz = input.ToCharArray();		
		zz[r1] = sym[r2];
		input = new string(zz);
	}
	Console.WriteLine(input);
	//random caps
	for (int i = 0; i != input.Length/4; i++)
	{
		char z = char.ToUpper(input[i]);
		char[] zz = input.ToCharArray();	
		zz[i] = z;
		input = new string(zz);
	}
	Console.WriteLine(input);
	//add more symbols
	input = string.Format("{2}{1}{0}{3}{4}", input, sym[rng.Next(0, sym.Length)], sym[rng.Next(0, sym.Length)], sym[rng.Next(0, sym.Length)], sym[rng.Next(0, sym.Length)]);
	Console.WriteLine(input);
	//salt
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
	return input;
}
public static string RandStr(int length)
{
    string result = string.Empty;
    Random random = new Random((int)DateTime.Now.Ticks);
    List<string> characters = new List<string>();
    for (int i = 48; i < 58; i++)
    {
        characters.Add(((char)i).ToString());
    }
    for (int i = 65; i < 91; i++)
    {
        characters.Add(((char)i).ToString());
    }
    for (int i = 97; i < 123; i++)
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
