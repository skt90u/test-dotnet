using Microsoft.Reporting.WebForms;
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
                //ReportViewer1.LocalReport.SetParameters(new List<ReportParameter> { 
                //    new ReportParameter(name: "ReportParameter1", value: "SSS")
                //});

                var details = new List<ReportData>();

                for(var i=0; i<10; i++)
                {
                    var detail = new ReportData {
                        N01 = i + 1,
                        N02 = i + 2,
                        N03 = i + 3,
                        N04 = i + 4,
                        N05 = i + 5,
                        N06 = i + 6,
                        N07 = i + 7,
                        N08 = i + 8,
                        N09 = i + 9,
                        N10 = i + 10,
                        S01 = (i + 1).ToString(),
                        S02 = (i + 2).ToString(),
                        S03 = (i + 3).ToString(),
                        S04 = (i + 4).ToString(),
                        S05 = (i + 5).ToString(),
                        S06 = (i + 6).ToString(),
                        S07 = (i + 7).ToString(),
                        S08 = (i + 8).ToString(),
                        S09 = (i + 9).ToString(),
                        S10 = (i + 10).ToString(),
                    };

                    details.Add(detail);
                }
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Details", details));

                //ReportViewer1.LocalReport.Refresh();
            }
            
        }
    }
}