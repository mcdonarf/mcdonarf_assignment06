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

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
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
            }
        }
    }