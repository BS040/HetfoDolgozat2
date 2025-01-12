namespace WinFormsApp
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
            btnSorsor = new Button();
            btnClose = new Button();
            panel = new Panel();
            lbl = new Label();
            SuspendLayout();
            // 
            // btnSorsor
            // 
            btnSorsor.Location = new Point(686, 28);
            btnSorsor.Name = "btnSorsor";
            btnSorsor.Size = new Size(75, 23);
            btnSorsor.TabIndex = 1;
            btnSorsor.Text = "Sorsolás";
            btnSorsor.UseVisualStyleBackColor = true;
            btnSorsor.Click += btnSorsor_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(686, 72);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 2;
            btnClose.Text = "Bezár";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // panel
            // 
            panel.Location = new Point(28, 23);
            panel.Name = "panel";
            panel.Size = new Size(200, 100);
            panel.TabIndex = 3;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new Point(689, 128);
            lbl.Name = "lbl";
            lbl.Size = new Size(0, 15);
            lbl.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 661);
            Controls.Add(lbl);
            Controls.Add(panel);
            Controls.Add(btnClose);
            Controls.Add(btnSorsor);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSorsor;
        private Button btnClose;
        private Panel panel;
        private Label lbl;
    }
}
