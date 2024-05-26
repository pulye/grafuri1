namespace grafuri
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
            panelGrafic = new Panel();
            btnIncarcaGraf = new Button();
            SuspendLayout();
            // 
            // panelGrafic
            // 
            panelGrafic.Location = new Point(26, 17);
            panelGrafic.Name = "panelGrafic";
            panelGrafic.Size = new Size(991, 758);
            panelGrafic.TabIndex = 0;
            panelGrafic.Paint += panelGrafic_Paint;
            // 
            // btnIncarcaGraf
            // 
            btnIncarcaGraf.Location = new Point(1081, 369);
            btnIncarcaGraf.Name = "btnIncarcaGraf";
            btnIncarcaGraf.Size = new Size(94, 29);
            btnIncarcaGraf.TabIndex = 1;
            btnIncarcaGraf.Text = "INCARCA";
            btnIncarcaGraf.UseVisualStyleBackColor = true;
            btnIncarcaGraf.Click += btnIncarcaGraf_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 787);
            Controls.Add(btnIncarcaGraf);
            Controls.Add(panelGrafic);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Panel panelGrafic;
        private Button btnIncarcaGraf;
    }
}
