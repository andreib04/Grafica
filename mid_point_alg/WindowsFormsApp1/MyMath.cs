using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	public class MyMath
	{
		public float PointDistance(PointF A, PointF B)
		{
			return (float)Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
		}

		public float Determinant(PointF A, PointF B, PointF C)
		{
			return (A.X * B.Y + B.X * C.Y + A.Y * C.X - C.X * B.Y - A.Y * B.X - C.Y * A.X);
		}

		public float Area(PointF A, PointF B, PointF C)
		{
			return 0.5f * (float)Math.Abs(Determinant(A, B, C));
		}

		public float AreaPolygon(PointF C, List<PointF> points)
		{
			float sum = 0;

			for (int i = 0; i < points.Count; i++)
			{
				sum += Area(C, points[i], points[(i + 1) % points.Count]);
			}

			return sum;
		}
	}
}
