﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp_project
{
	public partial class Form1 : Form
	{
		private Bitmap drawArea;
		private const int RADIUS = 18;
		private Pen pen;
		private Pen whitePen;
		private Pen dashedPen;
		private Color vertColor = Color.Black;
		private List<(Point point, Color color)> verts;
		private int vertNumber = 0;
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
			dashedPen.DashPattern = new float[] { 3, 3 };
			whitePen.DashPattern = new float[] { 3, 3 };
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

							if ((yDiff < 2 * RADIUS) && (xDiff < 2 * RADIUS))
							{
								flag = it;
								break;
							}
							it++;
						}
					}

					if (flag != -1) // add edge
					{

					}
					else // add vertex
					{
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
					}

				}
				verts.Add((new Point(e.X, e.Y), vertColor));
				vertNumber++;
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
					int it = 0;
					foreach (var v in verts)
					{
						if (it == chosenVertNR)
						{
							++it;
							continue;
						}

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
					using (Graphics g = Graphics.FromImage(drawArea))
					{
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

				mouseIsDown = false;
			}
		}
	}
}



