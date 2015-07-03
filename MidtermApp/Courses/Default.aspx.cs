using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using MidtermApp;

namespace MidtermApp.Courses
{
    public partial class Default : System.Web.UI.Page
    {
		protected MidtermApp.DefaultConnection _db = new MidtermApp.DefaultConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Model binding method to get List of Course entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<MidtermApp.Course> GetData()
        {
            return _db.Courses;
        }
    }
}

