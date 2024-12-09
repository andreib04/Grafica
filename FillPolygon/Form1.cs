using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillPolygon
{
	public partial class Form1 : Form
	{
		MyGraphics graphics;
		Map map;
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			graphics = new MyGraphics(pictureBox1);
			map = new Map(@"../../input.txt");

			map.Draw(graphics.grp);
			map.Fill(graphics);

			graphics.Refresh();
		}
	}
}
