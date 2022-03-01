using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Swatch.Models;

namespace Swatch.Controllers
{
	[ApiController]
	[Route("api/swatch")]
	public class SwatchController : ControllerBase
	{
		public SwatchController()
		{
		}
		//localhost:5000/api/swatch/two?color1=DDDDDD&color2=000000&steps=3
		[HttpGet("two")]
		public object TwoColorSwatch(string color1, string color2, string steps)
		{ 
			List<Color> output = tweenColors(color1,color2,steps);
			return JsonSerializer.Serialize(output);
		}
		//localhost:5000/api/swatch/four?color1=DDDDDD&color2=000000&color3=FFFFFF&color4=EEEEEE&steps=3
		[HttpGet("four")]
		public object FourColorSwatch(string color1, string color2, string color3, string color4, string steps)
		{
			int size = int.Parse(steps) + 2;
			List<List<Color>> output = new List<List<Color>>{};
			List<Color> leftCol = tweenColors(color1, color3, steps);
			List<Color> rightCol = tweenColors(color2,color4,steps);
			for(int i = 0; i<leftCol.Count; i++){
				output.Add(tweenColors(leftCol[i].Hex,rightCol[i].Hex,steps));
			}
			return JsonSerializer.Serialize(output);
		}

		public static List<Color> tweenColors(string color1, string color2, string steps){
			int stepsAsInt = int.Parse(steps) + 1;
			Color start = new Color(color1);
			Color end = new Color(color2);

      List<Color> output = new List<Color> {};
			output.Add(start);
			for (int i = 1; i < stepsAsInt; i++)
			{
        int weight = stepsAsInt - i;
        int red = ((start.Red * weight) + end.Red * i) / stepsAsInt;
        int green = ((start.Green * weight) + end.Green * i) / stepsAsInt;
        int blue = ((start.Blue * weight) + end.Blue * i) / stepsAsInt;
        output.Add(new Color(new int[] {red, green, blue}));
			}
			output.Add(end);
			return output;
		}

	}
}