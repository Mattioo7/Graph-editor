
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.LanguageBox = new System.Windows.Forms.GroupBox();
			this.EnglishLanguageButton = new System.Windows.Forms.Button();
			this.PolishLanguageButton = new System.Windows.Forms.Button();
			this.EditionBox = new System.Windows.Forms.GroupBox();
			this.ClearButton = new System.Windows.Forms.Button();
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
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.workingArea, 0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// tableLayoutPanel2
			// 
			resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
			this.tableLayoutPanel2.Controls.Add(this.LanguageBox, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.EditionBox, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.ImportBox, 0, 2);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			// 
			// LanguageBox
			// 
			this.LanguageBox.Controls.Add(this.EnglishLanguageButton);
			this.LanguageBox.Controls.Add(this.PolishLanguageButton);
			resources.ApplyResources(this.LanguageBox, "LanguageBox");
			this.LanguageBox.Name = "LanguageBox";
			this.LanguageBox.TabStop = false;
			// 
			// EnglishLanguageButton
			// 
			resources.ApplyResources(this.EnglishLanguageButton, "EnglishLanguageButton");
			this.EnglishLanguageButton.Name = "EnglishLanguageButton";
			this.EnglishLanguageButton.UseVisualStyleBackColor = true;
			this.EnglishLanguageButton.Click += new System.EventHandler(this.EnglishLanguageButton_Click);
			// 
			// PolishLanguageButton
			// 
			resources.ApplyResources(this.PolishLanguageButton, "PolishLanguageButton");
			this.PolishLanguageButton.Name = "PolishLanguageButton";
			this.PolishLanguageButton.UseVisualStyleBackColor = true;
			this.PolishLanguageButton.Click += new System.EventHandler(this.PolishLanguageButton_Click);
			// 
			// EditionBox
			// 
			this.EditionBox.Controls.Add(this.ClearButton);
			this.EditionBox.Controls.Add(this.DeleteButton);
			this.EditionBox.Controls.Add(this.colorField);
			this.EditionBox.Controls.Add(this.ColorButton);
			resources.ApplyResources(this.EditionBox, "EditionBox");
			this.EditionBox.Name = "EditionBox";
			this.EditionBox.TabStop = false;
			// 
			// ClearButton
			// 
			resources.ApplyResources(this.ClearButton, "ClearButton");
			this.ClearButton.Name = "ClearButton";
			this.ClearButton.UseVisualStyleBackColor = true;
			this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
			// 
			// DeleteButton
			// 
			resources.ApplyResources(this.DeleteButton, "DeleteButton");
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.UseVisualStyleBackColor = true;
			this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// colorField
			// 
			resources.ApplyResources(this.colorField, "colorField");
			this.colorField.Name = "colorField";
			// 
			// ColorButton
			// 
			resources.ApplyResources(this.ColorButton, "ColorButton");
			this.ColorButton.Name = "ColorButton";
			this.ColorButton.UseVisualStyleBackColor = true;
			this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
			// 
			// ImportBox
			// 
			this.ImportBox.Controls.Add(this.LoadButton);
			this.ImportBox.Controls.Add(this.SaveButton);
			resources.ApplyResources(this.ImportBox, "ImportBox");
			this.ImportBox.Name = "ImportBox";
			this.ImportBox.TabStop = false;
			// 
			// LoadButton
			// 
			resources.ApplyResources(this.LoadButton, "LoadButton");
			this.LoadButton.Name = "LoadButton";
			this.LoadButton.UseVisualStyleBackColor = true;
			this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
			// 
			// SaveButton
			// 
			resources.ApplyResources(this.SaveButton, "SaveButton");
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// workingArea
			// 
			resources.ApplyResources(this.workingArea, "workingArea");
			this.workingArea.Cursor = System.Windows.Forms.Cursors.Cross;
			this.workingArea.Name = "workingArea";
			this.workingArea.TabStop = false;
			this.workingArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.workingArea_MouseDown);
			this.workingArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.workingArea_MouseMove);
			this.workingArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.workingArea_MouseUp);
			// 
			// Form1
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.KeyPreview = true;
			this.Name = "Form1";
			this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
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
		private System.Windows.Forms.Button ClearButton;
	}
}

