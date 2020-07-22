using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using FileHandling;
using DataModeling;
using System.Windows.Input;

namespace ObjectPainter
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        PictureBox picturebox;

        public MainWindow()
		{
			InitializeComponent();

            // Create picture box where all shapes are drawn.
            picturebox = new PictureBox();
            drawArea.Child = picturebox;
        }

		private void DrawArea_Paint(object sender, PaintEventArgs e)
		{
			foreach (IShape Shape in DataModel.ShapeList)
			{
				Shape.Draw(e);
			}
		}

        private void Command_LoadFromFile_Executed(object sender, ExecutedRoutedEventArgs e)
        {
			// If there is already text in the editing area, show warning message box.
			if (editArea.Text != string.Empty)
			{
				var result = System.Windows.Forms.MessageBox.Show(Constants.RELOAD_SCRIPT_MESSAGE, Constants.WARNING_MESSAGE_TITLE,
																  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (result == System.Windows.Forms.DialogResult.No)
				{
					return;
				}
			}
			editArea.Text = FileHandle.LoadFile();
        }

        private void Command_GenerateScript_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void Command_Draw_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Hide the command when no text in the textbox
            e.CanExecute = !(String.IsNullOrEmpty(editArea.Text));
        }

        private void Command_Draw_Executed(object sender, ExecutedRoutedEventArgs e)
        {
			// Parse scripts to get shape's attributes.
			DataModel dataModel = new DataModel();
			dataModel.ParseScript(editArea.Text);

			/* Create event for painting */
			// Delegate to the draw area.
			picturebox.Paint += new PaintEventHandler(DrawArea_Paint);
		}

        private void Command_SaveToFile_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Hide the command when no text in the textbox
            e.CanExecute = !(String.IsNullOrEmpty(editArea.Text));
        }

        private void Command_SaveToFile_Executed(object sender, ExecutedRoutedEventArgs e)
        {

		}

        private void Command_Exit_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			System.Windows.Application.Current.Shutdown();
		}
    }


    public static class CustomCommand
    {
        public static readonly RoutedUICommand LoadFromFile = new RoutedUICommand
        (
            "LoadFromFile", "LoadFromFile",
            typeof(CustomCommand),
            new InputGestureCollection()
            {
                 new KeyGesture(Key.L, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand GenerateScript = new RoutedUICommand
        (
            "GenerateScript", "GenerateScript",
            typeof(CustomCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.G, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Draw = new RoutedUICommand
        (
            "Draw", "Draw",
            typeof(CustomCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.D, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand SaveToFile = new RoutedUICommand
        (
            "SaveSaveFile", "SaveSaveFile",
            typeof(CustomCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.S, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Exit = new RoutedUICommand
        (
            "Exit", "Exit",
            typeof(CustomCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F4, ModifierKeys.Alt)
            }
        );
    }

}

