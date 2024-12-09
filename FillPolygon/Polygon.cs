using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillPolygon
{
	public class Polygon
	{
		Random rnd  = new Random();
		PointF[] points;
		public Polygon(string data)
		{
			string[] strings = data.Split(' ');
			points = new PointF[strings.Length / 2];

			for(int i = 0; i < strings.Length; i += 2)
			{
				float X = float.Parse(strings[i]);
				float Y = float.Parse(strings[i + 1]);

				points[i / 2] = new PointF(X, Y);
			}
		}

		public Polygon()
		{
			int n = rnd.Next(3, 6);
			points = new PointF[n];

			for(int i = 0; i < n; i++)
			{
				points[i] = new PointF(rnd.Next(1024), rnd.Next(600));
			}
		}

		public void Draw(Graphics handler)
		{
			handler.DrawPolygon(Pens.Black, points);
		}
	}
}
