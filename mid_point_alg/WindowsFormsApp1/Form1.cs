using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		MyGraphics myGraphics;
		Random rnd;
		float a = 0, b = 0;
		public Form1()
		{
			InitializeComponent();
			myGraphics = new MyGraphics(pictureBox1);
			rnd = new Random();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//DrawPolygon(myGraphics.grp, Pr(4, new PointF(250, 250), 150, 0));

			//for(float a = 0; a <=(float)Math.PI*2; a+= 0.01f)
			//{
			//	DrawPolygon(myGraphics.grp, Pr(4, new PointF(250, 250), 150, a));
			//}

			//for (float a = 0; a <= 200; a += 10)
			//{
			//	DrawPolygon(myGraphics.grp, Pr(4, new PointF(250, 250), a, 0));
			//}
			//float b = 0;
			//for (float a = 0; a <= 200; a += 10, b += 0.1f)
			//{
			//	DrawPoints(myGraphics.grp, Pr(6, new PointF(250, 250), a, b));
			//}


			DrawPolygon(myGraphics.grp, IregularPolygon(10, new PointF(250,250), 100, 200, 0.1f));
			myGraphics.Refresh();

		}

		private List<PointF> Pr(int n, PointF C, float R, float fi)
		{
			List<PointF> toReturn = new List<PointF>();

			float alpha = (float)(2 * Math.PI/n);

			for (int i = 0; i < n; i++)
			{
				float x = C.X + R * (float)Math.Cos(i * alpha + fi);
				float y = C.Y + R * (float)Math.Sin(i * alpha + fi);

				toReturn.Add(new PointF(x, y));
			}

			return toReturn;
		}

		private List<PointF> IregularPolygon(int n, PointF C, float minR, float maxR, float fi) //random values
		{
			List<PointF> toReturn = new List<PointF>();

			float[] alpha = new float[n];
			float[] dist = new float[n];

			for(int i = 0; i < n; i++)
			{
				alpha[i] = (float)rnd.NextDouble() * (float)(2 * 3.1415);
				dist[i] = (float)rnd.NextDouble() * (maxR - minR) + minR;
			}

			for(int i = 0; i < n; i++)
			{
				for(int j = i + 1; j < n; j++)
				{
					if (alpha[i] > alpha[j])
					{
						float aux = alpha[i];
						alpha[i] = alpha[j];
						alpha[j] = aux;
					}
				}
			}

			for(int i = 0; i < n; i++)
			{
				float x = C.X + dist[i] * (float)Math.Cos(alpha[i] + fi);
				float y = C.Y + dist[i] * (float)Math.Sin(alpha[i] + fi);

				toReturn.Add(new PointF(x, y));	
				myGraphics.grp.DrawLine(Pens.Red, x, y, C.X, C.Y);
			}

			return toReturn;
		}

		public void DrawPolygon(Graphics grp, List<PointF> points)
		{
			grp.DrawPolygon(new Pen(Color.Black), points.ToArray());
		}

		public void DrawPoints(Graphics grp, List<PointF> points)
		{
			foreach(var point in points)
			{
				grp.DrawEllipse(new Pen(Color.Black), point.X - 1, point.Y - 1, 3, 3);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			timer1.Enabled = true;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			a += 10;
			b += 0.1f;

			if(a >= 200)
			{
				a = 10;
			}

			myGraphics.Clear();
			DrawPoints(myGraphics.grp, Pr(100, new PointF(250, 250), a, b));
			myGraphics.Refresh();
		}
	}
}
