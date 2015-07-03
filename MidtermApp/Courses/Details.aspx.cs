using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using MidtermApp;

namespace MidtermApp.Courses
{
    public partial class Details : System.Web.UI.Page
    {
		protected MidtermApp.DefaultConnection _db = new MidtermApp.DefaultConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Select methd to selects a single Course item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public MidtermApp.Course GetItem([FriendlyUrlSegmentsAttribute(0)]string CourseID)
        {
            if (CourseID == null)
            {
                return null;
            }

            using (_db)
            {
	            return _db.Courses.Where(m => m.CourseID == CourseID).FirstOrDefault();
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Default");
            }
        }
    }
}

