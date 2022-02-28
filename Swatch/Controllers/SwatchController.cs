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
		//localhost:5000/api/swatch?color1=DDDDDD&color2=000000&steps=3
		[HttpGet]
		public object TwoColorSwatch(string color1, string color2, string steps)
		{ 
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
			return JsonSerializer.Serialize(output);
		}
	}
}