using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestFormAuth
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var userName = this.tbUserName.Text;
            var password = this.tbPassword.Text;

            if(userName == password)
            {
                var userData = JsonConvert.SerializeObject(new UserInfo {
                    UserName = userName,
                    Password = password,
                });

                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                Response.SuppressFormsAuthenticationRedirect = true;
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(new FormsAuthenticationTicket(
                        version: 1,
                        userName,
                        issueDate: DateTime.Now,
                        expiration: DateTime.Now.AddMinutes(30),
                        isPersistent: false, // 將管理者登入的 Cookie 設定成 Session Cookie
                        userData,
                        FormsAuthentication.FormsCookiePath
                    ))));

                Response.Redirect("~/");
            }
        }

        class UserInfo
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}