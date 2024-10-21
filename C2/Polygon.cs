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
	internal class MyPoint
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
		MyPoint[] points;

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

	}
}
