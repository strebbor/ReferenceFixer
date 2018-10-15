namespace Reference_Fixer
{
    partial class frmMain
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
            this.btnApplyInline = new System.Windows.Forms.Button();
            this.btnApplyEnd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtInlineExample = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtEndExample = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSelectedText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApplyInline
            // 
            this.btnApplyInline.Location = new System.Drawing.Point(89, 202);
            this.btnApplyInline.Name = "btnApplyInline";
            this.btnApplyInline.Size = new System.Drawing.Size(111, 23);
            this.btnApplyInline.TabIndex = 0;
            this.btnApplyInline.Text = "Apply Inline";
            this.btnApplyInline.UseVisualStyleBackColor = true;
            this.btnApplyInline.Click += new System.EventHandler(this.btnApplyInline_Click);
            // 
            // btnApplyEnd
            // 
            this.btnApplyEnd.Location = new System.Drawing.Point(89, 199);
            this.btnApplyEnd.Name = "btnApplyEnd";
            this.btnApplyEnd.Size = new System.Drawing.Size(111, 23);
            this.btnApplyEnd.TabIndex = 1;
            this.btnApplyEnd.Text = "Apply End";
            this.btnApplyEnd.UseVisualStyleBackColor = true;
            this.btnApplyEnd.Click += new System.EventHandler(this.btnApplyEnd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtInlineExample);
            this.panel1.Controls.Add(this.btnApplyInline);
            this.panel1.Location = new System.Drawing.Point(6, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 225);
            this.panel1.TabIndex = 2;
            // 
            // txtInlineExample
            // 
            this.txtInlineExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInlineExample.Location = new System.Drawing.Point(0, 3);
            this.txtInlineExample.Multiline = true;
            this.txtInlineExample.Name = "txtInlineExample";
            this.txtInlineExample.Size = new System.Drawing.Size(280, 172);
            this.txtInlineExample.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtEndExample);
            this.panel2.Controls.Add(this.btnApplyEnd);
            this.panel2.Location = new System.Drawing.Point(6, 324);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 225);
            this.panel2.TabIndex = 3;
            // 
            // txtEndExample
            // 
            this.txtEndExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndExample.Location = new System.Drawing.Point(0, 3);
            this.txtEndExample.Multiline = true;
            this.txtEndExample.Name = "txtEndExample";
            this.txtEndExample.Size = new System.Drawing.Size(281, 172);
            this.txtEndExample.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 57);
            this.button1.TabIndex = 5;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSelectedText
            // 
            this.txtSelectedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectedText.Location = new System.Drawing.Point(6, 12);
            this.txtSelectedText.Multiline = true;
            this.txtSelectedText.Name = "txtSelectedText";
            this.txtSelectedText.Size = new System.Drawing.Size(200, 57);
            this.txtSelectedText.TabIndex = 6;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 563);
            this.Controls.Add(this.txtSelectedText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmMain";
            this.Text = "Reference Fixer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApplyInline;
        private System.Windows.Forms.Button btnApplyEnd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSelectedText;
        private System.Windows.Forms.TextBox txtInlineExample;
        private System.Windows.Forms.TextBox txtEndExample;
    }
}