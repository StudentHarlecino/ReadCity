namespace ReadCity
{
    partial class ListBooks
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
            panel1 = new Panel();
            labelFullName = new Label();
            buttonExit = new Button();
            panel2 = new Panel();
            panelBooks = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(labelFullName);
            panel1.Controls.Add(buttonExit);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(984, 50);
            panel1.TabIndex = 0;
            // 
            // labelFullName
            // 
            labelFullName.Dock = DockStyle.Right;
            labelFullName.Font = new Font("Segoe UI", 12F);
            labelFullName.Location = new Point(648, 0);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(293, 50);
            labelFullName.TabIndex = 0;
            labelFullName.Text = "label1";
            labelFullName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.SteelBlue;
            buttonExit.Dock = DockStyle.Right;
            buttonExit.Font = new Font("Segoe UI", 20F);
            buttonExit.Location = new Point(941, 0);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(43, 50);
            buttonExit.TabIndex = 1;
            buttonExit.Text = "🚪";
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(0, 1011);
            panel2.TabIndex = 1;
            // 
            // panelBooks
            // 
            panelBooks.Dock = DockStyle.Fill;
            panelBooks.Location = new Point(0, 50);
            panelBooks.Name = "panelBooks";
            panelBooks.Size = new Size(984, 1011);
            panelBooks.TabIndex = 2;
            // 
            // ListBooks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(984, 1061);
            Controls.Add(panelBooks);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ListBooks";
            Text = "Просмотр книг";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label labelFullName;
        private Button buttonExit;
        private Panel panel2;
        private Panel panelBooks;
    }
}