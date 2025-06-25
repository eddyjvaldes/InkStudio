using System;
using Godot;
using InkCode.Engine;
using InkCode.Evaluator;

class EngineReporter : IEngineDebug
{
	TextEdit errors;
	Ide ide;

	public EngineReporter(TextEdit text, Ide ide)
	{
		errors = text;
		this.ide = ide;
	}

	public void Report(string message)
	{ }

	public void Report(int number, string error)
	{
		errors.Text += $"\n [{number}] : {error}";
	}

	public void PaintCanvas(CanvasState.Color[,] colors)
	{
		int height = colors.GetLength(0);
		int width = colors.GetLength(1);

		ide.image = Image.CreateEmpty(width, height, false, Image.Format.Rgba8);

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				var colorEnum = colors[y, x];
				ide.image.SetPixel(x, y, ConvertEnumToColor(colorEnum));
			}
		}

		ide.texture = ImageTexture.CreateFromImage(ide.image);
		ide.canvas.Texture = (Texture2D)ide.texture;
	}

	private static Color ConvertEnumToColor(CanvasState.Color c)
	{
		return c switch
		{
			CanvasState.Color.White => Color.Color8(250, 245, 235),
			CanvasState.Color.Red => Color.Color8(255, 0, 0),
			CanvasState.Color.Blue => Color.Color8(0, 0, 255),
			CanvasState.Color.Green => Color.Color8(0, 255, 0),
			CanvasState.Color.Yellow => Color.Color8(255, 255, 0),
			CanvasState.Color.Orange => Color.Color8(255, 165, 0),
			CanvasState.Color.Purple => Color.Color8(128, 0, 128),
			CanvasState.Color.Black => Color.Color8(0, 0, 0),
			CanvasState.Color.Transparent => new Color(0, 0, 0, 0),
			_ => Color.Color8(255, 255, 255)
		};
	}
}
