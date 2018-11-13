public List<Color> ColorLerp(Color a, Color b)
{
	List<Color> output = new List<Color>();
	output.Add(a);
	//get changes in r, g, and b
	int cr = a.R - b.R;
	int cg = a.G - b.G;
	int cb = a.B - b.B;
	//average out differences
	int av = (cr + cg + cb) / 3;
	//proportions to prepare for lerping
	//1/(change) = x/(average)
	//cross multiply and divide
	/*
	Ex:
	1      x
	--- = ---
	cr     av
	So...
	pr = crx = av
	pr = av/cr
	*/
	int pr = av/cr;
	int pg = av/cg;
	int pb = av/cb;
	//slope = cy / cx
	//cy = cr/cg/cb
	//cx = av
	//slope cr/cg/cb/av
	for (int i = 0; i != av)
	{
		//lerp!
		output.Add(new Color(/*R*/ cr > 0 ? a.R + cr/av : a.R - cr/av, /*G*/ cg > 0 ? a.G + cg/av : a.G - cg/av, /*B*/ cb > 0 ? a.B + cb/av : a.B - cb/av));
	}
	output.Add(b);
	return output;
}
