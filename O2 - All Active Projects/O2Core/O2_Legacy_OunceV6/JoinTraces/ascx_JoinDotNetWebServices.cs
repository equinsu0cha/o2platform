﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using O2.DotNetWrappers.DotNet;
using O2.DotNetWrappers.Windows;

namespace O2.Legacy.OunceV6.JoinTraces
{
    public partial class ascx_JoinDotNetWebServices : UserControl
    {
        public ascx_JoinDotNetWebServices()
        {
            InitializeComponent();
        }

        private void lbTargetSavedAssessmentFiles_DragEnter(object sender, DragEventArgs e)
        {
            Dnd.setEffect(e);  
        }

        private void lbTargetSavedAssessmentFiles_DragDrop(object sender, DragEventArgs e)
        {
            handleDrop(Dnd.tryToGetFileOrDirectoryFromDroppedObject(e));
        }

        private void btCreateTraces_Click(object sender, EventArgs e)
        {
            createAllTracesAfterDotNetWebServicesMapping();
        }

        
    }
}
