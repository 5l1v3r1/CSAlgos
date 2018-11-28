public static string Txt2Hex(string str)
{
    var sb = new StringBuilder();

    var bytes = Encoding.Unicode.GetBytes(str);
    foreach (var t in bytes)
    {
        sb.Append(t.ToString("X2"));
    }

    return sb.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"
}
