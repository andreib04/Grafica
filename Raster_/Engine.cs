using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raster_
{
	public static class Engine
	{
		public static double colorDistanceEuclidian(Color c)
		{
			return Math.Sqrt(c.R * c.R + c.B * c.B + c.G * c.G);
		}

		public static double colorDistanceManhattan(Color c)
		{
			return c.R + c.B + c.G;
		}

		public static Color std(Color c, int k)
		{
			int R = (c.R / k) * k;
			int G = (c.G / k) * k;
			int B = (c.B / k) * k;

			return Color.FromArgb(R, G, B);
		}
	}
}
