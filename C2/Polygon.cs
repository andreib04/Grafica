using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2
{
	//TODO introducerea transformarilor R, T, S pe un MyPoint
	//
	public class MyPoint
	{
		public float X, Y;

		public MyPoint(float x, float y)
		{
			X = x;
			Y = y;
		}	

		public void Draw(Graphics handler)
		{
			handler.DrawEllipse(Pens.Black, X - 3, Y - 3, 7, 7);
		}

	}
	public class Polygon
	{
	    public MyPoint[] points;

		public Polygon(int length)
		{
			points= new MyPoint[length];
		}

		public Polygon(string fileName)
		{
			TextReader load = new StreamReader(fileName);
			List<string> data = new List<string>();
			string buffer;

			while ((buffer = load.ReadLine()) != null)
			{
				data.Add(buffer);
			}
			load.Close();

			points = new MyPoint[data.Count];

			for (int i = 0; i < data.Count; i++)
			{
				float X = float.Parse(data[i].Split(' ')[0]);
				float Y = float.Parse(data[i].Split(' ')[1]);
				points[i] = new MyPoint(X, Y);
			}
		}

		public void DrawP(Graphics handler)
		{
			for(int i = 0; i < points.Length; i++)
			{
				handler.DrawLine(Pens.Red, points[i].X, points[i].Y, points[(i + 1) % points.Length].X, points[(i + 1) % points.Length].Y);
			}

			foreach(MyPoint p in points)
			{
				p.Draw(handler);
			}
		}

		public void Translatie(float x, float y)
		{
			for(int i = 0; i < points.Length; i++)
			{
				points[i].X += x;
				points[i].Y += y;
			}
		}

		public Polygon Rotation(float angle, Polygon polygon)
		{
			Matrix R = new Matrix(3, 3);
			R.values[0, 0] = (float)Math.Cos(angle);
			R.values[0, 1] = -(float)(Math.Sin(angle));
			R.values[1,0] = (float)Math.Sin(angle);
			R.values[1, 1] = (float)Math.Cos(angle);
			R.values[2, 2] = 1;



			Matrix toR = R * polygon.polygonToMatrix();

			return toR.matrixToPolygon();
		}

		public Matrix polygonToMatrix()
		{
			Matrix toR = new Matrix(points.Length, 2);

			for(int i = 0; i < points.Length; i++)
			{
				toR.values[0, 1] = (int)points[i].X;
				toR.values[1, i] = (int)points[i].Y;
			}

			return toR;
		}

	}
}
