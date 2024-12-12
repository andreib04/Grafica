using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coloring
{
	public class Palette
	{
		public PointF location;
		public Color color;
		public static Random random = new Random();
		public int pound = 1;

		public Palette(int maxX, int maxY)
		{
			location = new PointF(random.Next(maxX), random.Next(maxY));
			color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
		}

		public void Draw(Graphics handler)
		{
			handler.FillEllipse(new SolidBrush(color), location.X - 2, location.Y - 2, 5, 5);
			handler.DrawEllipse(Pens.Black, location.X - 2, location.Y - 2, 5, 5);
		}
	}
}
