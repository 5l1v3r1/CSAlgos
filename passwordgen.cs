public static string Password(string input)
{
	//for later stuff
	input = input.ToLower();
	//leet
	input.Replace("a" "4");
	input.Replace("i" "1");
	input.Replace("e" "3");
	input.Replace("l" "7");
	input.Replace("g" "6");
	input.Replace("s" "5");
	input.Replace("z" "2");
	//random symbols
	string sym = "~!@#$%^&*()_+{}|:\"<>?`-=[]\;\',./\\";
	for (int i = 0; i != 10; i++)
	{
		input[new Random().Next(0, input.Length)] = sym[new Random().Next(0, sym.Length)];
	}
	//random caps
	for (int i = 0; i != input.Length/2; i++)
	{
		input[i] = input[i].ToUpper();
	}
	//add more symbols
	input = string.Format("{1}{1}{0}{1}{1}", input, sym[new Random().Next(0, sym.Length)]);
	//salt
	string salt = RandStr(new Random().Next(5, 11));
	List<string> x = new List<string>();
	foreach(char i in input)
	{
		x.Add(i.ToString());
	}
	int[] index = {new Random().Next(0, input.Length), new Random().Next(0, input.Length), new Random().Next(0, input.Length), new Random().Next(0, input.Length)};
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
    List<string> characters = new List<string>() { };
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
        Thread.Sleep(1);
    }
    return result;
}
