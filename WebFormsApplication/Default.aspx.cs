using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using System.Data.OracleClient;
using System.Data;
using System.Net;
using System.Text;

namespace WebFormsApplication
{
    public partial class _Default : Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            //new GlobalTemplate().Render(System.IO.Path.Combine(MapPath("~/"), "globaltemplate.master"));
              
            MasterPageFile = MasterPageVirtualPathProvider.MasterPageFileLocation;
            //MasterPageFile = "~/globaltemplate.master";
            base.OnPreInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var cmd = new OracleCommand();
            cmd.CommandText = "select global_dept_name from hart_global_depts_mv";
            var set = Database.GetData(cmd, "dbdev2.hscnet.hsc.usf.edu", "1522", "dbdev", "hsc", "graham_hill");

            foreach (System.Data.DataRow rItem in set.Tables[0].Rows)
            {
                this.Div1.InnerHtml  += rItem["global_dept_name"].ToString() +"<br/>";
            }
        }
        
    }
}