using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multigraf
{
	public class Bezier
	{
		PointF A, B;
		int k;
		List<PointF> points;

		public Bezier(PointF A,  PointF B, int k)
		{
			this.A = A;
			this.B = B;
			this.k = k;
		}

		public void Do()
		{
			points = new List<PointF>();
			for(int i = 0; i < k; i++)
			{
				float x = i * A.X + (k - i) * B.X;
				float y = i * A.Y + (k - i) * B.Y;
				points.Add(new PointF(x / k, y / k));
			}
		}

		public void Draw(Graphics handler)
		{
			handler.DrawEllipse(Pens.Red, A.X - 5, A.Y - 5, 11, 11);
			handler.DrawEllipse(Pens.Red, B.X - 5, B.Y - 5, 11, 11);
			
			for(int i = 0; i < points.Count; i++)
			{
				if(i == 3)
				{
					handler.DrawEllipse(Pens.Black, points[i]);
				}
				
			}
		}
	}
}
