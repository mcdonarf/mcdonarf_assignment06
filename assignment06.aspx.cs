/* Hello from Bill */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

            tStoreTableAdapter myTableAdapterStore = new tStoreTableAdapter();
            Store.tStoreDataTable myTableStore = myTableAdapterStore.GetData();
            ddlStore.DataTextField = "Store";
            ddlStore.DataValueField = "StoreID";
            ddlStore.DataSource = myTableStore;
            ddlStore.DataBind();

            tLoyaltyTableAdapter myTableAdapterLoyalty = new tLoyaltyTableAdapter();
            Loyalty.tLoyaltyDataTable myTableLoyalty = myTableAdapterLoyalty.GetData();
            ddlLoyalty.DataTextField = "LoyaltyNumber";
            ddlLoyalty.DataValueField = "LoyaltyID";
            ddlLoyalty.DataSource = myTableLoyalty;
            ddlLoyalty.DataBind();

            tTransactionTypeTableAdapter myTableAdapterTransactionType = new tTransactionTypeTableAdapter();
            TransactionType.tTransactionTypeDataTable myTableTransactionType = myTableAdapterTransactionType.GetData();
            ddlTransactionType.DataTextField = "TransactionType";
            ddlTransactionType.DataValueField = "TransactionTypeID";
            ddlTransactionType.DataSource = myTableTransactionType;
            ddlTransactionType.DataBind();

            tEmplTableAdapter myTableAdapterEmpl = new tEmplTableAdapter();
            Empl.tEmplDataTable myTableEmpl = myTableAdapterEmpl.GetData();
            ddlEmpl.DataTextField = "LastName";
            ddlEmpl.DataValueField = "EmplID";
            ddlEmpl.DataSource = myTableEmpl;
            ddlEmpl.DataBind();

            tProductTableAdapter myTableAdapterProduct = new tProductTableAdapter();
            Product.tProductDataTable myTableProduct = myTableAdapterProduct.GetData();
            lbProduct.DataTextField = "Product_Name";
            lbProduct.DataValueField = "ProductID";
            lbProduct.DataSource = myTableProduct;
            lbProduct.DataBind();

            tCouponDetailTableAdapter myTableAdapterCoupon = new tCouponDetailTableAdapter();
            Coupon.tCouponDetailDataTable myTableCoupon = myTableAdapterCoupon.GetData();
            ddlCoupon.DataTextField = "Coupon";
            ddlCoupon.DataValueField = "CouponDetailID";
            ddlCoupon.DataSource = myTableCoupon;
            ddlCoupon.DataBind();
        }
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = true;

        string constr = ConfigurationManager.ConnectionStrings["GroceryStoreSimulatorConnectionString"].ToString();
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "spAddTransactionAndDetail";
        cmd.Connection = con;

        cmd.Parameters.Add("@DateOfTransaction", SqlDbType.VarChar).Value = txtTransactionDate.Text.Trim();
        cmd.Parameters.Add("@TimeOfTransaction", SqlDbType.VarChar).Value = txtTransactionTime.Text.Trim();
        cmd.Parameters.Add("@TransactionComment", SqlDbType.VarChar).Value = txtComment.Text.Trim();
        cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = txtQtyOfProduct.Text.Trim();
        cmd.Parameters.Add("@PricePerSellableUnitAsMarked", SqlDbType.VarChar).Value = txtPricePerSale.Text.Trim();
        cmd.Parameters.Add("@PricePerSellableUnitToTheCustomer", SqlDbType.VarChar).Value = txtPricePerSaleToCustomer.Text.Trim();
        cmd.Parameters.Add("@TransactionDetailComment", SqlDbType.VarChar).Value = txtTransDetailComment.Text.Trim();
        cmd.Parameters.Add("@LoyaltyID", SqlDbType.Int).Value = ddlLoyalty.SelectedValue;
        cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = ddlStore.SelectedValue;
        cmd.Parameters.Add("@TransactionTypeID", SqlDbType.Int).Value = ddlTransactionType.SelectedValue;
        cmd.Parameters.Add("@EmplID", SqlDbType.Int).Value = ddlEmpl.SelectedValue;
        cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = lbProduct.SelectedValue;
        cmd.Parameters.Add("@couponDetailID", SqlDbType.Int).Value = ddlCoupon.SelectedValue;
        cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = "@@IDENTITY";

        try

        {

            con.Open();

            cmd.ExecuteNonQuery();

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