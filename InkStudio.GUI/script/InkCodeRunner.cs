using Godot;
using InkCode.Engine;
using InkCode.Evaluator;

public partial class InkCodeRunner : Node, IEngineDebug
{
	InkEngine engine;
	private TextEdit ErrorOutput;
	private Canvas CanvasPanel;

	public override void _Ready()
	{
		engine = new InkEngine(this);
		ErrorOutput = GetNode<TextEdit>("Error Panel/Console");
		CanvasPanel = GetNode<Canvas>("CanvasPanel");
	}

	public override void _Process(double delta)
	{
	}

	public void RunScript(string code, int canvasX, int canvasY)
	{
		engine.Run(code, canvasX, canvasY);
	}

	public void OpenFile(string path, int canvasX, int canvasY)
	{
		engine.RunFile(path, canvasX, canvasY);
	}

	public void Report(int line, string message)
	{
		ErrorOutput.Text += $"[Línea {line}]: {message}\n";
	}

	public void PaintCanvas(CanvasState.Color[,] canvas)
	{
		CanvasPanel.SetCanvas(canvas);
	}

	public void Report(string message) { }
}
