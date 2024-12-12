using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drepte_intersectii
{
	public class MyGraphics
	{
		PictureBox display;
		public Graphics grp;
		public Bitmap bmp;
		public Color backColor = Color.LightBlue;

		public int resX { get { return display.Width; } }
		public int resY { get { return display.Height; } }

		public MyGraphics(PictureBox _display)
		{
			this.display = _display;
			bmp = new Bitmap(display.Width, display.Height);
			grp = Graphics.FromImage(bmp);
		}

		public void Clear()
		{
			grp.Clear(backColor);
		}

		public void Refresh()
		{
			display.Image = bmp;
		}
	}
}
