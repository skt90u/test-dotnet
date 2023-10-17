using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ReportData
{
    /// <summary>
    /// 用於設定可用資料集
    /// 
    /// https://support.syncfusion.com/kb/article/7919/how-to-create-rdlc-report-using-business-object-data-source
    /// </summary>
    public List<ReportData> Example()
    {
        return new List<ReportData>();
    }

    public int N01 { get; set; }
    public int N02 { get; set; }
    public int N03 { get; set; }
    public int N04 { get; set; }
    public int N05 { get; set; }
    public int N06 { get; set; }
    public int N07 { get; set; }
    public int N08 { get; set; }
    public int N09 { get; set; }
    public int N10 { get; set; }

    public string S01 { get; set; }
    public string S02 { get; set; }
    public string S03 { get; set; }
    public string S04 { get; set; }
    public string S05 { get; set; }
    public string S06 { get; set; }
    public string S07 { get; set; }
    public string S08 { get; set; }
    public string S09 { get; set; }
    public string S10 { get; set; }
}