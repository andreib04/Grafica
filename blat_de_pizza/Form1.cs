using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blat_de_pizza
{
	public partial class Form1 : Form
	{
		public static Random rnd = new Random();
		Graphics g;
		Bitmap bmp;
		public Form1()
		{
			InitializeComponent();
			bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			g = Graphics.FromImage(bmp);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			PointF[] demo = BlatDePizza(new PointF(300, 300), 100, 105, 60);
			

			g.FillPolygon(new SolidBrush(Color.Gold), demo);
			g.DrawPolygon(new Pen(Color.Black), demo);

			PointF[] demo1 = BlatDePizza(new PointF(300, 300), 90, 95, 60);
			g.FillPolygon(new SolidBrush(Color.Red), demo1);
			g.DrawPolygon(new Pen(Color.Black), demo1);

			for(int j = 0; j < 100; j++)
			{
				float alpha = (float)rnd.NextDouble() * (2 * (float)Math.PI);
				float d = (float)rnd.NextDouble() * 80;
				float x = 300 + d * (float)Math.Cos(alpha);
				float y = 300 + d * (float)Math.Sin(alpha);

				PointF[] demo2 = Dispersie(new PointF(x, y), 90, 10);

				for (int i = 0; i < demo2.Length; i++)
				{
					int t = rnd.Next(1, 4);
					g.FillEllipse(new SolidBrush(Color.White), demo2[i].X - t, demo2[i].Y - t, 2*t+1, 2*t+1);
				}
			}

			for(int i = 0; i < 10; i++)
			{
				float alpha = (float)rnd.NextDouble() * (2 * (float)Math.PI);
				float d = (float)rnd.NextDouble() * 70;
				float x = 300 + d * (float)Math.Cos(alpha);
				float y = 300 + d * (float)Math.Sin(alpha);
				Pepperoni(new PointF(x, y));
			}

			pictureBox1.Image = bmp;
		}

		public void Pepperoni(PointF center)
		{
			PointF[] t = BlatDePizza(center, 15, 16, 36);
			g.FillPolygon(new SolidBrush(Color.DarkRed), t);
			g.DrawPolygon(new Pen(Color.Black), t);

			PointF[] d = Dispersie(center, 15, 20);

			for (int i = 0; i < d.Length; i++)
			{
				int x = rnd.Next(1, 2);
				g.FillEllipse(new SolidBrush(Color.RosyBrown), d[i].X - x, d[i].Y - x, 2 * x + 1, 2 * x + 1);
			}

		}

		public PointF[] Dispersie(PointF center, float rMax, int n)
		{
			PointF[] toR = new PointF[n];

			for(int i = 0; i < n; i++)
			{
				float alpha = (float)rnd.NextDouble() * (2 * (float)Math.PI);
				float d = (float)rnd.NextDouble() * rMax;
				float x = center.X + d * (float)Math.Cos(alpha);
				float y = center.Y + d * (float)Math.Sin(alpha);
				toR[i] = new PointF(x, y);
			}

			return toR;
		}

		public PointF[] BlatDePizza(PointF center, float dMin, float dMax, int k)
		{
			PointF[] toR = new PointF[k];
			float[] distances = new float[k];
			float alpha = (2 * (float)Math.PI) / k;

			for(int i = 0; i < k; i++)
			{
				distances[i] = (float)rnd.NextDouble() * (dMax - dMin) + dMin;
			}

			for(int i = 0; i < k; i++)
			{
				float x = center.X + distances[i] * (float)Math.Cos(alpha * i);
				float y = center.Y + distances[i] * (float)Math.Sin(alpha * i);

				toR[i] = new PointF(x, y);
			}

			return toR;
		}
	}
}
