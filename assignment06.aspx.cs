/* Hello from Bill */
/****************************************************************************************************************
 * Richard McDonald and Tom Martin
 * mcdonarf@mail.uc.edu & marti2t5@mail.uc.edu
 * Due: 03/01/2017
 * Professor: Bill Nicholson
 * Tutuor: Justin Meyer
 * This program loads a series of tables from the tables associated with the database the data on the webpage is being added to and uses a stored procedure to add the data to the corresponding tables within the database.
 * *************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Add table adapters to the tables being used.
using StoreTableAdapters;
using LoyaltyTableAdapters;
using TransactionTypeTableAdapters;
using EmplTableAdapters;
using ProductTableAdapters;
using CouponTableAdapters;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            lblMessage.Visible = false;
            //Load the data from the Store table and load it into the asscociated drop down list.
            tStoreTableAdapter myTableAdapterStore = new tStoreTableAdapter();
            Store.tStoreDataTable myTableStore = myTableAdapterStore.GetData();
            ddlStore.DataTextField = "Store";
            ddlStore.DataValueField = "StoreID";
            ddlStore.DataSource = myTableStore;
            ddlStore.DataBind();
            //Load the data from the Loyalty Number table and load it into the asscociated drop down list.
            tLoyaltyTableAdapter myTableAdapterLoyalty = new tLoyaltyTableAdapter();
            Loyalty.tLoyaltyDataTable myTableLoyalty = myTableAdapterLoyalty.GetData();
            ddlLoyalty.DataTextField = "LoyaltyNumber";
            ddlLoyalty.DataValueField = "LoyaltyID";
            ddlLoyalty.DataSource = myTableLoyalty;
            ddlLoyalty.DataBind();
            //Load the data from the Transaction Type table and load it into the asscociated drop down list.
            tTransactionTypeTableAdapter myTableAdapterTransactionType = new tTransactionTypeTableAdapter();
            TransactionType.tTransactionTypeDataTable myTableTransactionType = myTableAdapterTransactionType.GetData();
            ddlTransactionType.DataTextField = "TransactionType";
            ddlTransactionType.DataValueField = "TransactionTypeID";
            ddlTransactionType.DataSource = myTableTransactionType;
            ddlTransactionType.DataBind();
            //Load the data from the Employee table and load it into the asscociated drop down list.
            tEmplTableAdapter myTableAdapterEmpl = new tEmplTableAdapter();
            Empl.tEmplDataTable myTableEmpl = myTableAdapterEmpl.GetData();
            ddlEmpl.DataTextField = "LastName";
            ddlEmpl.DataValueField = "EmplID";
            ddlEmpl.DataSource = myTableEmpl;
            ddlEmpl.DataBind();
            //Load the data from the Product and Name tables and load it into the asscociated list box.
            tProductTableAdapter myTableAdapterProduct = new tProductTableAdapter();
            Product.tProductDataTable myTableProduct = myTableAdapterProduct.GetData();
            lbProduct.DataTextField = "Product_Name";
            lbProduct.DataValueField = "ProductID";
            lbProduct.DataSource = myTableProduct;
            lbProduct.DataBind();

            /*tCouponDetailTableAdapter myTableAdapterCoupon = new tCouponDetailTableAdapter();
            Coupon.tCouponDetailDataTable myTableCoupon = myTableAdapterCoupon.GetData();
            ddlCoupon.DataTextField = "Coupon";
            ddlCoupon.DataValueField = "CouponDetailID";
            ddlCoupon.DataSource = myTableCoupon;
            ddlCoupon.DataBind();*/
        }
    }
    //Upon clicking the insert button insert all of the entered data into the database using the stored procedure in the database
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = true;
        //Connect to the database.
        string constr = ConfigurationManager.ConnectionStrings["GroceryStoreSimulatorConnectionString"].ToString();
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "spAddTransactionAndDetail";
        cmd.Connection = con;
        //Create parameters that take the entered data and assign it to a certain value within the stored procedure.
        cmd.Parameters.Add("@DateOfTransaction", SqlDbType.Date).Value = txtTransactionDate.Text;
        cmd.Parameters.Add("@TimeOfTransaction", SqlDbType.Time).Value = txtTransactionTime.Text;
        cmd.Parameters.Add("@TransactionComment", SqlDbType.NVarChar).Value = txtComment.Text;
        cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = Convert.ToInt32(txtQtyOfProduct.Text);
        cmd.Parameters.Add("@PricePerSellableUnitAsMarked", SqlDbType.Money).Value = Convert.ToDecimal(txtPricePerSale.Text);
        cmd.Parameters.Add("@PricePerSellableUnitToTheCustomer", SqlDbType.Money).Value = Convert.ToDecimal(txtPricePerSaleToCustomer.Text);
        cmd.Parameters.Add("@TransactionDetailComment", SqlDbType.NVarChar).Value = txtTransDetailComment.Text;
        cmd.Parameters.Add("@LoyaltyID", SqlDbType.Int).Value = ddlLoyalty.SelectedValue;
        cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = ddlStore.SelectedValue;
        cmd.Parameters.Add("@TransactionTypeID", SqlDbType.Int).Value = ddlTransactionType.SelectedValue;
        cmd.Parameters.Add("@EmplID", SqlDbType.Int).Value = ddlEmpl.SelectedValue;
        cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = lbProduct.SelectedValue;
        cmd.Parameters.Add("@couponDetailID", SqlDbType.Int).Value = 0;
        cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = 1;

        try

        {

            con.Open();

            cmd.ExecuteNonQuery();
            //Return message to the user that the records were succesfully inserted.
            lblMessage.Text = "Record inserted successfully";

        }

        catch (Exception ex)

        {

            throw ex;

        }

        finally

        {

            con.Close();

            con.Dispose();

        }

    }
}