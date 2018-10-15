using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace Reference_Fixer
{
    public partial class Ribbon
    {
        frmMain mainForm = new frmMain();

        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnOpen_Click(object sender, RibbonControlEventArgs e)
        {
            if (mainForm == null || mainForm.IsDisposed)
                mainForm = new frmMain();           

            mainForm.Show();
            mainForm.TopMost = true;
        }
    }
}
