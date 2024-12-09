using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace points2D3D
{
	public partial class Form1 : Form
	{
		Graphics grp;
		Bitmap bmp;
		public PointF RTS(PointF P, PointF M, float teta)
		{
			float x = (float)Math.Cos(teta) * (P.X - M.X) - (float)Math.Sin(teta) * (P.Y - M.Y) + M.X;
			float y = (float)Math.Sin(teta) * (P.X - M.X) + (float)Math.Cos(teta) * (P.Y - M.Y) + M.Y;

			return new PointF(x, y);
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			grp = Graphics.FromImage(bmp);

			PointF test1 = new PointF(100, 100);
			PointF test2 = new PointF(200, 100);

			for(float i = 0.2f; i < 10; i+= 0.2f)
			{
				PointF tt1 = RTS(test1, new PointF(150, 150), i);
				PointF tt2 = RTS(test2, new PointF(150, 150), i);

				grp.DrawLine(Pens.Black, tt1, tt2);
			}

			

			grp.DrawLine(Pens.Black, test1, test2);

			

			pictureBox1.Image = bmp;
		}
	}
}
