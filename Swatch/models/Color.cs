using System;

namespace Swatch.Models
{
  public class Color
  {
    public string Hex {get;}
    public int Red {get;}
    public int Green {get;}
    public int Blue {get;}
    
    public Color(string hex)
    {
    this.Hex = hex;
    int[] rgb = HexToRGB(hex);
    this.Red = rgb[0];
    this.Green = rgb[1];
    this.Blue = rgb[2];
    }

    public Color(int[] rgb)
    {
      this.Hex = RGBToHex(rgb[0], rgb[1], rgb[2]);
      this.Red = rgb[0];
      this.Green = rgb[1];
      this.Blue = rgb[2];
    }

    public static int[] HexToRGB(string hex)
		{
			int[] returnArray = new int[3];
			for (int i = 0; i < 3; i++) 
			{
				returnArray[i] = Convert.ToInt32(hex.Substring((i*2), 2), 16);
			}
			return returnArray;
		}

		public static string RGBToHex(int red, int green, int blue)
		{
			string sred = red.ToString("X2");
			string sgreen = green.ToString("X2");
			string sblue = blue.ToString("X2");

			return (sred + sgreen + sblue);
		}
  }
}