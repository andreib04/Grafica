using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			
		}
		MyGraphics graphics;
		//Un punct (x,y) il mutam in (x', y') - translatie
		//Transformare fata de un pivot (x'', y'')
		//Transformare fata de (0,0)

		//Daca am un punct de coordonate px, py 
		//Avem matricea T(1 0 x)
		//				 (0 1 y)
		//				 (0 0 1)
		//Coordonatele P' = P * T reprezinta coordonatele punctului translatat cu x, y

		//Avem matricea R (cos(T) -sin(T) 0)
		//				  (sin(T) cos(T)  0)
		//				  (0         0    1) reprezinta coordonatele P' = P * R
		//punctului rotit fata de origine

		//Matricea S (x 0 0)  P' = P * S reprezinta coordonatele punctului scalar
		//			 (0 y 0)
		//			 (0 0 1)

		Polygon polygon = new Polygon(@"../../polygon.txt");
		private void Form1_Load(object sender, EventArgs e)
		{
			Matrix T = new Matrix(@"../../fisier.txt");
			Matrix A = new Matrix(@"../../fisier2.txt");
			foreach(string s in (T*A).View())
			{
				listBox1.Items.Add(s);
			}

			graphics = new MyGraphics(pictureBox1);
			
			
			polygon.DrawP(graphics.grp);

			graphics.Refresh();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			polygon.Translatie((float)input1.Value, (float)input2.Value);
			polygon.DrawP(graphics.grp);

			graphics.Refresh();
		}
	}
}
