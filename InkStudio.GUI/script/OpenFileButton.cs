using Godot;
using System;

public partial class OpenFileButton : Button
{
	private FileDialog fileDialog;
	private AcceptDialog sizeDialog;
	private SpinBox xInput;
	private SpinBox yInput;

	private string loadedCode;

	public override void _Ready()
	{
		fileDialog = GetNode<FileDialog>("../FileDialog");
		fileDialog.Hide();
		sizeDialog = GetNode<AcceptDialog>("AcceptDialog");
		xInput = sizeDialog.GetNode<SpinBox>("AcceptDialog/Control/canvasx");
		yInput = sizeDialog.GetNode<SpinBox>("AcceptDialog/Control/canvasy");
		sizeDialog.Confirmed += OnSizeConfirmed;
	}

	public void _on_pressed()
	{
		OnOpenFileButtonPressed();
	}

	private void OnOpenFileButtonPressed()
	{
		fileDialog.PopupCentered();
	}

	private void OnFileSelected(string path)
	{
		var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
		loadedCode = file.GetAsText();
		AskCanvasDimensions();
	}

	private void AskCanvasDimensions()
	{
		sizeDialog.PopupCentered();
	}

	private void OnSizeConfirmed()
	{
		int x = (int)xInput.Value;
		int y = (int)yInput.Value;

		var engine = new InkCodeRunner();
		engine.RunScript(loadedCode, x, y);
	}
}
