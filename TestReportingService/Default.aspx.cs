﻿using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestReportingService
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.LocalReport.SetParameters(new List<ReportParameter> { 
                    new ReportParameter(name: "ReportParameter1", value: "SSS")
                });
                ReportViewer1.LocalReport.Refresh();
            }
            
        }
    }
}