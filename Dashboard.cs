using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace RTS
{
    public partial class Dashboard : Telerik.WinControls.UI.RadForm
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void setup_menu_Click(object sender, EventArgs e)
        {
            AddRequest obj = new AddRequest();
            obj.Show();
        }

        private void complaintStatus_menu_Click(object sender, EventArgs e)
        {
            RTS_Status obj = new RTS_Status();
            obj.Show();
        }

       
    }
}
