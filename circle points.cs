public static Point[] CirclePoints(double radius, double centerx, double centery)
{
	radius = radius <= 0 ? 1 : radius;
	Point[] output = new Point[359];
	for (int i = 0; i < 359; i++)
	{
		output[i] = new Point(Convert.ToInt32((Math.Cos(DegToRad(i))*r) + centerx), Convert.ToInt32((Math.Sin(DegToRad(i)) * r) + centery));
	}
	return output;
}
public static double DegToRad (double degrees)
{
    double radians = (Math.PI / 180) * degrees;
    return (radians);
}
