using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using ObjectPainter;

namespace DataModeling
{
	public class DataModel
	{
		public static List<IShape> ShapeList { get; private set; }

		public DataModel()
		{
			ShapeList = new List<IShape>();
		}

		protected List<string> GetSection(string inScript)
		{
			List<string> sectionList = new List<string>();
			List<string> sectionNameList = new List<string>();

			string section = "";
			int start = 0;
			int end = 0;
			// Search for "[section_name]"
			string pattern = @"\[(.*?)\]";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(inScript);

			while (true)
			{
				try
				{
					// Get list of section names.
					// Then compare section names.
					// If duplicate section names, show error message.
					sectionNameList.Add(match.Value);
					if ((sectionNameList.Count() != sectionNameList.Distinct().Count()) == true)
					{
						throw new Exception(Constants.EXCEPTION);
					}
					start = match.Index;
					match = match.NextMatch();
					if (match.Success)
					{
						end = match.Index;
						section = inScript.Substring(start, end - start);
						sectionList.Add(section);
					}
					else
					{    // If this is the last section
						section = inScript.Substring(start);
						sectionList.Add(section);
						break;
					}
				}
				catch (Exception)
				{
					string msg = string.Format("Duplicate object IDs: {0}", match.Value);
					MessageBox.Show(msg, Constants.ERROR_MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return new List<string>();      // TODO better solution
				}

			}
			return sectionList;
		}

#if (REGEX)
		public void ParseScript(string inScript)
		{
			// Search for "type"
			string pattern_type = @"(type)[\t ]{0,}=[\t ]{0,}(\w+)";
			Regex regex_type = new Regex(pattern_type, RegexOptions.Multiline | RegexOptions.IgnoreCase);

			List<string> sectionList = GetSection(inScript);
			foreach (string section in sectionList)
			{
				MatchCollection matchCollection = regex_type.Matches(section);
				// If more than one "type" are found, show error message.
				if (matchCollection.Count > 1)
				{
					break;
				}

				GroupCollection groupCollection = matchCollection[0].Groups;
				// groupCollection[0] : full match
				// groupCollection[1] : left hand side of "="
				// groupCollection[2] : right hand side of "="

				// Search for shape's attributes other than "type"
				string pattern_others = @"(\w+)[\t ]{0,}=[\t ]{0,}([\w+-]+)";
				Regex regex_others = new Regex(pattern_others, RegexOptions.Multiline | RegexOptions.IgnoreCase);

				// If type is line
				if (groupCollection[2].Value.Equals(Constants.LINE, StringComparison.OrdinalIgnoreCase))
				{
					Line line = new Line();
					this.ParseScript_Line(section, line, regex_others);
					if (line.IsCorrectFormat() == false)
					{
						return;
					}
					ShapeList.Add(line);
				}
				// If type is rectangle
				else if (groupCollection[2].Value.Equals(Constants.RECTANGLE, StringComparison.OrdinalIgnoreCase))
				{
					ObjectPainter.Rectangle rec = new ObjectPainter.Rectangle();
					this.ParseScript_Rectangle(section, rec, regex_others);
					if (rec.IsCorrectFormat() == false)
					{
						return;
					}
					ShapeList.Add(rec);
				}

			}
		}
#else
        public void ParseScript(string inScript)
        {
            List<string> sectionList = GetSection(inScript);
            foreach (string section in sectionList)
            {
                // TODO parse type
                string[] lineList = section.Split('\n');
                foreach (string scriptLine in lineList)
                {
                    // If more than one "=" (eg: "x0==100"), BUG !!!
                    if (scriptLine.Contains("=") == false)
                    {
                        continue;
                    }

                    string[] attributeList = scriptLine.Split('=');
                    string lhs = attributeList[0].Trim();
                    string rhs = attributeList[1].Trim();
                    if (lhs.Equals(Constants.TYPE, StringComparison.OrdinalIgnoreCase))
                    {
                        if (rhs.Equals(Constants.LINE, StringComparison.OrdinalIgnoreCase))
                        {
                            Line line = new Line();
                            this.ParseScript_Line(section, line);
                            if (line.IsCorrectFormat() == false)
                            {
                                return;
                            }
                            ShapeList.Add(line);
                        }
                        else if (rhs.Equals(Constants.RECTANGLE, StringComparison.OrdinalIgnoreCase))
                        {
                            ObjectPainter.Rectangle rec = new ObjectPainter.Rectangle();
                            this.ParseScript_Rectangle(section, rec);
                            if (rec.IsCorrectFormat() == false)
                            {
                                return;
                            }
                            ShapeList.Add(rec);
                        }
                    }
                }

            }
        }
#endif

#if (REGEX)
		private void ParseScript_Line(string inSection, Line inLine, Regex inRegex)
		{
			MatchCollection matchCollection = inRegex.Matches(inSection);
			foreach (Match match in matchCollection)
			{
				GroupCollection groupCollection = match.Groups;
				// groupCollection[0] : full match
				// groupCollection[1] : left hand side of "="
				// groupCollection[2] : right hand side of "="
				if (groupCollection[1].Value.Equals(Constants.X0, StringComparison.OrdinalIgnoreCase))
				{
					inLine.StartPoint.X = Convert.ToInt16(groupCollection[2].Value);
				}
				else if (groupCollection[1].Value.Equals(Constants.Y0, StringComparison.OrdinalIgnoreCase))
				{
					inLine.StartPoint.Y = Convert.ToInt16(groupCollection[2].Value);
				}
				else if (groupCollection[1].Value.Equals(Constants.X1, StringComparison.OrdinalIgnoreCase))
				{
					inLine.EndPoint.X = Convert.ToInt16(groupCollection[2].Value);
				}
				else if (groupCollection[1].Value.Equals(Constants.Y1, StringComparison.OrdinalIgnoreCase))
				{
					inLine.EndPoint.Y = Convert.ToInt16(groupCollection[2].Value);
				}
				else if (groupCollection[1].Value.Equals(Constants.BRUSH_THICKNESS, StringComparison.OrdinalIgnoreCase))
				{
					inLine.BrushThickness = Convert.ToInt16(groupCollection[2].Value);
				}
				else if (groupCollection[1].Value.Equals(Constants.BRUSH_COLOR, StringComparison.OrdinalIgnoreCase))
				{
					inLine.BrushColor = Color.FromName(groupCollection[2].Value);
				}
			}
		}

		private void ParseScript_Rectangle(string inSection, ObjectPainter.Rectangle inRect, Regex inRegex)
		{
			MatchCollection matchCollection = inRegex.Matches(inSection);
			foreach (Match match in matchCollection)
			{
				GroupCollection groupCollection = match.Groups;
				// groupCollection[0] : full match
				// groupCollection[1] : left hand side of "="
				// groupCollection[2] : right hand side of "="
				if (groupCollection[1].Value.Equals(Constants.X0, StringComparison.OrdinalIgnoreCase))
				{
					inRect.StartPoint.X = Convert.ToInt16(groupCollection[2].Value);
				}
				else if (groupCollection[1].Value.Equals(Constants.Y0, StringComparison.OrdinalIgnoreCase))
				{
					inRect.StartPoint.Y = Convert.ToInt16(groupCollection[2].Value);
				}
				else if (groupCollection[1].Value.Equals(Constants.HEIGHT, StringComparison.OrdinalIgnoreCase))
				{
					inRect.Height = Convert.ToInt16(groupCollection[2].Value);
				}
				else if (groupCollection[1].Value.Equals(Constants.WIDTH, StringComparison.OrdinalIgnoreCase))
				{
					inRect.Width = Convert.ToInt16(groupCollection[2].Value);
				}
				else if (groupCollection[1].Value.Equals(Constants.BACKGROUND_COLOR, StringComparison.OrdinalIgnoreCase))
				{
					inRect.BackgroudColor = Color.FromName(groupCollection[2].Value);
				}
				else if (groupCollection[1].Value.Equals(Constants.BRUSH_THICKNESS, StringComparison.OrdinalIgnoreCase))
				{
					inRect.BrushThickness = Convert.ToInt16(groupCollection[2].Value);
				}
				else if (groupCollection[1].Value.Equals(Constants.BRUSH_COLOR, StringComparison.OrdinalIgnoreCase))
				{
					inRect.BrushColor = Color.FromName(groupCollection[2].Value);
				}
			}
		}
#else
        private void ParseScript_Line(string inSection, Line inLine)
        {
            string[] lineList = inSection.Split('\n');
            foreach (string line in lineList)
            {
                if (line.Contains("=") == false
                    || line.ToLower().Contains(Constants.TYPE) == true
                    || line == ""
                    || line == "\r")
                {
                    continue;
                }
                string[] attributeList = line.Split('=');
                string lhs = attributeList[0].Trim();
                string rhs = attributeList[1].Trim();

                // TODO: break error is not interger
                if (lhs.Equals(Constants.X0, StringComparison.OrdinalIgnoreCase))
                {
                    inLine.StartPoint.X = Convert.ToInt16(rhs);
                }
                else if (lhs.Equals(Constants.Y0, StringComparison.OrdinalIgnoreCase))
                {
                    inLine.StartPoint.Y = Convert.ToInt16(rhs);
                }
                else if (lhs.Equals(Constants.X1, StringComparison.OrdinalIgnoreCase))
                {
                    inLine.EndPoint.X = Convert.ToInt16(rhs);
                }
                else if (lhs.Equals(Constants.Y1, StringComparison.OrdinalIgnoreCase))
                {
                    inLine.EndPoint.Y = Convert.ToInt16(rhs);
                }
                else if (lhs.Equals(Constants.BRUSH_THICKNESS, StringComparison.OrdinalIgnoreCase))
                {
                    inLine.BrushThickness = Convert.ToInt16(rhs);
                }
                else if (lhs.Equals(Constants.BRUSH_COLOR, StringComparison.OrdinalIgnoreCase))
                {
                    inLine.BrushColor = Color.FromName(rhs);
                }
            }
        }

        private void ParseScript_Rectangle(string inSection, ObjectPainter.Rectangle inRec)
        {
            string[] lineList = inSection.Split('\n');
            foreach (string line in lineList)
            {
                if (line.Contains("=") == false
                    || line.ToLower().Contains(Constants.TYPE) == true
                    || line == ""
                    || line == "\r")
                {
                    continue;
                }
                // If more than one "=" (eg: "x0==100"), BUG !!!
                // If there is no rhs (eg: "x0="), BUG !!! To fix, add condition to check the rhs
                string[] attributeList = line.Split('=');
                string lhs = attributeList[0].Trim();
                string rhs = attributeList[1].Trim();

                if (lhs.Equals(Constants.X0, StringComparison.OrdinalIgnoreCase))
                {
                    inRec.StartPoint.X = Convert.ToInt16(rhs);
                }
                else if (lhs.Equals(Constants.Y0, StringComparison.OrdinalIgnoreCase))
                {
                    inRec.StartPoint.Y = Convert.ToInt16(rhs);
                }
                else if (lhs.Equals(Constants.WIDTH, StringComparison.OrdinalIgnoreCase))
                {
                    inRec.Width = Convert.ToInt16(rhs);
                }
                else if (lhs.Equals(Constants.HEIGHT, StringComparison.OrdinalIgnoreCase))
                {
                    inRec.Height = Convert.ToInt16(rhs);
                }
                else if (lhs.Equals(Constants.BACKGROUND_COLOR, StringComparison.OrdinalIgnoreCase))
                {
                    inRec.BackgroudColor = Color.FromName(rhs);
                }
                else if (lhs.Equals(Constants.BRUSH_THICKNESS, StringComparison.OrdinalIgnoreCase))
                {
                    inRec.BrushThickness = Convert.ToInt16(rhs);
                }
                else if (lhs.Equals(Constants.BRUSH_COLOR, StringComparison.OrdinalIgnoreCase))
                {
                    inRec.BrushColor = Color.FromName(rhs);
                }
            }
        }
#endif
	}
}
