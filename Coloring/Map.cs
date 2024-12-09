using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coloring
{
	public class Map
	{
		List<Palette> palettes = new List<Palette>();
		public int resX, resY;
		public Map(int n, int resX, int resY)
		{
			this.resX = resX;
			this.resY = resY;
			for(int i = 0; i < n; i++)
			{
				palettes.Add(new Palette(resX, resY));
			}
		}

		public void Fill(Bitmap bmp)
		{
			for(int i = 0; i < resX; i++)
			{
				for (int j = 0; j < resY; j++)
				{
					Color c = Color.Black;
					float d = Dist(new PointF(0, 0), new PointF(resX, resY));
					foreach(Palette palette in palettes)
					{
						float crt = Dist(new PointF(i, j), palette.location);
						if(crt < d)
						{
							d = crt;
							c = palette.color;
						}
					}
					bmp.SetPixel(i, j, c);
				}
			
			}
		}
		public void FillPonder(Bitmap bmp)
		{
			for (int i = 0; i < resX; i++)
			{
				for (int j = 0; j < resY; j++)
				{
					float[] d = new float[palettes.Count];
					float R = 0;
					float G = 0;
					float B = 0;
					float sum = 0;



					for (int k = 0; k < palettes.Count; k++)
					{
					    d[k] = Dist(new PointF(i, j), palettes[k].location);
						
						sum += d[k];
						R += d[k] * palettes[k].color.R;
						G += d[k] * palettes[k].color.G;
						B += d[k] * palettes[k].color.B;
					}
					R /= sum;
					G /= sum; 
					B /= sum;

					bmp.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));
				}

			}
		}

		public float Dist(PointF A, PointF B)
		{
			return (float)Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
		}

		public void Draw(Graphics handler)
		{
			foreach (var palette in palettes)
			{
				palette.Draw(handler);
			}
		}
	}
}
