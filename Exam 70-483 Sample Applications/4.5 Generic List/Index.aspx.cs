using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _4._5_Generic_List
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Product> products = new List<Product>();

            products.Add(new Product() { ProductId = 1, Name = "Mars Bar" });
            products.Add(new Product() { ProductId = 2, Name = "Killer Python" });
            products.Add(new Product() { ProductId = 3, Name = "Gummy Bears" });

            DropDownList1.DataSource = products;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ProductId";
            DropDownList1.DataBind();
        }
    }
}