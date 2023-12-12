using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

namespace flower_stock_monitoring.views.mainPage
{
    public partial class mainPage1 : System.Web.UI.Page
    {
        model.Function Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new model.Function();
            stockId.Visible = false;
            populateStock();
        }

        private void clear()
        {

            flowerType.Value = "";
            quantity.Value = "";
            unitPrice.Value = "";
            categoryDd.Text = "";
        }

        private void populateStock()
        {
            string query = "select Id as Id, flower_type as [Flower Type], quantity as [Quantity], unit_price as [Unit Price], category as [Category] from Stock";
            stockDVG.DataSource = Con.GetData(query);
            stockDVG.DataBind();
        }

        protected void save_Click(object sender, EventArgs e)
        {
            Guid myId = Guid.NewGuid();
            string myIdString = new string(myId.ToString().Where(char.IsDigit).ToArray());
            myIdString = myIdString.Length >= 6 ? myIdString.Substring(0, 6) : myIdString;
            stockId.Text = myIdString;

            if (string.IsNullOrEmpty(stockId.Text))
            {
                errorMsg.InnerText = "Incomplete details";
            }
            else
            {
                string flowertype = flowerType.Value;
                string Quantity = quantity.Value;
                string UnitPrice = unitPrice.Value;
                string Cat = categoryDd.Text;

                string query = "INSERT INTO Stock (Id, flower_type, quantity, unit_price, category) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";

                query = string.Format(query, stockId.Text, flowertype, Quantity, UnitPrice, Cat);
                Con.SetData(query);
                populateStock();
                errorMsg.InnerText = "Added Successfully";
                clear();
            }
        }

        protected void edit_Click(object sender, EventArgs e)
        {

            if (stockId.Text == "")
            {
                errorMsg.InnerText = "select  details";
            }
            else
            {

                string flowertype = flowerType.Value;
                string Quantity = quantity.Value;
                string UnitPrice = unitPrice.Value;
                string Cat = categoryDd.Text;


                string query = "UPDATE Stock SET flower_type = '{0}', quantity = '{1}',unit_price = '{2}',category = '{3}' WHERE Id = '{4}'";
                query = string.Format(query, flowertype, Quantity, UnitPrice, Cat, stockDVG.SelectedRow.Cells[1].Text);
                Con.SetData(query);
                populateStock();
                errorMsg.InnerHtml = "Updated Successfully";
                clear();

            }
        }

        protected void stockDVG_SelectedIndexChanged(object sender, EventArgs e)
        {
            stockId.Text = stockDVG.SelectedRow.Cells[1].Text;
            flowerType.Value = stockDVG.SelectedRow.Cells[2].Text;
            quantity.Value = stockDVG.SelectedRow.Cells[3].Text;
            unitPrice.Value = stockDVG.SelectedRow.Cells[4].Text;
            categoryDd.Text = stockDVG.SelectedRow.Cells[5].Text;
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (stockId.Text == "")
                {
                    errorMsg.InnerText = "select  details";
                }
                else
                {
                    string flowerT = flowerType.Value;
                    string Query = "DELETE FROM Stock WHERE Id = '{0}'";
                    Query = string.Format(Query, stockDVG.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    populateStock();
                    errorMsg.InnerText = "Deleted Successfully";
                    clear();
                }
            }
            catch (Exception Ex)
            {

            }
        }
    }
}
