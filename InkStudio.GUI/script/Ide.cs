using Godot;
using InkCode.Engine;
using System;

public partial class Ide : Node2D
{
	InkEngine inkEngine;
	EngineReporter reporter;
	public int CanvasHeight = 1;
	public int CanvasWidth = 1;
	public Image image;
	public TextureRect canvas;
	public Texture texture;
	CodeEdit code;
	TextEdit errors;
	FileDialog fileDialog;
	AcceptDialog canvasDimensionDialog;

	public override void _Ready()
	{
		errors = GetNode<TextEdit>("Error Panel");

		reporter = new(errors, this);
		inkEngine = new(reporter);

		canvas = GetNode<TextureRect>("Canvas");
		code = GetNode<CodeEdit>("Code Box");
		fileDialog = GetNode<FileDialog>("Open File Button/FileDialog");
		canvasDimensionDialog = GetNode<AcceptDialog>("Canvas Dimension Dialog");
	}

	public override void _Process(double delta)
	{
	}

	public void _on_draw_button_pressed()
	{
		errors.Clear();
		ResetCanvas();;
		reporter.PaintCanvas(inkEngine.Run(code.Text, CanvasHeight, CanvasWidth));
	}

	public void _on_open_file_button_pressed()
	{
		fileDialog.PopupCentered();
	}

	public void _on_canvas_dimension_button_pressed()
	{
		canvasDimensionDialog.PopupCentered();
	}

	public void _on_file_dialog_file_selected(string path)
	{
		errors.Clear();
		ResetCanvas();
		reporter.PaintCanvas(inkEngine.RunFile(path, CanvasHeight, CanvasWidth));
	}

	public void _on_canvas_height_value_changed(float value)
	{
		CanvasHeight = (int)value;
	}

	public void _on_canvas_width_value_changed(float value)
	{
		CanvasWidth = (int)value;
	}

	public void _on_canvas_dimension_dialog_confirmed()
	{
		ResizeCanvas(CanvasHeight, CanvasWidth);
	}

	public void ResizeCanvas(int newWidth, int newHeight)
	{
		image = Image.CreateEmpty(newWidth, newHeight, false, Image.Format.Rgba8);

		ResetCanvas();
	}

	public void ResetCanvas()
	{
		image.Fill(Color.Color8(250, 245, 235));

		texture = ImageTexture.CreateFromImage(image);  
		canvas.Texture = (Texture2D)texture;
	}
}
