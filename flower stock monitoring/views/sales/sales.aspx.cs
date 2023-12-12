using System;
using System.Linq;

namespace flower_stock_monitoring.views.sales
{
    public partial class sales1 : System.Web.UI.Page
    {
        model.Function Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new model.Function();
            saleId.Visible = false;

            if (!IsPostBack)
            {
             
                populateSale();
            }
        }

        private void clear()
        {
            customerName.Value = "";
            address.Value = "";
        
            price.Value = "";
            quantity.Value = "";
        }

        private void populateSale()
        {
            string query = "select Id as Id, customer_name as [Customer Name],  address as [Address], price as [Price], quantity as [Quantity], flower_order as [Order] from Sale";

            saleDVG.DataSource = Con.GetData(query);
            saleDVG.DataBind();
        }



        protected void addOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(customerName.Value) || string.IsNullOrEmpty(address.Value) || string.IsNullOrEmpty(order.Text) || string.IsNullOrEmpty(price.Value) || string.IsNullOrEmpty(quantity.Value))
            {
                errorMsg.InnerText = "Incomplete details";
                return;
            }

            Guid myId = Guid.NewGuid();
            string myIdString = new string(myId.ToString().Where(char.IsDigit).ToArray());
            myIdString = myIdString.Length >= 6 ? myIdString.Substring(0, 6) : myIdString;
            saleId.Text = myIdString;

            string customername = customerName.Value;
            string addrs = address.Value;
            string ord = order.Text;
            string prc = price.Value;
            string qty = quantity.Value;

            // Specify the columns in the INSERT INTO statement
            string query = "INSERT INTO Sale (Id, customer_name, address,  price, quantity, flower_order) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}','{5}')";

            query = string.Format(query, saleId.Text, customername, addrs, prc, qty, ord);

            Con.SetData(query);
            errorMsg.InnerText = "Added Successfully";
            populateSale();
            clear();
        }

        protected void saleDVG_SelectedIndexChanged(object sender, EventArgs e)
        {
            saleId.Text = saleDVG.SelectedRow.Cells[1].Text;
            customerName.Value = saleDVG.SelectedRow.Cells[2].Text;
            address.Value = saleDVG.SelectedRow.Cells[3].Text;
        
 
            price.Value = saleDVG.SelectedRow.Cells[4].Text;
            quantity.Value = saleDVG.SelectedRow.Cells[5].Text;
            order.Text = saleDVG.SelectedRow.Cells[6].Text;
        }

        protected void cancelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (saleId.Text == "")
                {
                    errorMsg.InnerText = "select  details";
                }
                else
                {
            
                    string Query = "DELETE FROM Sale WHERE Id = '{0}'";
                    Query = string.Format(Query, saleDVG.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    populateSale();
                    errorMsg.InnerText = "Order Cancelled";
                    clear();
                }
            }
            catch (Exception Ex)
            {

            }
        }
    }
}
