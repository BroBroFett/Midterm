﻿using System;
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
    public partial class Edit : System.Web.UI.Page
    {
		protected MidtermApp.DefaultConnection _db = new MidtermApp.DefaultConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Update methd to update the selected Course item
        // USAGE: <asp:FormView UpdateMethod="UpdateItem">
        public void UpdateItem(string  CourseID)
        {
            using (_db)
            {
                var item = _db.Courses.Find(CourseID);

                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", CourseID));
                    return;
                }

                TryUpdateModel(item);

                if (ModelState.IsValid)
                {
                    // Save changes here
                    _db.SaveChanges();
                    Response.Redirect("../Default");
                }
            }
        }

        // This is the Select method to selects a single Course item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public MidtermApp.Course GetItem([FriendlyUrlSegmentsAttribute(0)]string CourseID)
        {
            if (CourseID == null)
            {
                return null;
            }

            using (_db)
            {
                return _db.Courses.Find(CourseID);
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
