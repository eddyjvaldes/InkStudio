using Godot;
using System;

public partial class RunButton : Button
{
	private AcceptDialog sizeDialog;
	private SpinBox xInput;
	private SpinBox yInput;

	public override void _Ready()
	{
		sizeDialog = GetNode<AcceptDialog>("../AcceptDialog");
		sizeDialog.Hide();
		xInput = sizeDialog.GetNode<SpinBox>("AcceptDialog/Control/canvasx");
		yInput = sizeDialog.GetNode<SpinBox>("AcceptDialog/Control/canvasy");

		// Pressed += OnRunButtonPressed;
		sizeDialog.Confirmed += OnSizeConfirmed;
	}

	public void _on_pressed()
	{
		OnRunButtonPressed();
		OnSizeConfirmed();
	}

	private void OnRunButtonPressed()
	{
		sizeDialog.PopupCentered();
	}

	private void OnSizeConfirmed()
	{
		int x = (int)xInput.Value;
		int y = (int)yInput.Value;
		var code = GetNode<TextEdit>("Code Panel/CodeEdit").Text;

		var engine = new InkCodeRunner();
		engine.RunScript(code, x, y);
	}
}
