using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raster_
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		Bitmap source, destination;

		private void button1_Click(object sender, EventArgs e)
		{
			int k = 4;
			for(int i = k; i < source.Width - k; i++)
			{
				for (int j = k; j < source.Height - k; j++)
				{
					List<Color> colors = new List<Color>();
					
					for(int l = -k; l <= k; l++)
					{
						for(int c = -k; c <= k; c++)
						{
							colors.Add(source.GetPixel(i + l, j + c));
						}
					}

					colors.Sort(delegate (Color A, Color B) 
								{ 
									return Engine.colorDistanceEuclidian(A).CompareTo(Engine.colorDistanceEuclidian(B)); 
								});

					destination.SetPixel(i, j, colors[colors.Count / 2]);
				}
			}

			pictureBox2.Image = destination;
		}

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			for(int i = 0; i < source.Width; i++)
			{
				for(int j = 0; j < source.Height; j++)
				{
					Color color = Engine.std(source.GetPixel(i, j), 32);
					destination.SetPixel(i, j, color);
				}
			}

			pictureBox2.Image = destination;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			button3_Click(sender, e);
			float eps = 32;

			//source = destination;

			for(int i = 0; i < source.Width; i++)
			{
				for(int j = 0; j < source.Height; j++)
				{
					source.SetPixel(i, j, destination.GetPixel(i, j));
				}
			}

			for(int i = 1; i < source.Width - 1; i++)
			{
				for(int j = 1; j < source.Height - 1; j++)
				{
					bool contur = false;
					Color color = source.GetPixel(i, j);
				
					for(int k = -1; k <= 1; k++)
					{
						
						for(int c = -1; c <= 1; c++)
						{ 
							Color color2 = source.GetPixel(i + k, j + c);

							if (Math.Abs(Engine.colorDistanceEuclidian(color) - Engine.colorDistanceEuclidian(color2)) > eps)
							{
								contur = true;
							} 
						}

						if (contur)
							destination.SetPixel(i, j, Color.Black);
						else
							destination.SetPixel(i, j, Color.White);
					}
				}
			}

			pictureBox2.Image = destination;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			source = new Bitmap(@"../../Pictures/bird1.jpg");
			pictureBox1.Image = source;
			destination = new Bitmap(source.Height, source.Width);


			//source = new Bitmap(@"../../Pictures/bird2.jpg");
			//pictureBox2.Image = source;

			//source = new Bitmap(@"../../Pictures/bird3.jpg");
			//pictureBox3.Image = source;
		}
	}
}
