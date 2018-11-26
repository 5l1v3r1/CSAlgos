public static decimal[] SmoothNoise2D(int width, int max, int frequency) //IS BROKEN
{
	/*
	how it works
	get points with a certain frequency 
	lerp from point to point
	make smooth curves with random radius from 0 - 2 (more freq, more smooth)
	*/
	decimal[] output = new decimal[width];
	for (int zzz = 0; zzz < width; zzz++)
	{
		output[zzz] = 0;
	}
	Random rng = new Random();
	int freq = frequency;
	decimal d = 0;
	int x = 0;
	//make points
	while (true) //this will ALWAYS break
	{
		try
		{
			output[x] = Convert.ToDecimal((decimal)Math.Floor(rng.NextDouble()) * max);
			x += freq;
			Thread.Sleep(1000); //make sure that it doesn't generate the same number 10 times
		}
		catch (Exception e) //eventually will be index out of range
		{
			break;
		}
	}
	x = 0;
	//lerp
	/*
	y =+ distance between points / freq
	*/
	while (x <= output.Length - 1 && freq != 1)
	{
		decimal p1 = output[x];
		decimal p2 = output[x + freq];
		if (p1 > p2)
		{
			decimal dis = (decimal)Math.Abs(p1-p2);
			decimal ad = dis/freq;
			for (int i = 0; i < (dis + freq); i++)
			{
				output[x + i] = p1 + (ad * i); //if i = 0, then it stays the same because it can be simplified as output[x + 0] = p1 + 0;  and X should be p1 in the first iteration, and it will end at output[output.IndexOf(p2) - 1]; so it never reaches p2
			}
		}
		else if (p1 < p2)
		{
			decimal dis = (decimal)Math.Abs(p1-p2);
			decimal ad = dis/freq;
			for (int i = 0; i < (dis + freq); i++)
			{
				output[x + i] = p1 - (ad * i); //if i = 0, then it stays the same because it can be simplified as output[x + 0] = p1 + 0;  and X should be p1 in the first iteration, and it will end at output[output.IndexOf(p2) - 1]; so it never reaches p2
			}
		}
		else if (p1 == p2)
		{
			for (int i = x; i != freq; i++)
			{
				output[x + i] = p1;
			}
		}
		x += freq;
	}
	//smooth
	/*
	sine waves
	intersect lerp?
	trim waves
	repeat at top
	*/
	int z = 0; //index of numbers
	for(int w = 0; w <= output.Length; w += freq)
	{
		for (int i = 0; i < output[z];i = (90/freq) * z)
		{
			output[z] += (decimal)Math.Sin(i);
			z++;
		}
		//top
		z = w + freq; //reuse variables! :)
		for (int i = 0; i > output[z];i = (90/freq) * z)
		{
			output[z] = (decimal)Math.Sin(i);
			z--;
		}
		z = w;
	}
	return output;
}
