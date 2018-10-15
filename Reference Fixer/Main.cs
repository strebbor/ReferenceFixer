using Microsoft.Office.Interop.Word;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reference_Fixer
{
    public partial class frmMain : Form
    {
        Methods m = new Methods();
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedText;
            selectedText = Globals.ThisAddIn.Application.Selection.Text;
            txtSelectedText.Text = selectedText;
          
            txtInlineExample.Text = m.GenerateExampleInlineString(selectedText);
            txtEndExample.Text = m.GenerateExampleEndString(selectedText);
        }

        private void btnApplyInline_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.Application.Selection.Text = txtInlineExample.Text;
        }

        private void btnApplyEnd_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.Application.Selection.Text = txtEndExample.Text;
        }
    }
}
