using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace FileHandling
{
	public class FileHandle
	{
		public static string LoadFile()
		{
			// Dialog to open file with two buttons: Open and Cancel.
			OpenFileDialog openFileDialog = new OpenFileDialog()
			{
				Filter = "Configuration files (*.ini)|*.ini|Text files (*.txt)|*.txt",
				RestoreDirectory = true
			};

			// If press Cancel button, stop the function.
			if (openFileDialog.ShowDialog() == DialogResult.Cancel)
			{
				return string.Empty;
			}

			// Get file name of the selected file.
			string fileName = openFileDialog.FileName;
			// Open the file.
			//var fileStream = openFileDialog.OpenFile();
			//// Read the file.
			//var streamReader = new StreamReader(fileStream);
			//string fileContent = streamReader.ReadToEnd();
			return File.ReadAllText(fileName);
		}
	}
}
