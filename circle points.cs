public Point[] CirclePoints(int radius, Point CircleCenter)
{
	Point[] output = new Point[360];
	for (int a = 0; a < 360; a++)
	{
		output[a] = new Point((int)Math.Round(Math.Cos(DegreeToRadian(a)) * radius) + CircleCenter.X, (int)Math.Round(Math.Sin(DegreeToRadian(a)) * radius) + CircleCenter.Y);
	}
	return output;
}
private double DegreeToRadian(double angle)
{
   return Math.PI * angle / 180.0;
}
