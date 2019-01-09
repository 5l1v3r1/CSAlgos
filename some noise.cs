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
	//smooth
	/*
	sine waves
	intersect lerp?
	trim waves
	repeat at top
	*/
	int z = 0; //index of numbers
	for (int index = 0; index < freq; index += 0)
	{
		decimal p1 = output[index];
		decimal p2 = output[index + freq];
		decimal dis = p2-p1;
		if (true)
		{
			int angle = 90/freq;
			for (int i = index + 1; i < index + freq; i++)
			{
				output[i] = p1 + (Math.Sin(angle) * dis);
				angle += 90/freq;
			}
		}
		index += freq;
	}
	return output;
}
