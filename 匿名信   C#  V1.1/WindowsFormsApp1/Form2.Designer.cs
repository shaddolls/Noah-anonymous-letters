namespace WindowsFormsApp1
{
    partial class Form2
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
            this.textnowlv = new System.Windows.Forms.TextBox();
            this.texttolv = new System.Windows.Forms.TextBox();
            this.texthave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelout = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textnowlv
            // 
            this.textnowlv.Location = new System.Drawing.Point(147, 41);
            this.textnowlv.MaxLength = 3;
            this.textnowlv.Name = "textnowlv";
            this.textnowlv.Size = new System.Drawing.Size(85, 25);
            this.textnowlv.TabIndex = 0;
            this.textnowlv.Text = "1";
            this.textnowlv.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textnowlv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textnowlv_KeyPress);
            // 
            // texttolv
            // 
            this.texttolv.Location = new System.Drawing.Point(147, 148);
            this.texttolv.MaxLength = 3;
            this.texttolv.Name = "texttolv";
            this.texttolv.Size = new System.Drawing.Size(85, 25);
            this.texttolv.TabIndex = 1;
            this.texttolv.Text = "120";
            this.texttolv.TextChanged += new System.EventHandler(this.texttolv_TextChanged);
            this.texttolv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.texttolv_KeyPress);
            // 
            // texthave
            // 
            this.texthave.Location = new System.Drawing.Point(147, 94);
            this.texthave.MaxLength = 3;
            this.texthave.Name = "texthave";
            this.texthave.Size = new System.Drawing.Size(85, 25);
            this.texthave.TabIndex = 2;
            this.texthave.Text = "0";
            this.texthave.TextChanged += new System.EventHandler(this.texthave_TextChanged);
            this.texthave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.texthave_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "现在等级：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "已有经验：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "到达等级：";
            // 
            // labelout
            // 
            this.labelout.AutoSize = true;
            this.labelout.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelout.ForeColor = System.Drawing.Color.Red;
            this.labelout.Location = new System.Drawing.Point(144, 206);
            this.labelout.Name = "labelout";
            this.labelout.Size = new System.Drawing.Size(71, 15);
            this.labelout.TabIndex = 6;
            this.labelout.Text = "25847280";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "需要经验：";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 288);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.texthave);
            this.Controls.Add(this.texttolv);
            this.Controls.Add(this.textnowlv);
            this.MaximumSize = new System.Drawing.Size(305, 335);
            this.MinimumSize = new System.Drawing.Size(305, 335);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计算器";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textnowlv;
        private System.Windows.Forms.TextBox texttolv;
        private System.Windows.Forms.TextBox texthave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelout;
        private System.Windows.Forms.Label label4;
    }
}