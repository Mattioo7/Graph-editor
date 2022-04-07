
namespace WinFormsApp_project
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.LanguageBox = new System.Windows.Forms.GroupBox();
			this.EnglishLanguageButton = new System.Windows.Forms.Button();
			this.PolishLanguageButton = new System.Windows.Forms.Button();
			this.EditionBox = new System.Windows.Forms.GroupBox();
			this.DeleteButton = new System.Windows.Forms.Button();
			this.colorField = new System.Windows.Forms.Label();
			this.ColorButton = new System.Windows.Forms.Button();
			this.ImportBox = new System.Windows.Forms.GroupBox();
			this.LoadButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.workingArea = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.LanguageBox.SuspendLayout();
			this.EditionBox.SuspendLayout();
			this.ImportBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.workingArea)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.workingArea, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.LanguageBox, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.EditionBox, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.ImportBox, 0, 2);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(630, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(151, 555);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// LanguageBox
			// 
			this.LanguageBox.Controls.Add(this.EnglishLanguageButton);
			this.LanguageBox.Controls.Add(this.PolishLanguageButton);
			this.LanguageBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LanguageBox.Location = new System.Drawing.Point(3, 258);
			this.LanguageBox.Name = "LanguageBox";
			this.LanguageBox.Size = new System.Drawing.Size(145, 144);
			this.LanguageBox.TabIndex = 0;
			this.LanguageBox.TabStop = false;
			this.LanguageBox.Text = "Język";
			// 
			// EnglishLanguageButton
			// 
			this.EnglishLanguageButton.Enabled = false;
			this.EnglishLanguageButton.Location = new System.Drawing.Point(7, 74);
			this.EnglishLanguageButton.Name = "EnglishLanguageButton";
			this.EnglishLanguageButton.Size = new System.Drawing.Size(138, 46);
			this.EnglishLanguageButton.TabIndex = 1;
			this.EnglishLanguageButton.Text = "Angielski";
			this.EnglishLanguageButton.UseVisualStyleBackColor = true;
			// 
			// PolishLanguageButton
			// 
			this.PolishLanguageButton.Enabled = false;
			this.PolishLanguageButton.Location = new System.Drawing.Point(6, 22);
			this.PolishLanguageButton.Name = "PolishLanguageButton";
			this.PolishLanguageButton.Size = new System.Drawing.Size(138, 46);
			this.PolishLanguageButton.TabIndex = 0;
			this.PolishLanguageButton.Text = "Polski";
			this.PolishLanguageButton.UseVisualStyleBackColor = true;
			// 
			// EditionBox
			// 
			this.EditionBox.Controls.Add(this.DeleteButton);
			this.EditionBox.Controls.Add(this.colorField);
			this.EditionBox.Controls.Add(this.ColorButton);
			this.EditionBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EditionBox.Location = new System.Drawing.Point(3, 3);
			this.EditionBox.Name = "EditionBox";
			this.EditionBox.Size = new System.Drawing.Size(145, 249);
			this.EditionBox.TabIndex = 1;
			this.EditionBox.TabStop = false;
			this.EditionBox.Text = "Edycja";
			// 
			// DeleteButton
			// 
			this.DeleteButton.Enabled = false;
			this.DeleteButton.Location = new System.Drawing.Point(7, 51);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(132, 23);
			this.DeleteButton.TabIndex = 2;
			this.DeleteButton.Text = "Usuń wierzchołek";
			this.DeleteButton.UseVisualStyleBackColor = true;
			this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// colorField
			// 
			this.colorField.AutoSize = true;
			this.colorField.Location = new System.Drawing.Point(87, 26);
			this.colorField.MinimumSize = new System.Drawing.Size(40, 15);
			this.colorField.Name = "colorField";
			this.colorField.Size = new System.Drawing.Size(40, 15);
			this.colorField.TabIndex = 1;
			// 
			// ColorButton
			// 
			this.ColorButton.Location = new System.Drawing.Point(6, 22);
			this.ColorButton.Name = "ColorButton";
			this.ColorButton.Size = new System.Drawing.Size(75, 23);
			this.ColorButton.TabIndex = 0;
			this.ColorButton.Text = "Kolor";
			this.ColorButton.UseVisualStyleBackColor = true;
			this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
			// 
			// ImportBox
			// 
			this.ImportBox.Controls.Add(this.LoadButton);
			this.ImportBox.Controls.Add(this.SaveButton);
			this.ImportBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ImportBox.Location = new System.Drawing.Point(3, 408);
			this.ImportBox.Name = "ImportBox";
			this.ImportBox.Size = new System.Drawing.Size(145, 144);
			this.ImportBox.TabIndex = 2;
			this.ImportBox.TabStop = false;
			this.ImportBox.Text = "Import/Export";
			// 
			// LoadButton
			// 
			this.LoadButton.Enabled = false;
			this.LoadButton.Location = new System.Drawing.Point(6, 83);
			this.LoadButton.Name = "LoadButton";
			this.LoadButton.Size = new System.Drawing.Size(138, 46);
			this.LoadButton.TabIndex = 2;
			this.LoadButton.Text = "Wczytaj";
			this.LoadButton.UseVisualStyleBackColor = true;
			// 
			// SaveButton
			// 
			this.SaveButton.Enabled = false;
			this.SaveButton.Location = new System.Drawing.Point(6, 31);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(138, 46);
			this.SaveButton.TabIndex = 1;
			this.SaveButton.Text = "Zapisz";
			this.SaveButton.UseVisualStyleBackColor = true;
			// 
			// workingArea
			// 
			this.workingArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.workingArea.Location = new System.Drawing.Point(3, 3);
			this.workingArea.Name = "workingArea";
			this.workingArea.Size = new System.Drawing.Size(621, 555);
			this.workingArea.TabIndex = 1;
			this.workingArea.TabStop = false;
			this.workingArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.workingArea_MouseDown);
			this.workingArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.workingArea_MouseMove);
			this.workingArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.workingArea_MouseUp);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.LanguageBox.ResumeLayout(false);
			this.EditionBox.ResumeLayout(false);
			this.EditionBox.PerformLayout();
			this.ImportBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.workingArea)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.GroupBox LanguageBox;
		private System.Windows.Forms.GroupBox EditionBox;
		private System.Windows.Forms.GroupBox ImportBox;
		private System.Windows.Forms.PictureBox workingArea;
		private System.Windows.Forms.Button EnglishLanguageButton;
		private System.Windows.Forms.Button PolishLanguageButton;
		private System.Windows.Forms.Button LoadButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button ColorButton;
		private System.Windows.Forms.Label colorField;
		private System.Windows.Forms.Button DeleteButton;
	}
}

