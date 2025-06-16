using Godot;
using InkCode.Evaluator;

public partial class Canvas : Control
{
	private CanvasState.Color[,] colorGrid;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetCanvas(CanvasState.Color[,] newGrid)
	{
		colorGrid = newGrid;
		QueueRedraw();
	}

	public override void _Draw()
	{
		if (colorGrid == null) return;

		int rows = colorGrid.GetLength(0);
		int cols = colorGrid.GetLength(1);
		float cellSize = 10f;

		for (int y = 0; y < rows; y++)
		{
			for (int x = 0; x < cols; x++)
			{
				Color drawColor = ConvertEnumToColor(colorGrid[y, x]);
				DrawRect(new Rect2(x * cellSize, y * cellSize, cellSize, cellSize), drawColor);
			}
		}
	}

	public static Color ConvertEnumToColor(CanvasState.Color color)
	{
	return color switch
	{
		CanvasState.Color.White  => new Color(1, 1, 1),                  // Blanco
		CanvasState.Color.Red    => new Color(1, 0, 0),                  // Rojo
		CanvasState.Color.Blue   => new Color(0, 0, 1),                  // Azul
		CanvasState.Color.Green  => new Color(0, 1, 0),                  // Verde
		CanvasState.Color.Yellow => new Color(1, 1, 0),                  // Amarillo
		CanvasState.Color.Orange => new Color(1, 0.5f, 0),              // Naranja
		CanvasState.Color.Purple => new Color(0.5f, 0, 0.5f),           // Púrpura
		CanvasState.Color.Black  => new Color(0, 0, 0),                  // Negro
		_ => new Color(0.5f, 0.5f, 0.5f) // Gris como fallback
	};
}
}
