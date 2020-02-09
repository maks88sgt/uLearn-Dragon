
using System.Drawing;
using System;

namespace Fractals
{
	internal static class DragonFractalTask
	{
        public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
        {

            double x = 1.0;
            double y = 0.0;
            double angle45 = Math.PI * 45 / 180;
            double angle135 = Math.PI * 135 / 180;
            double angle;
            Random randomGenerator = new Random(seed);
            for (int i = 0; i < iterationsCount; i++)
            {
                int nextNumber = (int)randomGenerator.Next(0, 2);
                if (nextNumber == 1)
                {
                    angle = angle135;
                } 
                else
                {
                    angle = angle45;
                }
                var newXY = GenerateNewXY(x, y, angle, nextNumber);
                x = newXY[0];
                y = newXY[1];
                pixels.SetPixel(x, y);
            }
        }

        public static double[] GenerateNewXY (double x, double y, double angle, int nextNumber)
        {
            double[] result = new double[2];
            result[0] = ((x * Math.Cos(angle) - y * Math.Sin(angle)) / Math.Sqrt(2)) + nextNumber;
            result[1] = (x * Math.Sin(angle) + y * Math.Cos(angle)) / Math.Sqrt(2);
            return result;
        }
    }
}