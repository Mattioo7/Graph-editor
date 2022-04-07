using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp_project
{
	public partial class Form1 : Form
	{
		private Bitmap drawArea;
		private const int RADIUS = 16;
		private Pen pen;
		private Pen whitePen;
		private Pen dashedPen;
		private Color vertColor = Color.Black;
		private List<(Point point, Color color)> verts;
		private int vertNumber;
		private Point chosenVert;
		private int chosenVertNR;
		private Point mousePosition;
		private bool mouseIsDown;
		private Point new_vertexPosition;
		private List<(Point p1, Point p2)> edges;

		public Form1()
		{
			InitializeComponent();

			drawArea = new Bitmap(workingArea.Size.Width, workingArea.Size.Height);
			workingArea.Image = drawArea;
			using (Graphics g = Graphics.FromImage(drawArea))
			{
				g.Clear(Color.LightBlue);
			}

			colorField.BackColor = vertColor;
			verts = new List<(Point, Color)>();
			pen = new Pen(Color.Black, 3);
			dashedPen = new Pen(Brushes.Black, 3);
			whitePen = new Pen(Brushes.White, 3);
			dashedPen.DashPattern = new float[] { 2, 2 };
			whitePen.DashPattern = new float[] { 2, 2 };
			vertNumber = 0;
			chosenVert = new Point(-1, -1);
			chosenVertNR = -1;
			mousePosition = new Point(-1, -1);
			mouseIsDown = false;
			new_vertexPosition = new Point();
			edges = new List<(Point p1, Point p2)>();
		}

		private void Form1_SizeChanged(object sender, EventArgs e)
		{
			int it = 0;
			var newsize = tableLayoutPanel1.GetControlFromPosition(0, 0).Size;
			drawArea = new Bitmap(newsize.Width, newsize.Height);
			workingArea.Image = drawArea;
			using (Graphics g = Graphics.FromImage(drawArea))
			{
				g.Clear(Color.LightBlue);
			}

			foreach (var edge in edges)
			{
				using (Graphics g = Graphics.FromImage(drawArea))
				{
					g.DrawLine(pen, edge.p1, edge.p2);
				}
			}
			foreach (var v in verts)
			{
				using (Graphics g = Graphics.FromImage(drawArea))
				{
					g.FillEllipse(Brushes.LightBlue, v.point.X - RADIUS + 2, v.point.Y - RADIUS + 2, (RADIUS - 2) * 2, (RADIUS - 2) * 2);
					g.DrawEllipse(new Pen(v.color, 3), v.point.X - RADIUS, v.point.Y - RADIUS, RADIUS * 2, RADIUS * 2);
					g.DrawString(it.ToString(),
						new Font("Ink Free", 12),
						new SolidBrush(v.color),
						v.point.X, v.point.Y,
						new StringFormat()
						{ Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

					if (chosenVertNR != -1 && it == chosenVertNR)
					{
						g.DrawEllipse(whitePen, v.point.X - RADIUS, v.point.Y - RADIUS, RADIUS * 2, RADIUS * 2);
					}
				}
				++it;
			}

			workingArea.Refresh();
		}

		private void workingArea_MouseDown(object sender, MouseEventArgs e)
		{
			int flag = -1;

			if (e.Button == MouseButtons.Left)
			{
				using (Graphics g = Graphics.FromImage(drawArea))
				{
					if (vertNumber > 0)
					{
						int it = 0;
						foreach (var v in verts)
						{
							int yDiff = Math.Abs(v.point.Y - e.Y);
							int xDiff = Math.Abs(v.point.X - e.X);

							//if ((yDiff < (2 * RADIUS)) && (xDiff < (2 * RADIUS)))
							if (yDiff * yDiff + xDiff * xDiff < 4 * (RADIUS + 1) * (RADIUS + 1))
							{
								flag = it;
								break;
							}
							it++;
						}
					}

					if (flag != -1 && chosenVertNR != -1) // add edge
					{
						edges.Add((chosenVert, verts[flag].point));
						g.DrawLine(pen, chosenVert, verts[flag].point);

						g.FillEllipse(Brushes.LightBlue, chosenVert.X - RADIUS + 2, chosenVert.Y - RADIUS + 2, (RADIUS-2) * 2, (RADIUS-2) * 2);

						int it = 0;
						foreach (var v in verts)
						{
							g.FillEllipse(Brushes.LightBlue, v.point.X - RADIUS + 2, v.point.Y - RADIUS + 2, (RADIUS - 2) * 2, (RADIUS - 2) * 2);
							g.DrawEllipse(new Pen(v.color, 3), v.point.X - RADIUS, v.point.Y - RADIUS, RADIUS * 2, RADIUS * 2);
							g.DrawString(it.ToString(),
								new Font("Ink Free", 12),
								new SolidBrush(v.color),
								v.point.X, v.point.Y,
								new StringFormat()
								{ Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

							++it;
						}

						g.DrawEllipse(whitePen, chosenVert.X - RADIUS, chosenVert.Y - RADIUS, RADIUS * 2, RADIUS * 2);
					}
					else if (flag == -1) // add vertex
					{
						g.FillEllipse(Brushes.LightBlue, e.X - RADIUS + 2, e.Y - RADIUS + 2, (RADIUS - 2) * 2, (RADIUS - 2) * 2);
						g.DrawEllipse(pen, e.X - RADIUS, e.Y - RADIUS, RADIUS * 2, RADIUS * 2);
						g.DrawString(vertNumber.ToString(),
							new Font("Ink Free", 12),
							new SolidBrush(vertColor),
							e.X, e.Y,
							new StringFormat()
							{ Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
						if (chosenVertNR != -1)
						{
							g.DrawEllipse(whitePen, chosenVert.X - RADIUS, chosenVert.Y - RADIUS, RADIUS * 2, RADIUS * 2);
						}
						verts.Add((new Point(e.X, e.Y), vertColor));
						vertNumber++;
					}

				}
				workingArea.Refresh();
			}
			else if (e.Button == MouseButtons.Right)
			{
				int yDiffBest = int.MaxValue;
				int xDiffBest = int.MaxValue;
				int iBest = -1;

				int i = 0;

				foreach (var v in verts)
				{
					int yDiff = Math.Abs(v.point.Y - e.Y);
					int xDiff = Math.Abs(v.point.X - e.X);

					if ((yDiff < 2 * RADIUS) && (xDiff < 2 * RADIUS) && yDiff < yDiffBest && xDiff < xDiffBest)
					{
						xDiffBest = xDiff;
						yDiffBest = yDiff;
						iBest = i;
					}
					i++;
				}

				if (chosenVert.X != -1)
				{
					int it = 0;
					foreach (var v in verts)
					{
						using (Graphics g = Graphics.FromImage(drawArea))
						{
							g.DrawEllipse(new Pen(v.color, 3), v.point.X - RADIUS, v.point.Y - RADIUS, RADIUS * 2, RADIUS * 2);
							g.DrawString(it.ToString(),
								new Font("Ink Free", 12),
								new SolidBrush(v.color),
								v.point.X, v.point.Y,
								new StringFormat()
								{ Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
						}
						++it;
					}

					chosenVert.X = -1;
					chosenVertNR = -1;
					DeleteButton.Enabled = false;
					workingArea.Refresh();
				}

				if (iBest != -1)
				{
					using (Graphics g = Graphics.FromImage(drawArea))
					{
						chosenVert.X = verts[iBest].point.X;
						chosenVert.Y = verts[iBest].point.Y;
						chosenVertNR = iBest;
						g.DrawEllipse(whitePen, chosenVert.X - RADIUS, chosenVert.Y - RADIUS, RADIUS * 2, RADIUS * 2);
						workingArea.Refresh();
					}

					DeleteButton.Enabled = true;
				}
				workingArea.Refresh();
			}
			else if (e.Button == MouseButtons.Middle && chosenVertNR != -1)
			{
				mousePosition.X = e.X;
				mousePosition.Y = e.Y;
				mouseIsDown = true;
			}
		}

		private void ColorButton_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				vertColor = colorDialog.Color;
				pen.Color = vertColor;
				colorField.BackColor = vertColor;
			}

			verts[chosenVertNR] = (new Point(verts[chosenVertNR].point.X, verts[chosenVertNR].point.Y), vertColor);
			var v = verts[chosenVertNR];
			using (Graphics g = Graphics.FromImage(drawArea))
			{
				g.DrawEllipse(new Pen(v.color, 3), v.point.X - RADIUS, v.point.Y - RADIUS, RADIUS * 2, RADIUS * 2);
				g.DrawString(chosenVertNR.ToString(),
					new Font("Ink Free", 12),
					new SolidBrush(v.color),
					v.point.X, v.point.Y,
					new StringFormat()
					{ Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
				g.DrawEllipse(whitePen, chosenVert.X - RADIUS, chosenVert.Y - RADIUS, RADIUS * 2, RADIUS * 2);
			}

			workingArea.Refresh();
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			int it = 0;
			foreach (var v in verts)
			{
				if (v.point.X == chosenVert.X && v.point.Y == chosenVert.Y)
				{
					break;
				}
				it++;
			}
			verts.RemoveAt(it);
			it = 0;
			using (Graphics g = Graphics.FromImage(drawArea))
			{
				g.Clear(Color.LightBlue);
				foreach (var v in verts)
				{
					g.DrawEllipse(new Pen(v.color, 3), v.point.X - RADIUS, v.point.Y - RADIUS, RADIUS * 2, RADIUS * 2);
					g.DrawString(it.ToString(),
						new Font("Ink Free", 12),
						new SolidBrush(v.color),
						v.point.X, v.point.Y,
						new StringFormat()
						{ Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
					++it;
				}
			}
			chosenVert.X = -1;
			chosenVertNR = -1;
			DeleteButton.Enabled = false;
			vertNumber--;
			workingArea.Refresh();
		}

		private void workingArea_MouseMove(object sender, MouseEventArgs e)
		{
			new_vertexPosition.X = e.X - mousePosition.X + chosenVert.X;
			new_vertexPosition.Y = e.Y - mousePosition.Y + chosenVert.Y;

			if (mouseIsDown == true)
			{
				if (chosenVert.X != -1)
				{
					using (Graphics g = Graphics.FromImage(drawArea))
					{
						g.Clear(Color.LightBlue);

						g.DrawEllipse(pen, e.X - mousePosition.X + chosenVert.X - RADIUS, e.Y - mousePosition.Y + chosenVert.Y - RADIUS, RADIUS * 2, RADIUS * 2);
						g.DrawString(chosenVertNR.ToString(),
							new Font("Ink Free", 12),
							new SolidBrush(vertColor),
							e.X - mousePosition.X + chosenVert.X, e.Y - mousePosition.Y + chosenVert.Y,
							new StringFormat()
							{ Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
					}
					foreach (var edge in edges)
					{
						if (edge.p1 == chosenVert)
						{
							
							using (Graphics g = Graphics.FromImage(drawArea))
							{
								g.DrawLine(pen, edge.p2, new Point(e.X - mousePosition.X + chosenVert.X, e.Y - mousePosition.Y + chosenVert.Y));
								//g.FillEllipse(Brushes.Red, e.X - mousePosition.X + chosenVert.X - RADIUS + 2, e.Y - mousePosition.Y - RADIUS + 2, (RADIUS - 2) * 2, (RADIUS - 2) * 2);
							}
							continue;
						}
						else if (edge.p2 == chosenVert)
						{
							using (Graphics g = Graphics.FromImage(drawArea))
							{
								g.DrawLine(pen, edge.p1, new Point(e.X - mousePosition.X + chosenVert.X, e.Y - mousePosition.Y + chosenVert.Y));
								//g.FillEllipse(Brushes.Green, e.X - mousePosition.X + chosenVert.X - RADIUS + 2, e.Y - mousePosition.Y - RADIUS + 2, (RADIUS - 2) * 2, (RADIUS - 2) * 2);
							}
							continue;
						}

						using (Graphics g = Graphics.FromImage(drawArea))
						{
							g.DrawLine(pen, edge.p1, edge.p2);
							//g.FillEllipse(Brushes.Black, e.X - mousePosition.X + chosenVert.X - RADIUS + 2, e.Y - mousePosition.Y - RADIUS + 2, (RADIUS - 2) * 2, (RADIUS - 2) * 2);
						}
						
					}
					int it = 0;
					//int it2 = 0;
					foreach (var v in verts)
					{
						if (it == chosenVertNR)
						{
							++it;
							continue;
						}

						using (Graphics g = Graphics.FromImage(drawArea))
						{
							g.FillEllipse(Brushes.LightBlue, v.point.X - RADIUS + 2, v.point.Y - RADIUS + 2, (RADIUS - 2) * 2, (RADIUS - 2) * 2);
							g.DrawEllipse(new Pen(v.color, 3), v.point.X - RADIUS, v.point.Y - RADIUS, RADIUS * 2, RADIUS * 2);
							g.DrawString(it.ToString(),
								new Font("Ink Free", 12),
								new SolidBrush(v.color),
								v.point.X, v.point.Y,
								new StringFormat()
								{ Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
						}
						++it;
					}
					using (Graphics g = Graphics.FromImage(drawArea))
					{
						g.FillEllipse(Brushes.LightBlue, e.X - mousePosition.X + chosenVert.X - RADIUS + 2, e.Y - mousePosition.Y + chosenVert.Y - RADIUS + 2, (RADIUS - 2) * 2, (RADIUS - 2) * 2);
						g.DrawString(chosenVertNR.ToString(),
								new Font("Ink Free", 12),
								new SolidBrush(vertColor),
								e.X - mousePosition.X + chosenVert.X, e.Y - mousePosition.Y + chosenVert.Y,
								new StringFormat()
								{ Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
						g.DrawEllipse(whitePen, e.X - mousePosition.X + chosenVert.X - RADIUS, e.Y - mousePosition.Y + chosenVert.Y - RADIUS, RADIUS * 2, RADIUS * 2);
					}

				}
				workingArea.Refresh();
			}
		}

		private void workingArea_MouseUp(object sender, MouseEventArgs e)
		{
			if (mouseIsDown == true)
			{
				// update vertex ends
				for (int i = 0; i < edges.Count; ++i)
				{
					if (edges[i].p1 == chosenVert)
					{
						edges[i] = (new Point(e.X - mousePosition.X + chosenVert.X, e.Y - mousePosition.Y + chosenVert.Y), edges[i].p2);
					}
					if (edges[i].p2 == chosenVert)
					{
						edges[i] = (edges[i].p1, new Point(e.X - mousePosition.X + chosenVert.X, e.Y - mousePosition.Y + chosenVert.Y));
					}
				}
				
				
				chosenVert.X = e.X - mousePosition.X + chosenVert.X;
				chosenVert.Y = e.Y - mousePosition.Y + chosenVert.Y;

				verts[chosenVertNR] = (new Point(chosenVert.X, chosenVert.Y), vertColor);

				int it = 0;
				foreach (var v in verts)
				{
					using (Graphics g = Graphics.FromImage(drawArea))
					{
						g.DrawEllipse(new Pen(v.color, 3), v.point.X - RADIUS, v.point.Y - RADIUS, RADIUS * 2, RADIUS * 2);
						g.DrawString(it.ToString(),
							new Font("Ink Free", 12),
							new SolidBrush(v.color),
							v.point.X, v.point.Y,
							new StringFormat()
							{ Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
					}
					++it;
				}

				if  (chosenVertNR != -1)
				{
					using (Graphics g = Graphics.FromImage(drawArea))
					{
						g.DrawEllipse(whitePen, chosenVert.X - RADIUS, chosenVert.Y - RADIUS, RADIUS * 2, RADIUS * 2);
					}
				}

				workingArea.Refresh();

				mouseIsDown = false;
			}
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (chosenVertNR != -1)
			{
				int it = 0;
				foreach (var v in verts)
				{
					if (v.point.X == chosenVert.X && v.point.Y == chosenVert.Y)
					{
						break;
					}
					it++;
				}
				verts.RemoveAt(it);
				it = 0;
				using (Graphics g = Graphics.FromImage(drawArea))
				{
					g.Clear(Color.LightBlue);
					foreach (var v in verts)
					{
						g.DrawEllipse(new Pen(v.color, 3), v.point.X - RADIUS, v.point.Y - RADIUS, RADIUS * 2, RADIUS * 2);
						g.DrawString(it.ToString(),
							new Font("Ink Free", 12),
							new SolidBrush(v.color),
							v.point.X, v.point.Y,
							new StringFormat()
							{ Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
						++it;
					}
				}
				chosenVert.X = -1;
				chosenVertNR = -1;
				DeleteButton.Enabled = false;
				vertNumber--;
				workingArea.Refresh();
			}
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog safeDialog = new SaveFileDialog())
			{ 
				safeDialog.Filter = "Graph files (*.graph)|*.graph";
				if (safeDialog.ShowDialog() == DialogResult.OK)
				{
					var filename = safeDialog.FileName;

					using (StreamWriter sw = File.CreateText(filename))
					{
						foreach (var v in verts)
						{
							sw.WriteLine(v.point.X.ToString());
							sw.WriteLine(v.point.Y.ToString());
							sw.WriteLine(v.color.ToArgb());
						}
						sw.WriteLine("e");
						foreach (var edge in edges)
						{
							sw.WriteLine(edge.p1.X.ToString());
							sw.WriteLine(edge.p1.Y.ToString());
							sw.WriteLine(edge.p2.X.ToString());
							sw.WriteLine(edge.p2.Y.ToString());
						}
					}

					MessageBox.Show("File saved");
				}
			}
		}

		private void LoadButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openDialog = new OpenFileDialog())
			{
				openDialog.Filter = "Graph files (*.graph)|*.graph";
				if (openDialog.ShowDialog() == DialogResult.OK)
				{
					//var filename = openDialog.FileName;

					using (StreamReader sw = new StreamReader(openDialog.OpenFile()))
					{
						try
						{
							LoadGraph(sw, out verts, out edges);

							using (Graphics g = Graphics.FromImage(drawArea))
							{
								g.Clear(Color.LightBlue);

								int it = 0;
								foreach (var edge in edges)
								{
									g.DrawLine(pen, edge.p1, edge.p2);
								}


								foreach (var v in verts)
								{
									g.FillEllipse(Brushes.LightBlue, v.point.X - RADIUS + 2, v.point.Y - RADIUS + 2, (RADIUS - 2) * 2, (RADIUS - 2) * 2);
									g.DrawEllipse(new Pen(v.color, 3), v.point.X - RADIUS, v.point.Y - RADIUS, RADIUS * 2, RADIUS * 2);
									g.DrawString(it.ToString(),
										new Font("Ink Free", 12),
										new SolidBrush(v.color),
										v.point.X, v.point.Y,
										new StringFormat()
										{ Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

									++it;
								}



							}

							workingArea.Refresh();
						}
						catch
						{
							MessageBox.Show("Error load");
							return;
						}
					}
				}
			}
		}

		private void LoadGraph(StreamReader stream, out List<(Point point, Color color)> verts, out List<(Point p1, Point p2)> edges)
		{
			var newEdges = new List<(Point p1, Point p2)>();
			var newVerts = new List<(Point point, Color color)>();

			while (!stream.EndOfStream && stream.Peek() != 'e')
			{
				var line1 = stream.ReadLine();
				var line2 = stream.ReadLine();
				var line3 = stream.ReadLine();
				newVerts.Add((new Point(int.Parse(line1), int.Parse(line2)), Color.FromArgb(int.Parse(line3))));
			}

			if (stream.Peek() == 'e')
				stream.ReadLine();

			while (!stream.EndOfStream && stream.Peek() != 'e')
			{
				var line1 = stream.ReadLine();
				var line2 = stream.ReadLine();
				var line3 = stream.ReadLine();
				var line4 = stream.ReadLine();
				newEdges.Add((new Point(int.Parse(line1), int.Parse(line2)), new Point(int.Parse(line3), int.Parse(line4))));
			}


			verts = newVerts;
			edges = newEdges;
		}

		private void ClearButton_Click(object sender, EventArgs e)
		{
			verts.Clear();
			edges.Clear();
			vertColor = Color.Black;
			vertNumber = 0;
			chosenVert = new Point(-1, -1);
			chosenVertNR = -1;

			using (Graphics g = Graphics.FromImage(drawArea))
			{
				g.Clear(Color.LightBlue);
			}

			workingArea.Refresh();
		}
	}
}



