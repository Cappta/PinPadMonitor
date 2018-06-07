namespace PinPadMonitor
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.UxTreeView = new System.Windows.Forms.TreeView();
			this.UxMenuPanel = new System.Windows.Forms.Panel();
			this.UxButtonImport = new System.Windows.Forms.Button();
			this.UxButtonExport = new System.Windows.Forms.Button();
			this.UxButtonReset = new System.Windows.Forms.Button();
			this.UxButtonStart = new System.Windows.Forms.Button();
			this.UxComboRealCom = new System.Windows.Forms.ComboBox();
			this.UxLabelRealCom = new System.Windows.Forms.Label();
			this.UxLabelVirtualCom = new System.Windows.Forms.Label();
			this.UxComboVirtualCom = new System.Windows.Forms.ComboBox();
			this.UxComUpdateTimer = new System.Windows.Forms.Timer(this.components);
			this.UxRequestPanel = new System.Windows.Forms.Panel();
			this.UxTestBoxManualRequest = new System.Windows.Forms.TextBox();
			this.UxButtonRequest = new System.Windows.Forms.Button();
			this.UxMenuPanel.SuspendLayout();
			this.UxRequestPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// UxTreeView
			// 
			this.UxTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.UxTreeView.Location = new System.Drawing.Point(0, 62);
			this.UxTreeView.Name = "UxTreeView";
			this.UxTreeView.Size = new System.Drawing.Size(520, 221);
			this.UxTreeView.TabIndex = 0;
			// 
			// UxMenuPanel
			// 
			this.UxMenuPanel.Controls.Add(this.UxButtonImport);
			this.UxMenuPanel.Controls.Add(this.UxButtonExport);
			this.UxMenuPanel.Controls.Add(this.UxButtonReset);
			this.UxMenuPanel.Controls.Add(this.UxButtonStart);
			this.UxMenuPanel.Controls.Add(this.UxComboRealCom);
			this.UxMenuPanel.Controls.Add(this.UxLabelRealCom);
			this.UxMenuPanel.Controls.Add(this.UxLabelVirtualCom);
			this.UxMenuPanel.Controls.Add(this.UxComboVirtualCom);
			this.UxMenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.UxMenuPanel.Location = new System.Drawing.Point(0, 0);
			this.UxMenuPanel.Name = "UxMenuPanel";
			this.UxMenuPanel.Size = new System.Drawing.Size(520, 62);
			this.UxMenuPanel.TabIndex = 1;
			// 
			// UxButtonImport
			// 
			this.UxButtonImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UxButtonImport.Location = new System.Drawing.Point(434, 12);
			this.UxButtonImport.Name = "UxButtonImport";
			this.UxButtonImport.Size = new System.Drawing.Size(80, 39);
			this.UxButtonImport.TabIndex = 14;
			this.UxButtonImport.Text = "IMPORT";
			this.UxButtonImport.UseVisualStyleBackColor = true;
			this.UxButtonImport.Click += new System.EventHandler(this.UxButtonImport_Click);
			// 
			// UxButtonExport
			// 
			this.UxButtonExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UxButtonExport.Location = new System.Drawing.Point(348, 12);
			this.UxButtonExport.Name = "UxButtonExport";
			this.UxButtonExport.Size = new System.Drawing.Size(80, 39);
			this.UxButtonExport.TabIndex = 13;
			this.UxButtonExport.Text = "EXPORT";
			this.UxButtonExport.UseVisualStyleBackColor = true;
			this.UxButtonExport.Click += new System.EventHandler(this.UxButtonExport_Click);
			// 
			// UxButtonReset
			// 
			this.UxButtonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UxButtonReset.Location = new System.Drawing.Point(262, 12);
			this.UxButtonReset.Name = "UxButtonReset";
			this.UxButtonReset.Size = new System.Drawing.Size(80, 39);
			this.UxButtonReset.TabIndex = 12;
			this.UxButtonReset.Text = "RESET";
			this.UxButtonReset.UseVisualStyleBackColor = true;
			this.UxButtonReset.Click += new System.EventHandler(this.UxButtonReset_Click);
			// 
			// UxButtonStart
			// 
			this.UxButtonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UxButtonStart.Location = new System.Drawing.Point(176, 12);
			this.UxButtonStart.Name = "UxButtonStart";
			this.UxButtonStart.Size = new System.Drawing.Size(80, 39);
			this.UxButtonStart.TabIndex = 9;
			this.UxButtonStart.Text = "START";
			this.UxButtonStart.UseVisualStyleBackColor = true;
			this.UxButtonStart.Click += new System.EventHandler(this.UxButtonStart_Click);
			// 
			// UxComboRealCom
			// 
			this.UxComboRealCom.FormattingEnabled = true;
			this.UxComboRealCom.Location = new System.Drawing.Point(94, 25);
			this.UxComboRealCom.Name = "UxComboRealCom";
			this.UxComboRealCom.Size = new System.Drawing.Size(76, 21);
			this.UxComboRealCom.TabIndex = 8;
			// 
			// UxLabelRealCom
			// 
			this.UxLabelRealCom.AutoSize = true;
			this.UxLabelRealCom.Location = new System.Drawing.Point(94, 9);
			this.UxLabelRealCom.Name = "UxLabelRealCom";
			this.UxLabelRealCom.Size = new System.Drawing.Size(69, 13);
			this.UxLabelRealCom.TabIndex = 7;
			this.UxLabelRealCom.Text = "PinPad Real:";
			// 
			// UxLabelVirtualCom
			// 
			this.UxLabelVirtualCom.AutoSize = true;
			this.UxLabelVirtualCom.Location = new System.Drawing.Point(12, 9);
			this.UxLabelVirtualCom.Name = "UxLabelVirtualCom";
			this.UxLabelVirtualCom.Size = new System.Drawing.Size(76, 13);
			this.UxLabelVirtualCom.TabIndex = 6;
			this.UxLabelVirtualCom.Text = "PinPad Virtual:";
			// 
			// UxComboVirtualCom
			// 
			this.UxComboVirtualCom.FormattingEnabled = true;
			this.UxComboVirtualCom.Location = new System.Drawing.Point(12, 25);
			this.UxComboVirtualCom.Name = "UxComboVirtualCom";
			this.UxComboVirtualCom.Size = new System.Drawing.Size(76, 21);
			this.UxComboVirtualCom.TabIndex = 5;
			// 
			// UxComUpdateTimer
			// 
			this.UxComUpdateTimer.Enabled = true;
			this.UxComUpdateTimer.Interval = 1000;
			this.UxComUpdateTimer.Tick += new System.EventHandler(this.UxComUpdateTimer_Tick);
			// 
			// UxRequestPanel
			// 
			this.UxRequestPanel.Controls.Add(this.UxTestBoxManualRequest);
			this.UxRequestPanel.Controls.Add(this.UxButtonRequest);
			this.UxRequestPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.UxRequestPanel.Location = new System.Drawing.Point(0, 283);
			this.UxRequestPanel.Name = "UxRequestPanel";
			this.UxRequestPanel.Size = new System.Drawing.Size(520, 48);
			this.UxRequestPanel.TabIndex = 2;
			// 
			// UxTestBoxManualRequest
			// 
			this.UxTestBoxManualRequest.Dock = System.Windows.Forms.DockStyle.Fill;
			this.UxTestBoxManualRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UxTestBoxManualRequest.Location = new System.Drawing.Point(98, 0);
			this.UxTestBoxManualRequest.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.UxTestBoxManualRequest.Multiline = true;
			this.UxTestBoxManualRequest.Name = "UxTestBoxManualRequest";
			this.UxTestBoxManualRequest.Size = new System.Drawing.Size(422, 48);
			this.UxTestBoxManualRequest.TabIndex = 0;
			// 
			// UxButtonRequest
			// 
			this.UxButtonRequest.Dock = System.Windows.Forms.DockStyle.Left;
			this.UxButtonRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UxButtonRequest.Location = new System.Drawing.Point(0, 0);
			this.UxButtonRequest.Name = "UxButtonRequest";
			this.UxButtonRequest.Size = new System.Drawing.Size(98, 48);
			this.UxButtonRequest.TabIndex = 10;
			this.UxButtonRequest.Text = "REQUEST";
			this.UxButtonRequest.UseVisualStyleBackColor = true;
			this.UxButtonRequest.Click += new System.EventHandler(this.UxButtonRequest_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(520, 331);
			this.Controls.Add(this.UxTreeView);
			this.Controls.Add(this.UxRequestPanel);
			this.Controls.Add(this.UxMenuPanel);
			this.MinimumSize = new System.Drawing.Size(370, 370);
			this.Name = "MainForm";
			this.Text = "PinPad Monitor";
			this.UxMenuPanel.ResumeLayout(false);
			this.UxMenuPanel.PerformLayout();
			this.UxRequestPanel.ResumeLayout(false);
			this.UxRequestPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView UxTreeView;
		private System.Windows.Forms.Panel UxMenuPanel;
		private System.Windows.Forms.Button UxButtonReset;
		private System.Windows.Forms.Button UxButtonStart;
		private System.Windows.Forms.ComboBox UxComboRealCom;
		private System.Windows.Forms.Label UxLabelRealCom;
		private System.Windows.Forms.Label UxLabelVirtualCom;
		private System.Windows.Forms.ComboBox UxComboVirtualCom;
		private System.Windows.Forms.Timer UxComUpdateTimer;
		private System.Windows.Forms.Button UxButtonExport;
		private System.Windows.Forms.Button UxButtonImport;
		private System.Windows.Forms.Panel UxRequestPanel;
		private System.Windows.Forms.TextBox UxTestBoxManualRequest;
		private System.Windows.Forms.Button UxButtonRequest;
	}
}

