// This file is part of the OWASP O2 Platform (http://www.owasp.org/index.php/OWASP_O2_Platform) and is released under the Apache 2.0 License (http://www.apache.org/licenses/LICENSE-2.0)
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace O2.Core.CIR.Ascx
{
    public partial class ascx_FindingsSplitter : UserControl
    {
        public ascx_FindingsSplitter()
        {
            InitializeComponent();
        }

        private void ascx_FindingsSplitter_Load(object sender, EventArgs e)
        {
            onLoad();
        }

       
    }
}
