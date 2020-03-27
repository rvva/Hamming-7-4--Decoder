namespace HammingCode
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelG_X = new System.Windows.Forms.Label();
            this.comboBoxG_X = new System.Windows.Forms.ComboBox();
            this.labelY_n = new System.Windows.Forms.Label();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.maskedTextBoxYn = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // labelG_X
            // 
            this.labelG_X.AutoSize = true;
            this.labelG_X.Location = new System.Drawing.Point(26, 58);
            this.labelG_X.Name = "labelG_X";
            this.labelG_X.Size = new System.Drawing.Size(40, 13);
            this.labelG_X.TabIndex = 0;
            this.labelG_X.Text = "G(X) = ";
            // 
            // comboBoxG_X
            // 
            this.comboBoxG_X.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxG_X.FormattingEnabled = true;
            this.comboBoxG_X.IntegralHeight = false;
            this.comboBoxG_X.Items.AddRange(new object[] {
            "x³+x+1",
            "x³+x²+1"});
            this.comboBoxG_X.Location = new System.Drawing.Point(72, 51);
            this.comboBoxG_X.Name = "comboBoxG_X";
            this.comboBoxG_X.Size = new System.Drawing.Size(165, 29);
            this.comboBoxG_X.TabIndex = 1;
            this.comboBoxG_X.TabStop = false;
            // 
            // labelY_n
            // 
            this.labelY_n.AutoSize = true;
            this.labelY_n.Location = new System.Drawing.Point(34, 23);
            this.labelY_n.Name = "labelY_n";
            this.labelY_n.Size = new System.Drawing.Size(32, 13);
            this.labelY_n.TabIndex = 3;
            this.labelY_n.Text = "Yn = ";
            // 
            // buttonDecode
            // 
            this.buttonDecode.Enabled = false;
            this.buttonDecode.Location = new System.Drawing.Point(331, 16);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(82, 64);
            this.buttonDecode.TabIndex = 4;
            this.buttonDecode.Text = "Dekoduj";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(13, 98);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(421, 380);
            this.richTextBoxLog.TabIndex = 5;
            this.richTextBoxLog.Text = "";
            // 
            // maskedTextBoxYn
            // 
            this.maskedTextBoxYn.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxYn.Location = new System.Drawing.Point(72, 16);
            this.maskedTextBoxYn.Mask = "0000000";
            this.maskedTextBoxYn.Name = "maskedTextBoxYn";
            this.maskedTextBoxYn.Size = new System.Drawing.Size(165, 28);
            this.maskedTextBoxYn.TabIndex = 6;
            this.maskedTextBoxYn.TextChanged += new System.EventHandler(this.maskedTextBoxYn_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 490);
            this.Controls.Add(this.maskedTextBoxYn);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.buttonDecode);
            this.Controls.Add(this.labelY_n);
            this.Controls.Add(this.comboBoxG_X);
            this.Controls.Add(this.labelG_X);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Hamming (7, 4) Dekoder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelG_X;
        private System.Windows.Forms.ComboBox comboBoxG_X;
        private System.Windows.Forms.Label labelY_n;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxYn;
    }
}

