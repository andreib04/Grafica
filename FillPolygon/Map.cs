using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillPolygon
{
	public class Map
	{
		List<Polygon> polygons;
		PointF point;
		Color fill;

		public Map(string fileName)
		{
			TextReader load = new StreamReader(fileName);
			string buffer;
			List<string> data = new List<string>();

			while((buffer = load.ReadLine()) != null)
			{
				data.Add(buffer);
			}
			load.Close();

			polygons = new List<Polygon>();

			for(int i = 0; i < data.Count - 1; i++)
			{
				polygons.Add(new Polygon(data[i]));
			}

			string[] line = data[data.Count - 1].Split(' ');
			point = new PointF(float.Parse(line[0]), float.Parse(line[1]));

			fill = Color.FromArgb(int.Parse(line[2]), int.Parse(line[3]), int.Parse(line[4]));

			for(int i = 0; i < 3; i++)
			{
				polygons.Add(new Polygon());
			}
		}

		public void Fill(MyGraphics handler)
		{
			Queue<PointF> queue = new Queue<PointF>();
			queue.Enqueue(point);
			handler.bmp.SetPixel((int)point.X, (int)point.Y, fill);
			do
			{
				PointF t = queue.Dequeue();
				if(t.X - 1 >= handler.resX)
				{
					Color a = handler.bmp.GetPixel((int)t.X - 1, (int)t.Y);

					if(a == handler.backColor)
					{
						handler.bmp.SetPixel((int)t.X - 1, (int)t.Y, fill);
						queue.Enqueue(new PointF(t.X - 1, t.Y));
					}
				}

				if(t.Y - 1 >= 0)
				{
					Color a = handler.bmp.GetPixel((int)t.X, (int)t.Y - 1);

					if(a == handler.backColor)
					{
						handler.bmp.SetPixel((int)t.X, (int)t.Y - 1, fill);
						queue.Enqueue(new PointF(t.X, t.Y - 1));
					}
				}

				if (t.Y + 1 >= 0)
				{
					Color a = handler.bmp.GetPixel((int)t.X, (int)t.Y - 1);

					if (a == handler.backColor)
					{
						handler.bmp.SetPixel((int)t.X, (int)t.Y - 1, fill);
						queue.Enqueue(new PointF(t.X, t.Y - 1));
					}
				}
			}
			while (queue.Count > 0);
			
		}

		public void Draw(Graphics handler)
		{
			foreach(Polygon p in polygons)
			{
				p.Draw(handler);
			}

			handler.DrawEllipse(Pens.Black, point.X - 2, point.Y - 2, 5, 5);
		}
	}
}
