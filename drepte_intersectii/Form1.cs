using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drepte_intersectii
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		PointF intersect(PointF A, PointF B, PointF C, PointF D)
		{
			float deltaS = (A.Y - B.Y) * (D.X - C.X) - (B.X - A.X) * (C.Y - D.Y);

			if(deltaS == 0)
			{
				return PointF.Empty;
			}

			float deltaX = (A.Y * B.X - A.X * B.Y) * (D.X - C.X) - (B.X - A.X) * (C.Y * D.X - C.X * D.Y);
			float deltaY = (A.Y - B.Y) * (C.Y * D.X - C.X * D.Y) - (C.Y - D.Y) * (A.Y * B.X - A.X * B.Y);

			float x = deltaX / deltaS;
			float y = deltaY / deltaS;

			if((x >= A.X && x <= B.X) || (x >= B.X && x <= A.X)
					&& (x >= C.X || x <= D.X) || (x >= D.X && x <= C.X))
					return new PointF(x, y);

			return PointF.Empty;
		}

		Graphics grp;
		Bitmap bmp;
		public static Random rnd = new Random();
		private void Form1_Load(object sender, EventArgs e)
		{
			bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			grp = Graphics.FromImage(bmp);

			for (int i = 0; i < 5; i++)
			{
				PointF A = new PointF(rnd.Next(pictureBox1.Width), rnd.Next(pictureBox1.Height));
				PointF B = new PointF(rnd.Next(pictureBox1.Width), rnd.Next(pictureBox1.Height));
				PointF C = new PointF(rnd.Next(pictureBox1.Width), rnd.Next(pictureBox1.Height));
				PointF D = new PointF(rnd.Next(pictureBox1.Width), rnd.Next(pictureBox1.Height));
				PointF M;

				Color t = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

				grp.DrawLine(new Pen(t), A, B);
				grp.DrawLine(new Pen(t), C, D);
				M = intersect(A, B, C, D);
				if (M != PointF.Empty)
					grp.DrawEllipse(Pens.Red, M.X - 5, M.Y - 5, 11, 11);

				pictureBox1.Image = bmp;
			}
			
		}
	}
}
