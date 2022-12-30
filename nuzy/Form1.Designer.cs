namespace nuzy
{
    partial class Form1
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.configCB = new Guna.UI2.WinForms.Guna2GroupBox();
            this.aimCB = new Guna.UI2.WinForms.Guna2GroupBox();
            this.visualCB = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2DragControl3 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.aim1 = new nuzy.aim();
            this.visual1 = new nuzy.visual();
            this.settings1 = new nuzy.settings();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.guna2Panel1.Controls.Add(this.guna2ControlBox2);
            this.guna2Panel1.Controls.Add(this.guna2ControlBox1);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(540, 27);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.HoverState.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.HoverState.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(187)))), ((int)(((byte)(133)))));
            this.guna2ControlBox2.Location = new System.Drawing.Point(492, 3);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.PressedColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.ShadowDecoration.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.Size = new System.Drawing.Size(20, 21);
            this.guna2ControlBox2.TabIndex = 3;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(187)))), ((int)(((byte)(133)))));
            this.guna2ControlBox1.Location = new System.Drawing.Point(514, 3);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.PressedColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(20, 21);
            this.guna2ControlBox1.TabIndex = 2;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(40, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "CLIENT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(187)))), ((int)(((byte)(133)))));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "HERB";
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this;
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.TargetControl = this.guna2Panel1;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.guna2Panel2.Controls.Add(this.configCB);
            this.guna2Panel2.Controls.Add(this.aimCB);
            this.guna2Panel2.Controls.Add(this.visualCB);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 27);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(74, 313);
            this.guna2Panel2.TabIndex = 4;
            // 
            // configCB
            // 
            this.configCB.BorderThickness = 0;
            this.configCB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.configCB.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.configCB.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.configCB.FillColor = System.Drawing.Color.Transparent;
            this.configCB.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.configCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.configCB.Location = new System.Drawing.Point(11, 185);
            this.configCB.Name = "configCB";
            this.configCB.ShadowDecoration.Parent = this.configCB;
            this.configCB.Size = new System.Drawing.Size(54, 45);
            this.configCB.TabIndex = 37;
            this.configCB.Text = "config";
            this.configCB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.configCB.Click += new System.EventHandler(this.configCB_Click);
            // 
            // aimCB
            // 
            this.aimCB.BorderThickness = 0;
            this.aimCB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aimCB.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(187)))), ((int)(((byte)(133)))));
            this.aimCB.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.aimCB.FillColor = System.Drawing.Color.Transparent;
            this.aimCB.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.aimCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.aimCB.Location = new System.Drawing.Point(10, 83);
            this.aimCB.Name = "aimCB";
            this.aimCB.ShadowDecoration.Parent = this.aimCB;
            this.aimCB.Size = new System.Drawing.Size(54, 45);
            this.aimCB.TabIndex = 37;
            this.aimCB.Text = "aim";
            this.aimCB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.aimCB.Click += new System.EventHandler(this.guna2GroupBox1_Click);
            // 
            // visualCB
            // 
            this.visualCB.BorderThickness = 0;
            this.visualCB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.visualCB.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.visualCB.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.visualCB.FillColor = System.Drawing.Color.Transparent;
            this.visualCB.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.visualCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.visualCB.Location = new System.Drawing.Point(10, 134);
            this.visualCB.Name = "visualCB";
            this.visualCB.ShadowDecoration.Parent = this.visualCB;
            this.visualCB.Size = new System.Drawing.Size(54, 45);
            this.visualCB.TabIndex = 36;
            this.visualCB.Text = "visual";
            this.visualCB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.visualCB.Click += new System.EventHandler(this.visualCB_Click);
            // 
            // guna2DragControl3
            // 
            this.guna2DragControl3.TargetControl = this.guna2Panel2;
            // 
            // aim1
            // 
            this.aim1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.aim1.Location = new System.Drawing.Point(73, 28);
            this.aim1.Name = "aim1";
            this.aim1.Size = new System.Drawing.Size(467, 310);
            this.aim1.TabIndex = 3;
            this.aim1.Load += new System.EventHandler(this.aim1_Load);
            // 
            // visual1
            // 
            this.visual1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.visual1.Location = new System.Drawing.Point(73, 28);
            this.visual1.Name = "visual1";
            this.visual1.Size = new System.Drawing.Size(467, 310);
            this.visual1.TabIndex = 2;
            // 
            // settings1
            // 
            this.settings1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.settings1.Location = new System.Drawing.Point(73, 28);
            this.settings1.Name = "settings1";
            this.settings1.Size = new System.Drawing.Size(467, 310);
            this.settings1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(540, 340);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.aim1);
            this.Controls.Add(this.visual1);
            this.Controls.Add(this.settings1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
        private settings settings1;
        private aim aim1;
        private visual visual1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl3;
        private Guna.UI2.WinForms.Guna2GroupBox visualCB;
        private Guna.UI2.WinForms.Guna2GroupBox aimCB;
        private Guna.UI2.WinForms.Guna2GroupBox configCB;
    }
}

