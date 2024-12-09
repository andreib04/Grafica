using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arnold_Cat_Map
{
	public class ArnoldCatMap
	{
		public Bitmap source;
		Bitmap destination;

		public ArnoldCatMap(string fileName)
		{
			this.source = new Bitmap(Image.FromFile(fileName));
		}

		public ArnoldCatMap(Bitmap source)
		{
			this.source = source;
		}

		public new void Iterate()
		{
			destination = new Bitmap(source.Width, source.Height);

			for(int i = 0; i < source.Width; i++)
			{
				for(int j = 0; j < source.Height; j++)
				{
					int x = (2 * i + j) % source.Width;
					int y = (i + j) % source.Height;
					destination.SetPixel(x,y, source.GetPixel(i,j));
				}
			}

			source = destination;
		}
	}
}
