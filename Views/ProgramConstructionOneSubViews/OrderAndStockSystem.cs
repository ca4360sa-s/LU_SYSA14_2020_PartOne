using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LU_SYSA14_2020_PartOne.Views.ProgramConstructionOneSubViews
{
    public partial class OrderAndStockSystem : Form
    {
        public OrderAndStockSystem()
        {
            InitializeComponent();
        }
        private int OrderIDTempInMemory { set; get; }
        private int CustomerIDTempInMemory { set; get; }

        private static Dictionary<int, int> tempOrderDictonary = new Dictionary<int, int>(); 
        private void BtnBacktoMain_Click(object sender, EventArgs e)
        {
            ModelViews.programConstructionOne.Show();
            this.Hide();
        }
        private void RadioBtnCreatePrivateCustomer_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxPrivateCustomer.Show();
        }
        private void RadioBtnCreateCompanyCustomer_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxPrivateCustomer.Hide();
        }
        private void RadioBtnUpdatePrivateCustomer_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxUpdatePrivateCustomer.Show();
        }
        private void RadioBtnUpdateCompanyCustomer_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxUpdatePrivateCustomer.Hide();
        }
        private void RadioBtnVIAllCompanyCustomers_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxViewUnSpecificCustomer.Show();
        }
        private void RadioBtnVIAllPrivateCostomers_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxViewUnSpecificCustomer.Show();
        }
        private void RadioBtnVIAllCustomers_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxViewUnSpecificCustomer.Show();
        }
        private void RadioBtnVISpecificCustomer_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxViewUnSpecificCustomer.Hide();
        }
        private void DeleteAllCompanyCustomersUnSpecific_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxDeleteCustomerUnspecific.Show();
        }    
        private void radioBtnDeleteAllPrivateCustomersUnSpecific_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxDeleteCustomerUnspecific.Show();
        }
        private void radioBtnDeleteAllCustomersUnSpecific_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxDeleteCustomerUnspecific.Show();
        }
        private void radioBtnDeleteCustomerSpecific_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxDeleteCustomerUnspecific.Hide();
        }
        private void RadioBtnViewproductViewAllProducts_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxViewProductViewAllProducts.Show();
        }
        private void RadioBtnViewproductViewSpecificProduct_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxViewProductViewAllProducts.Hide();
        }
        private void RadioBtnDeleteProductAllProducts_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxDeleteProductAllProducts.Show();
        }
        private void RadioBtnDeleteProductSpecificProduct_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxDeleteProductAllProducts.Hide();
        }
        private void btnCOToStepTwo_Click(object sender, EventArgs e)
        {
            string orderID = textBoxCOGenerateOrderID.Text;
            string tempCustomerID = textBoxCOSubmittCustomerID.Text;
            bool condition = false;
            ClearAllFeedback();
            if (orderID.Length == 0)
            {
                lblCOGenerateOrderIDNF.Text = "Generera orderID";
                lblCOGenerateOrderIDNF.Visible = true; 
                condition = true; 
            }
            if (tempCustomerID.Length == 0)
            {
                lblCOSubmittCustomerIDNF.Text = "Ange befintligt kundID";
                lblCOSubmittCustomerIDNF.Visible = true; ;
                condition = true; 
            }
            if (condition == false)
            {
                if (!Controller.ControllInputIsInteger(tempCustomerID))
                {
                    lblCOSubmittCustomerIDNF.Text = "Ange enbart siffror";
                    lblCOSubmittCustomerIDNF.Visible = true; 
                }
                else
                {
                    int checkedCustomerID = Int32.Parse(tempCustomerID);
                    if (!Controller.CheckIfCustomerIDExist(checkedCustomerID))
                    {
                        lblCOSubmittCustomerIDNF.Text = "KundID:t finns ej";
                        lblCOSubmittCustomerIDNF.Visible = true;
                    }
                    else
                    {
                        OrderIDTempInMemory = Int32.Parse(orderID);
                        CustomerIDTempInMemory = checkedCustomerID;
                        groupBoxCreateOrderStepOne.Hide();
                        lblOngoingOrderIDFeedback.Text = $"OrderID: {orderID}";
                        lblOngoingOrderIDFeedback.Visible = true; 

                    }

                }
            }
        }
        private void btnCOToStepOneCancelOrder_Click(object sender, EventArgs e)
        {
            groupBoxCreateOrderStepOne.Show();
            tempOrderDictonary.Clear();
            ClearAllFeedback();
            dataGridViewCOOngoingOrder.DataSource = null;
            lblOngoingOrderIDFeedback.Visible = false; 
        }
        private void RadioBtnDeleteAllOrders_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxDOUnspecificOrder.Show();
        }
        private void RadioBtnDeleteSpecificOrder_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxDOUnspecificOrder.Hide();
        }
        private void RadioBtnVOVAViewAllOrdersforSpecificCustomer_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxVOVAViewSpecificOrder.Visible = false;
            groupBoxVOVAViewSpecificCustomer.Visible = true;
        }
        private void RadioBtnVOVAViewSpecificOrder_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxVOVAViewSpecificCustomer.Visible = false;
            groupBoxVOVAViewSpecificOrder.Visible = true;

        }
        private void RadioBtnVOVAViewAllOrders_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxVOVAViewSpecificOrder.Visible = false;
            groupBoxVOVAViewSpecificCustomer.Visible = false;
        }

        // -----------------------------------------------------------------------------------------------------
        private void ClearAllFeedback()
        {
            lblSQLEXFeedback.Visible = false;
            // Create Product
            lblCPGenerateProductIDNF.Visible = false;
            lblCPProductNameNF.Visible = false;
            lblCPProductDiscriptionNF.Visible = false;
            lblCPStockQuantityNF.Visible = false;
            lblCPCreateProductPF.Visible = false;
            lblCPCreateProductNF.Visible = false;
            // View Product
            lblViewProductViewAllProductsPF.Visible = false;
            lblViewProductViewAllProductsNF.Visible = false;
            lblViewProductViewSpecificProductPF.Visible = false;
            lblViewProductViewSpecificProductNF.Visible = false;
            // Delete Product
            lblDeleteAllProductsNF.Visible = false;
            lblDeleteAllProductsPF.Visible = false;
            lblDeleteSpecificProductNF.Visible = false;
            lblDeleteSpecificProductPF.Visible = false;
            // Update Product
            lblUPProductIDNF.Visible = false;
            lblUPProductIDPF.Visible = false;
            lblUPProductNameNF.Visible = false;
            lblUPProductNamePF.Visible = false;
            lblUPProductDescriptionNF.Visible = false;
            lblUPProductDescriptionPF.Visible = false;
            lblUPProductStockQuantityNF.Visible = false;
            lblUPProductStockQuantityPF.Visible = false;
            lblUPUpdateProductNF.Visible = false;
            // Create Customer
            lblCPCGeneratePrivateCustomerIDNF.Visible = false;
            lblCPCFirstNameNF.Visible = false;
            lblCPCLastNameNF.Visible = false;
            lblCPCAddressNF.Visible = false;
            lblCPCCreateCustomerPF.Visible = false;
            lblCCCGenerateCompanyCustomerIDNF.Visible = false; 
            lblCCCCompanyNameNF.Visible = false;
            lblCCCCompanyAddressNF.Visible = false;
            lblCCCCreateCustomerPF.Visible = false;
            // View Customer
            lblVCViewUnspecificCustomersPF.Visible = false;
            lblVCViewUnspecificCustomersNF.Visible = false;
            lblVCViewSpecificCustomersNF.Visible = false;
            lblVCViewSpecificCustomersPF.Visible = false;
            // Update Customer
            lblUCCSubmittCustomerIDNF.Visible = false;
            lblUCCCompanyNamePF.Visible = false;
            lblUCCCompanyAddressPF.Visible = false;
            lblUCCUpdateCompanyCustomerNF.Visible = false;
            lblUPCSubmittCustomerIDNF.Visible = false;
            lblUPCFirstNamePF.Visible = false;
            lblUPCLastNamePF.Visible = false;
            lblUPCPrivateCustomerAddressPF.Visible = false;
            lblUPCUpdatePrivateCustomerInfoNF.Visible = false; 
            // Delete Customer 
            lblDeleteCustomerUnSpecificPF.Visible = false;
            lblDeleteCustomerUnSpecificNF.Visible = false;
            lblDeleteCustomerSpecificNF.Visible = false;
            lblDeleteCustomerSpecificPF.Visible = false;
            // Create Order
            lblCOGenerateOrderIDNF.Visible = false;
            lblCOSubmittCustomerIDNF.Visible = false;
            lblCOSubmittProductIDNF.Visible = false;
            lblCOSubmittQuantityNF.Visible = false;
            lblCOAddToOrderPF.Visible = false;
            lblCOAddToOrderNF.Visible = false;
            lblCOCreateOrderNF.Visible = false;
            // View Order
            lblVOVAViewAllOrdersNF.Visible = false;
            lblVOVAViewAlternativesPF.Visible = false;
            lblVOVAViewSpecificCustomerNF.Visible = false;
            lbllblVOSubmittSpecificOrderIDNF.Visible = false;           
            // Delete Order
            lblDODeleteUnspecifikOrdersPF.Visible = false;
            lblDODeleteUnspecifikOrdersNF.Visible = false;
            lblDODeleteSpecifikOrdersPF.Visible = false;
            lblDODeleteSpecifikOrdersNF.Visible = false;
            

        }
        private void BtnGenerateProducctID_Click(object sender, EventArgs e)
        {
            textBoxCPGenerateProducctID.Text = Controller.GenerateProductID();
            lblCPGenerateProductIDNF.Visible = false; 
        }
        private void BtnCCCGenerateCustomerID_Click(object sender, EventArgs e)
        {
            textBoxCCCDisplayGeneratedCustomerID.Text = Controller.GenerateCustomerID();
            lblCCCGenerateCompanyCustomerIDNF.Visible = false;
            lblCCCCreateCustomerPF.Visible = false;
        }
        private void BtnCPCGeneratePrivateCustomerID_Click(object sender, EventArgs e)
        {
            textBoxCPCGeneratePrivateCustomerID.Text = Controller.GenerateCustomerID();
            lblCPCGeneratePrivateCustomerIDNF.Visible = false;
            lblCPCCreateCustomerPF.Visible = false; 
        }
        private void BtnCOGenerateOrderID_Click(object sender, EventArgs e)
        {
            textBoxCOGenerateOrderID.Text = Controller.GenerateOrderID();
            lblCOGenerateOrderIDNF.Visible = false; 
        }
        private void BtnCOAddToOrder_Click(object sender, EventArgs e)
        {
            ClearAllFeedback(); 
            string tempProductID = textBoxCOSubmittProductID.Text;
            string tempQuantity = textBoxCOSubmittQuantity.Text;
            bool conditionOne = false;
            bool conditionTwo = false;
            bool conditionThree = false;
            if(tempProductID.Length == 0)
            {
                lblCOSubmittProductIDNF.Text = "Ange produktID";
                lblCOSubmittProductIDNF.Visible = true;
                conditionOne = true; 
            }
            if (tempQuantity.Length == 0)
            {
                lblCOSubmittQuantityNF.Text = "Ange önskad kvantitet";
                lblCOSubmittQuantityNF.Visible = true;
                conditionOne = true; 
            }
            if(conditionOne == false)
            {
                if (!Controller.ControllInputIsInteger(tempProductID))
                {
                    lblCOSubmittProductIDNF.Text = "Ange enbart siffror";
                    lblCOSubmittProductIDNF.Visible = true;
                    conditionTwo = true;
                }
                if (!Controller.ControllInputIsInteger(tempQuantity))
                {
                    lblCOSubmittQuantityNF.Text = "Ange enbart siffror";
                    lblCOSubmittQuantityNF.Visible = true;
                    conditionTwo = true; 
                }
                if(conditionTwo == false)
                {
                    int checkedProductID = Int32.Parse(tempProductID);
                    int checkedQuanity = Int32.Parse(tempQuantity);
                    if (!Controller.CheckIfProductIDExist(checkedProductID))
                    {
                        lblCOSubmittProductIDNF.Text = "ProductID:t finns ej";
                        lblCOSubmittProductIDNF.Visible = true;
                        conditionThree = true; 
                    }
                    if (!Controller.ControllIfStockQuantityIsPositive(checkedQuanity))
                    {
                        lblCOSubmittQuantityNF.Text = "Kvantiteten måste vara positiv";
                        lblCOSubmittQuantityNF.Visible = true;
                        conditionThree = true; 
                    }
                    if (checkedQuanity == 0)
                    {
                        lblCOSubmittQuantityNF.Text = "Kvantiteten måste vara större än noll";
                        lblCOSubmittQuantityNF.Visible = true;
                        conditionThree = true;
                    }
                    if (conditionThree == false)
                    {
                        int stockQuantity = Controller.StockQuantityForSpecificProduct(checkedProductID);
                        if (stockQuantity < checkedQuanity)
                        {
                            lblCOSubmittQuantityNF.Text = "Lagerkvantiteten är för låg";
                            lblCOSubmittQuantityNF.Visible = true;
                        }
                        else
                        {
                            if (!tempOrderDictonary.ContainsKey(checkedProductID))
                            {
                                tempOrderDictonary.Add(checkedProductID, checkedQuanity);
                                DataTable table = new DataTable();
                                table.Columns.Add("ProduktID", typeof(string));
                                table.Columns.Add("Kvantitet", typeof(string));
                                foreach (var v in tempOrderDictonary)
                                {
                                    table.Rows.Add(new string[] { v.Key.ToString(), v.Value.ToString() });

                                }
                                dataGridViewCOOngoingOrder.DataSource = table;
                                textBoxCOSubmittProductID.Text = "";
                                textBoxCOSubmittQuantity.Text = "";
                                lblCOAddToOrderPF.Text = "Produkt och kvantitet har lagts till ordern";
                                lblCOAddToOrderPF.Visible = true;
                            }
                            else
                            {
                                int i = tempOrderDictonary[checkedProductID]; 
                                if (i + checkedQuanity > stockQuantity)
                                {
                                    lblCOAddToOrderNF.Text = "Ej tilllagd, samlad orderkvantiteten blir större än varans lagerkvantitet";
                                    lblCOAddToOrderNF.Visible = true; 
                                }
                                else
                                {
                                    tempOrderDictonary[checkedProductID] += checkedQuanity; 
                                    DataTable table = new DataTable();
                                    table.Columns.Add("ProduktID", typeof(int));
                                    table.Columns.Add("Kvantitet", typeof(int));
                                    foreach (var v in tempOrderDictonary)
                                    {
                                        table.Rows.Add(new string[] { v.Key.ToString(), v.Value.ToString() });
                                    }
                                    dataGridViewCOOngoingOrder.DataSource = table;
                                    textBoxCOSubmittProductID.Text = "";
                                    textBoxCOSubmittQuantity.Text = "";
                                    lblCOAddToOrderPF.Text = "Produkt och kvantitet har lagts till ordern";
                                    lblCOAddToOrderPF.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        public void DisplaySQLErrorMessage(string errorMessage)
        {
            lblSQLEXFeedback.Text = errorMessage;
            lblSQLEXFeedback.Visible = true;
        }

        // Create
        private void BtnCreateProduct_Click(object sender, EventArgs e)
        {
            string tempProductID = textBoxCPGenerateProducctID.Text;
            string tempProductName = textBoxCPProductName.Text;
            string tempProductDescription = textBoxCPProductDiscription.Text;
            string tempStockQuantity = textBoxCPStockQuantity.Text;
            bool callCreateMethod = true;

            ClearAllFeedback();
            if (tempProductID.Length == 0)
            {
                lblCPGenerateProductIDNF.Text = "Du måste generera ett nytt ID";
                lblCPGenerateProductIDNF.Visible = true;
                callCreateMethod = false;
            }
            if (tempProductName.Length == 0)
            {
                lblCPProductNameNF.Text = "Du måste ange produktens namn";
                lblCPProductNameNF.Visible = true;
                callCreateMethod = false;
            }
            if (tempProductDescription.Length == 0)
            {
                lblCPProductDiscriptionNF.Text = "Du måste ange en produktbeskrivning";
                lblCPProductDiscriptionNF.Visible = true;
                callCreateMethod = false;
            }
            if (tempStockQuantity.Length == 0)
            {
                lblCPStockQuantityNF.Text = "Du måste ange ett lagersaldo för produkten";
                lblCPStockQuantityNF.Visible = true;
                callCreateMethod = false;
            }
            if (callCreateMethod == true)
            {
                int tempResult = Controller.CreateProduct(tempProductID, tempProductName, tempProductDescription, tempStockQuantity);
                switch (tempResult) {
                    case 0:
                        lblCPStockQuantityNF.Text = "Lagerkvantiteten kan bara innehålla siffror";
                        lblCPStockQuantityNF.Visible = true;
                        break;
                    case 1:
                        lblCPStockQuantityNF.Text = "Lagerkvantiteten måste vara ett positivt antal";
                        lblCPStockQuantityNF.Visible = true;
                        break;
                    case 2:
                        lblCPGenerateProductIDNF.Text = "Det genererade ID finns redan, testa igen";
                        lblCPGenerateProductIDNF.Visible = true;
                        break;
                    case 3:
                        lblCPCreateProductNF.Text = "Kontrollera SQL-query (fel)";
                        lblCPCreateProductNF.Visible = true;
                        break;
                    case 4:
                        lblCPCreateProductPF.Text = "Produkten har skapats";
                        lblCPCreateProductPF.Visible = true;
                        textBoxCPProductName.Text = "";
                        textBoxCPGenerateProducctID.Text = "";
                        textBoxCPProductDiscription.Text = "";
                        textBoxCPStockQuantity.Text = "";
                        break;
                    default:
                        break;
                }
            }
        }
        private void BtnCPCCreatePrivateCustomer_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            string customerID = textBoxCPCGeneratePrivateCustomerID.Text;
            string firstName = textBoxCPCFirstName.Text;
            string lastName = textBoxCPCLastName.Text;
            string address = textBoxCPCAddress.Text;
            bool condition = false;
            if (customerID.Length == 0)
            {
                lblCPCGeneratePrivateCustomerIDNF.Text = "Generera kundID";
                lblCPCGeneratePrivateCustomerIDNF.Visible = true;
                condition = true;
            }
            if (firstName.Length == 0)
            {
                lblCPCFirstNameNF.Text = "Ange kundens förnamn";
                lblCPCFirstNameNF.Visible = true;
                condition = true;
            }
            if (lastName.Length == 0)
            {
                lblCPCLastNameNF.Text = "Ange kundens efternamn";
                lblCPCLastNameNF.Visible = true;
                condition = true;
            }
            if (address.Length == 0)
            {
                lblCPCAddressNF.Text = "Ange kundens adress";
                lblCPCAddressNF.Visible = true;
                condition = true;
            }
            if (condition == false)
            {
                bool temp = Controller.CreatePrivateCustomer(Int32.Parse(customerID), firstName, lastName, address);
                switch (temp)
                {
                    case true:
                        lblCPCCreateCustomerPF.Text = "Privatkunden har registrerats";
                        lblCPCCreateCustomerPF.Visible = true;
                        textBoxCPCGeneratePrivateCustomerID.Text = "";
                        textBoxCPCFirstName.Text = "";
                        textBoxCPCLastName.Text = "";
                        textBoxCPCAddress.Text = "";
                        break;
                    case false:
                        lblCPCGeneratePrivateCustomerIDNF.Text = "KundID:t finns redan, generera igen";
                        lblCPCGeneratePrivateCustomerIDNF.Visible = true;
                        break;
                }
            }
        }
        private void BtnCCCCreateCompanyCustomer_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            string customerID = textBoxCCCDisplayGeneratedCustomerID.Text;
            string companyName = textBoxCCCCompanyName.Text;
            string companyAddress = textBoxCCCCompanyAddress.Text;
            bool condition = false;
            if (customerID.Length == 0)
            {
                lblCCCGenerateCompanyCustomerIDNF.Text = "Generera kundID";
                lblCCCGenerateCompanyCustomerIDNF.Visible = true;
                condition = true;
            }
            if (companyName.Length == 0)
            {
                lblCCCCompanyNameNF.Text = "Ange företagets namn";
                lblCCCCompanyNameNF.Visible = true;
                condition = true;
            }
            if (companyAddress.Length == 0)
            {
                lblCCCCompanyAddressNF.Text = "Ange företagets adress";
                lblCCCCompanyAddressNF.Visible = true;
                condition = true;
            }
            if (condition == false)
            {
                bool temp = Controller.CreateCompanyCustomer(Int32.Parse(customerID), companyName, companyAddress);
                switch (temp)
                {
                    case true:
                        lblCCCCreateCustomerPF.Text = "Företagskunden har registrerats";
                        lblCCCCreateCustomerPF.Visible = true;
                        textBoxCCCDisplayGeneratedCustomerID.Text = "";
                        textBoxCCCCompanyName.Text = "";
                        textBoxCCCCompanyAddress.Text = "";
                        break;
                    case false:
                        lblCCCGenerateCompanyCustomerIDNF.Text = "KundID:t finns redan";
                        lblCCCGenerateCompanyCustomerIDNF.Visible = true;
                        break;
                }

            }
        }
        private void BtnCOCreateOrder_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            bool resultIsPrivateCustomer = false;
            int numbOfProductsInOrder = 0;

            int orderID = OrderIDTempInMemory;
            int customerID = CustomerIDTempInMemory;
            
            if (tempOrderDictonary.Count == 0)
            {
                lblCOCreateOrderNF.Text = "Ej skickad, ordern är tom";
                lblCOCreateOrderNF.Visible = true;
            }
            else
            {
                bool tempIsPrivateCustomer = Controller.CheckIfCustomerIsPrivateCustomer(customerID);
                if (tempIsPrivateCustomer)
                {
                    resultIsPrivateCustomer = Controller.CreateCustomerOrder(orderID: orderID, privateCustomerID: customerID);
                }
                else
                {
                    Controller.CreateCustomerOrder(orderID: orderID, companyCustomerID: customerID);
                }
                foreach (var v in tempOrderDictonary)
                {
                    numbOfProductsInOrder += Controller.CreateProduct_Orders(v.Key, orderID, v.Value);
                    int temp = Controller.StockQuantityForSpecificProduct(v.Key) - v.Value;
                    Controller.UpdateProduct(productID: v.Key, stockQuantity: temp);
                }
                if (resultIsPrivateCustomer)
                {
                    lblOngoingOrderIDFeedback.Text = $"Order: {orderID} till privatkund: {customerID} med {numbOfProductsInOrder} produkter är skickad";
                    lblOngoingOrderIDFeedback.Visible = true;
                    textBoxCOSubmittProductID.Text = "";
                    textBoxCOSubmittQuantity.Text = "";
                    textBoxCOGenerateOrderID.Text = "";
                    textBoxCOSubmittCustomerID.Text = "";
                    groupBoxCreateOrderStepOne.Show();
                    dataGridViewCOOngoingOrder.DataSource = null;
                    OrderIDTempInMemory = 0;
                    CustomerIDTempInMemory = 0;
                    tempOrderDictonary.Clear();
                }
                else
                {
                    lblOngoingOrderIDFeedback.Text = $"Order: {orderID} till företagskund: {customerID} med {numbOfProductsInOrder} produkter är skickad";
                    lblOngoingOrderIDFeedback.Visible = true;
                    textBoxCOSubmittProductID.Text = "";
                    textBoxCOSubmittQuantity.Text = "";
                    textBoxCOGenerateOrderID.Text = "";
                    textBoxCOSubmittCustomerID.Text = "";
                    groupBoxCreateOrderStepOne.Show();
                    dataGridViewCOOngoingOrder.DataSource = null;
                    OrderIDTempInMemory = 0;
                    CustomerIDTempInMemory = 0;
                    tempOrderDictonary.Clear();
                }
            }        
        }


        // (Read)View
        private void BtnViewAllProducts_Click(object sender, EventArgs e)
        {
            dataGridViewProduct.DataSource = null;
            ClearAllFeedback();
            DataTable table =  Controller.DisplayAllProducts();
            if(table.Rows.Count > 0)
            {
                dataGridViewProduct.DataSource = table; 
                lblViewProductViewAllProductsPF.Text = "Resultatet visas";
                lblViewProductViewAllProductsPF.Visible = true; 
            }
            else
            {
                lblViewProductViewAllProductsNF.Text = "Finns inga produkter";
                lblViewProductViewAllProductsNF.Visible = true; 
            }
        }
        private void BtnViewSpecificProduct_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            dataGridViewProduct.DataSource = null;
            string tempProductID = textBoxVPSubmittProductID.Text;
            if (tempProductID.Length == 0)
            {
                lblViewProductViewSpecificProductNF.Text = "Ange produkID";
                lblViewProductViewSpecificProductNF.Visible = true;
            }
            else if (tempProductID.Length > 0)
            {
                if (Controller.ControllInputIsInteger(tempProductID))
                {
                    DataTable tempTable = Controller.DisplaySpecificProduct(Int32.Parse(tempProductID));
                    int i = tempTable.Rows.Count;
                    if (i == 0)
                    {
                        lblViewProductViewSpecificProductNF.Text = "ProduktID:t finns ej";
                        lblViewProductViewSpecificProductNF.Visible = true;
                    }
                    else
                    {
                        dataGridViewProduct.DataSource = tempTable;
                        dataGridViewProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        foreach (DataGridViewColumn x in dataGridViewProduct.Columns)
                        {
                            x.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                        lblViewProductViewSpecificProductPF.Text = "Resultatet visas";
                        lblViewProductViewSpecificProductPF.Visible = true;
                        textBoxVPSubmittProductID.Text = "";
                    }
                }
                else
                {
                    lblViewProductViewSpecificProductNF.Text = "Ange enbar siffror";
                    lblViewProductViewSpecificProductNF.Visible = true;
                }
            }



            //bool isInputInt = Controller

        }
        private void BtnViewUnspecificCustomers_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            dataGridViewCustomer.DataSource = null;
            bool condition = false;
            DataTable table = new DataTable();
            if (radioBtnVCAllCompanyCustomers.Checked)
            {
                table = Controller.DisplayAllCustomersBySelectedCategory(1);
            }
            if (radioBtnVCAllPrivateCostomers.Checked)
            {
                table = Controller.DisplayAllCustomersBySelectedCategory(2);
            }
            if (radioBtnVCAllCustomers.Checked)
            {
                table = Controller.DisplayAllCustomersBySelectedCategory(3);
            }
            if (table.Rows.Count > 0)
            {
                condition = true;
                dataGridViewCustomer.DataSource = table;
            }
            switch (condition)
            {
                case false:
                    lblVCViewUnspecificCustomersNF.Text = "Inga kunder finns ännu för kategorin";
                    lblVCViewUnspecificCustomersNF.Visible = true;
                    break;
                case true:
                    lblVCViewUnspecificCustomersPF.Text = "Resultatet visas";
                    lblVCViewUnspecificCustomersPF.Visible = true;
                    break;
            }
        }
        private void BtnViewSpecificCustomerID_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            dataGridViewCustomer.DataSource = null;
            DataTable table = new DataTable();
            string tempInput = textBoxVCSubmittSpecificCustomerID.Text;
            if (tempInput.Length == 0)
            {
                lblVCViewSpecificCustomersNF.Text = "Ange kundID";
                lblVCViewSpecificCustomersNF.Visible = true;
            }
            else
            {
                if (!Controller.ControllInputIsInteger(tempInput))
                {
                    lblVCViewSpecificCustomersNF.Text = "Ange enbart siffror";
                    lblVCViewSpecificCustomersNF.Visible = true;
                }
                else
                {
                    int checkedID = Int32.Parse(tempInput);
                    table = Controller.DisplaySpecificCustomer(checkedID);
                    dataGridViewCustomer.DataSource = table;

                    if (table.Rows.Count == 0)
                    {
                        lblVCViewSpecificCustomersNF.Text = "KundID:t finns ej";
                        lblVCViewSpecificCustomersNF.Visible = true;
                    }
                    else
                    {
                        dataGridViewCustomer.DataSource = table;
                        lblVCViewSpecificCustomersPF.Text = "Resultatet visas";
                        lblVCViewSpecificCustomersPF.Visible = true;
                    }
                }
            }
        }
        private void BtnCOViewAllProducts_Click(object sender, EventArgs e)
        {
            dataGridViewCOViewAllProducts.DataSource = Controller.DisplayAllProducts();
        }
        private void BtnCOViewAllCustomers_Click(object sender, EventArgs e)
        {
            dataGridViewCOViewAllCustomers.DataSource = Controller.DisplayAllCustomersBySelectedCategory(3); 
        }
        private void BtnVOViewAlternatives_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            lblVOVADisplayFeedbackPF.Visible = false;
            dataGridViewVOVA.DataSource = null; 
            DataTable dataTable = new DataTable(); 
            if (radioBtnVOVAViewAllOrders.Checked)
            {
                dataTable = Controller.DisplayAllOrders();
                if(dataTable.Rows.Count == 0)
                {
                    lblVOVAViewAllOrdersNF.Text = "Finns inga ordrar"; 
                    lblVOVAViewAllOrdersNF.Visible = true; 
                }
                else
                {
                    lblVOVAViewAlternativesPF.Text = "Resultatet visas";
                    lblVOVAViewAlternativesPF.Visible = true;
                    dataGridViewVOVA.DataSource = dataTable;
                    lblVOVADisplayFeedbackPF.Text = "Alla ordrar:";
                    lblVOVADisplayFeedbackPF.Visible = true;
                    textBoxVOVAViewSpecificCustomer.Text = "";
                    textBoxVOSubmittSpecificOrderID.Text = "";
                }
            }
            else if (radioBtnVOVAViewAllOrdersforSpecificCustomer.Checked)
            {
                string tempCustomerID = textBoxVOVAViewSpecificCustomer.Text;
                if(tempCustomerID.Length == 0)
                {
                    lblVOVAViewSpecificCustomerNF.Text = "Ange kundID";
                    lblVOVAViewSpecificCustomerNF.Visible = true; 
                }
                else
                {
                    if (!Controller.ControllInputIsInteger(tempCustomerID))
                    {
                        lblVOVAViewSpecificCustomerNF.Text = "Ange enbart siffror";
                        lblVOVAViewSpecificCustomerNF.Visible = true;
                    }
                    else
                    {
                        int checkedCustomerID = Int32.Parse(tempCustomerID);
                        if (!Controller.CheckIfCustomerIDExist(checkedCustomerID))
                        {
                            lblVOVAViewSpecificCustomerNF.Text = "KundID:t finns ej";
                            lblVOVAViewSpecificCustomerNF.Visible = true;
                        }
                        else
                        {
                            dataTable = Controller.DisplayAllOrdersForSpecificCustomer(checkedCustomerID); 
                            if(dataTable.Rows.Count == 0)
                            {
                                lblVOVAViewSpecificCustomerNF.Text = "Kunden har inga ordrar";
                                lblVOVAViewSpecificCustomerNF.Visible = true;
                            }
                            else
                            {
                                dataGridViewVOVA.DataSource = dataTable;
                                lblVOVAViewAlternativesPF.Text = "Resultatet visas";
                                lblVOVAViewAlternativesPF.Visible = true;
                                lblVOVADisplayFeedbackPF.Text = $"Kund {checkedCustomerID}:";
                                lblVOVADisplayFeedbackPF.Visible = true;
                                textBoxVOVAViewSpecificCustomer.Text = "";
                                textBoxVOSubmittSpecificOrderID.Text = "";
                            }
                        }
                    }
                }
            }
            else if (radioBtnVOVAViewSpecificOrder.Checked)
            {
                string tempOrderID = textBoxVOSubmittSpecificOrderID.Text;
                if (tempOrderID.Length == 0)
                {
                    lbllblVOSubmittSpecificOrderIDNF.Text = "Ange orderID";
                    lbllblVOSubmittSpecificOrderIDNF.Visible = true;
                }
                else
                {
                    if (!Controller.ControllInputIsInteger(tempOrderID))
                    {
                        lbllblVOSubmittSpecificOrderIDNF.Text = "Ange enbart siffror";
                        lbllblVOSubmittSpecificOrderIDNF.Visible = true;

                    }
                    else
                    {
                        int checkedOrderID = Int32.Parse(tempOrderID);
                        if (!Controller.CheckIfOrderIDExist(checkedOrderID))
                        {
                            lbllblVOSubmittSpecificOrderIDNF.Text = "OrderID:t finns ej";
                            lbllblVOSubmittSpecificOrderIDNF.Visible = true;

                        }
                        else
                        {
                            dataTable = Controller.DisplaySpecificOrder(checkedOrderID); 
                            dataGridViewVOVA.DataSource = dataTable;
                            lblVOVAViewAlternativesPF.Text = "Resultatet visas";
                            lblVOVAViewAlternativesPF.Visible = true;
                            lblVOVADisplayFeedbackPF.Text = $"Order {checkedOrderID}:";
                            lblVOVADisplayFeedbackPF.Visible = true;
                            textBoxVOVAViewSpecificCustomer.Text = "";
                            textBoxVOSubmittSpecificOrderID.Text = "";
                        }
                    }
                }
            }
        }

        // Update
        private void BtnUpdateProduct_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            string tempProductID = textBoxUPSubmittProductID.Text;
            string tempStockQuantity = textBoxUPStockQuantity.Text;
            string tempProductName = textBoxUPProductName.Text;
            string tempProductDescripption = textBoxUPProductDiscription.Text;
            int feedback;
            if (tempProductID.Length == 0)
            {
                lblUPProductIDNF.Text = "Ange produktID";
                lblUPProductIDNF.Visible = true;
            }
            else
            {
                if (Controller.ControllInputIsInteger(tempProductID))
                {
                    int checkedProductID = Int32.Parse(tempProductID);
                    if (tempStockQuantity.Length != 0)
                    {
                        if (!Controller.ControllInputIsInteger(tempStockQuantity))
                        {
                            lblUPProductStockQuantityNF.Text = "Ange enbart siffror";
                            lblUPProductStockQuantityNF.Visible = true;
                        }
                        else
                        {
                            int checkedStockQuantity = Int32.Parse(tempStockQuantity);
                            if (checkedStockQuantity < 0)
                            {
                                lblUPProductStockQuantityNF.Text = "Lagerkvantiteten får ej vara mindre än noll";
                                lblUPProductStockQuantityNF.Visible = true;
                            }
                            else
                            {
                                feedback = Controller.UpdateProduct(checkedProductID, tempProductName, tempProductDescripption, checkedStockQuantity);

                                switch (feedback)
                                {
                                    case -1:
                                        lblUPProductIDNF.Text = "ProduktID:t finns ej";
                                        lblUPProductIDNF.Visible = true;
                                        break;
                                    case 0:
                                        lblUPUpdateProductNF.Text = "Ingen ny info att uppdatera";
                                        lblUPUpdateProductNF.Visible = true;
                                        break;
                                    case 1:
                                        lblUPProductNamePF.Text = "Produktens namn har uppdaterats";
                                        lblUPProductNamePF.Visible = true;
                                        textBoxUPSubmittProductID.Text = "";
                                        textBoxUPProductName.Text = "";
                                        break;
                                    case 10:
                                        lblUPProductDescriptionPF.Text = "Produktbeskrivningen har uppdaterats";
                                        lblUPProductDescriptionPF.Visible = true;
                                        textBoxUPSubmittProductID.Text = "";
                                        textBoxUPProductDiscription.Text = "";
                                        break;
                                    case 11:
                                        lblUPProductNamePF.Text = "Produktens namn har uppdaterats";
                                        lblUPProductNamePF.Visible = true;
                                        lblUPProductDescriptionPF.Text = "Produktbeskrivningen har uppdaterats";
                                        lblUPProductDescriptionPF.Visible = true;
                                        textBoxUPSubmittProductID.Text = "";
                                        textBoxUPProductName.Text = "";
                                        textBoxUPProductDiscription.Text = "";
                                        break;
                                    case 100:
                                        lblUPProductStockQuantityPF.Text = "Lagerkvantiteten har uppdaterats";
                                        lblUPProductStockQuantityPF.Visible = true;
                                        textBoxUPSubmittProductID.Text = "";
                                        textBoxUPStockQuantity.Text = "";
                                        break;
                                    case 101:
                                        lblUPProductNamePF.Text = "Produktens namn har uppdaterats";
                                        lblUPProductNamePF.Visible = true;
                                        lblUPProductStockQuantityPF.Text = "Lagerkvantiteten har uppdaterats";
                                        lblUPProductStockQuantityPF.Visible = true;
                                        textBoxUPSubmittProductID.Text = "";
                                        textBoxUPProductName.Text = "";
                                        textBoxUPStockQuantity.Text = "";
                                        break;
                                    case 110:
                                        lblUPProductDescriptionPF.Text = "Produktbeskrivningen har uppdaterats";
                                        lblUPProductDescriptionPF.Visible = true;
                                        lblUPProductStockQuantityPF.Text = "Lagerkvantiteten har uppdaterats";
                                        lblUPProductStockQuantityPF.Visible = true;
                                        textBoxUPSubmittProductID.Text = "";
                                        textBoxUPProductDiscription.Text = "";
                                        textBoxUPStockQuantity.Text = "";
                                        break;
                                    case 111:
                                        lblUPProductNamePF.Text = "Produktens namn har uppdaterats";
                                        lblUPProductNamePF.Visible = true;
                                        lblUPProductDescriptionPF.Text = "Produktbeskrivningen har uppdaterats";
                                        lblUPProductDescriptionPF.Visible = true;
                                        lblUPProductStockQuantityPF.Text = "Lagerkvantiteten har uppdaterats";
                                        lblUPProductStockQuantityPF.Visible = true;
                                        textBoxUPSubmittProductID.Text = "";
                                        textBoxUPProductName.Text = "";
                                        textBoxUPProductDiscription.Text = "";
                                        textBoxUPStockQuantity.Text = "";
                                        break;
                                    default:
                                        break;
                                }
                            }

                        }
                    }
                    else
                    {
                        feedback = Controller.UpdateProduct(checkedProductID, tempProductName, tempProductDescripption);
                        switch (feedback)
                        {
                            case -1:
                                lblUPProductIDNF.Text = "ProduktID:t finns ej";
                                lblUPProductIDNF.Visible = true;
                                break;
                            case 0:
                                lblUPUpdateProductNF.Text = "Ingen ny info att uppdatera";
                                lblUPUpdateProductNF.Visible = true;
                                break;
                            case 1:
                                lblUPProductNamePF.Text = "Produktens namn har uppdaterats";
                                lblUPProductNamePF.Visible = true;
                                textBoxUPSubmittProductID.Text = "";
                                textBoxUPProductName.Text = "";
                                break;
                            case 10:
                                lblUPProductDescriptionPF.Text = "Produktbeskrivningen har uppdaterats";
                                lblUPProductDescriptionPF.Visible = true;
                                textBoxUPSubmittProductID.Text = "";
                                textBoxUPProductDiscription.Text = "";
                                break;
                            case 11:
                                lblUPProductNamePF.Text = "Produktens namn har uppdaterats";
                                lblUPProductNamePF.Visible = true;
                                lblUPProductDescriptionPF.Text = "Produktbeskrivningen har uppdaterats";
                                lblUPProductDescriptionPF.Visible = true;
                                textBoxUPSubmittProductID.Text = "";
                                textBoxUPProductName.Text = "";
                                textBoxUPProductDiscription.Text = "";
                                break;
                            case 100:
                                lblUPProductStockQuantityPF.Text = "Lagerkvantiteten har uppdaterats";
                                lblUPProductStockQuantityPF.Visible = true;
                                textBoxUPSubmittProductID.Text = "";
                                textBoxUPStockQuantity.Text = "";
                                break;
                            case 101:
                                lblUPProductNamePF.Text = "Produktens namn har uppdaterats";
                                lblUPProductNamePF.Visible = true;
                                lblUPProductStockQuantityPF.Text = "Lagerkvantiteten har uppdaterats";
                                lblUPProductStockQuantityPF.Visible = true;
                                textBoxUPSubmittProductID.Text = "";
                                textBoxUPProductName.Text = "";
                                textBoxUPStockQuantity.Text = "";
                                break;
                            case 110:
                                lblUPProductDescriptionPF.Text = "Produktbeskrivningen har uppdaterats";
                                lblUPProductDescriptionPF.Visible = true;
                                lblUPProductStockQuantityPF.Text = "Lagerkvantiteten har uppdaterats";
                                lblUPProductStockQuantityPF.Visible = true;
                                textBoxUPSubmittProductID.Text = "";
                                textBoxUPProductDiscription.Text = "";
                                textBoxUPStockQuantity.Text = "";
                                break;
                            case 111:
                                lblUPProductNamePF.Text = "Produktens namn har uppdaterats";
                                lblUPProductNamePF.Visible = true;
                                lblUPProductDescriptionPF.Text = "Produktbeskrivningen har uppdaterats";
                                lblUPProductDescriptionPF.Visible = true;
                                lblUPProductStockQuantityPF.Text = "Lagerkvantiteten har uppdaterats";
                                lblUPProductStockQuantityPF.Visible = true;
                                textBoxUPSubmittProductID.Text = "";
                                textBoxUPProductName.Text = "";
                                textBoxUPProductDiscription.Text = "";
                                textBoxUPStockQuantity.Text = "";
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    lblUPProductIDNF.Text = "Ange enbart siffror";
                    lblUPProductIDNF.Visible = true;
                }
            }
        }
        private void BtnUCCUpdateCompanyCustomer_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            string tempCustomerID = textBoxUCCSubmittCustomerID.Text; 
            string companyName = textBoxUCCCompanyName.Text;
            string address = textBoxUCCCompanyAddress.Text; 
            int feedback; 
            if(tempCustomerID.Length == 0)
            {
                lblUCCSubmittCustomerIDNF.Text = "Ange kundID";
                lblUCCSubmittCustomerIDNF.Visible = true; 

            }
            else
            {
                if (!Controller.ControllInputIsInteger(tempCustomerID))
                {
                    lblUCCSubmittCustomerIDNF.Text = "Ange enbart siffror";
                    lblUCCSubmittCustomerIDNF.Visible = true;
                }
                else
                {
                    int checkedID = Int32.Parse(tempCustomerID);
                    feedback = Controller.UpdateCompanyCustomer(checkedID, companyName, address);
                    switch (feedback){
                        case -2:
                            lblUCCSubmittCustomerIDNF.Text = "KundID:t tillhör ej en företagskund";
                            lblUCCSubmittCustomerIDNF.Visible = true; 
                            break;
                        case -1:
                            lblUCCSubmittCustomerIDNF.Text = "KundID:t finns ej";
                            lblUCCSubmittCustomerIDNF.Visible = true;
                            break;
                        case 0:
                            lblUCCUpdateCompanyCustomerNF.Text = "Ingen ny info att uppdatera";
                            lblUCCUpdateCompanyCustomerNF.Visible = true; 
                            break;
                        case 1:
                            lblUCCCompanyNamePF.Text = "Företagets namn har uppdaterats";
                            lblUCCCompanyNamePF.Visible = true;
                            textBoxUCCSubmittCustomerID.Text = "";
                            textBoxUCCCompanyName.Text = "";
                            textBoxUCCCompanyAddress.Text = "";
                            break;
                        case 10:
                            lblUCCCompanyAddressPF.Text = "Företagets namn har uppdaterats";
                            lblUCCCompanyAddressPF.Visible = true;
                            textBoxUCCSubmittCustomerID.Text = "";
                            textBoxUCCCompanyName.Text = "";
                            textBoxUCCCompanyAddress.Text = "";
                            break;
                        case 11:
                            lblUCCCompanyNamePF.Text = "Företagets namn har uppdaterats";
                            lblUCCCompanyNamePF.Visible = true;
                            lblUCCCompanyAddressPF.Text = "Företagets namn har uppdaterats";
                            lblUCCCompanyAddressPF.Visible = true;
                            textBoxUCCSubmittCustomerID.Text = "";
                            textBoxUCCCompanyName.Text = "";
                            textBoxUCCCompanyAddress.Text = "";
                            break;
                        default:
                            break; 
                    }
                }
            }
        }
        private void BtnUPCUpdatePrivateCustomer_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            string tempCustomerID = textBoxUPCSubmittCustomerID.Text;
            string firstName = textBoxUPCFirstName.Text;
            string lastName = textBoxUPCLastName.Text;
            string address = textBoxUPCPrivateCustomerAddress.Text;
            int feedback; 
            if (tempCustomerID.Length == 0)
            {
                lblUPCSubmittCustomerIDNF.Text = "Ange kundID";
                lblUPCSubmittCustomerIDNF.Visible = true; 
            }
            else
            {
                if (!Controller.ControllInputIsInteger(tempCustomerID))
                {
                    lblUPCSubmittCustomerIDNF.Text = "Ange enbart siffror";
                    lblUPCSubmittCustomerIDNF.Visible = true; 
                }
                else
                {
                    int checkedID = Int32.Parse(tempCustomerID);
                    feedback = Controller.UpdatePrivateCustomer(checkedID, firstName, lastName, address);
                    switch (feedback)
                    {
                        case -2:
                            lblUPCSubmittCustomerIDNF.Text = "KundID:t tillhör ej en privatkund";
                            lblUPCSubmittCustomerIDNF.Visible = true; 
                            break;
                        case -1:
                            lblUPCSubmittCustomerIDNF.Text = "KundID:t finns ej";
                            lblUPCSubmittCustomerIDNF.Visible = true;
                            break;
                        case 0:
                            lblUPCUpdatePrivateCustomerInfoNF.Text = "Ingen ny info att uppdatera";
                            lblUPCUpdatePrivateCustomerInfoNF.Visible = true; 
                            break;
                        case 1:
                            lblUPCFirstNamePF.Text = "Kundens förnamn har uppdaterats";
                            lblUPCFirstNamePF.Visible = true;
                            textBoxUPCSubmittCustomerID.Text = "";
                            textBoxUPCFirstName.Text = "";
                            textBoxUPCLastName.Text = "";
                            textBoxUPCPrivateCustomerAddress.Text = "";
                            break;
                        case 10:
                            lblUPCLastNamePF.Text = "Kundens efternamn har uppdaterarts";
                            lblUPCLastNamePF.Visible = true;
                            textBoxUPCSubmittCustomerID.Text = "";
                            textBoxUPCFirstName.Text = "";
                            textBoxUPCLastName.Text = "";
                            textBoxUPCPrivateCustomerAddress.Text = "";
                            break;
                        case 11:
                            lblUPCFirstNamePF.Text = "Kundens förnamn har uppdaterats";
                            lblUPCFirstNamePF.Visible = true;
                            lblUPCLastNamePF.Text = "Kundens efternamn har uppdaterarts";
                            lblUPCLastNamePF.Visible = true;
                            textBoxUPCSubmittCustomerID.Text = "";
                            textBoxUPCFirstName.Text = "";
                            textBoxUPCLastName.Text = "";
                            textBoxUPCPrivateCustomerAddress.Text = "";
                            break;
                        case 100:
                            lblUPCPrivateCustomerAddressPF.Text = "Kundens adress har uppdaterats";
                            lblUPCPrivateCustomerAddressPF.Visible = true;
                            textBoxUPCSubmittCustomerID.Text = "";
                            textBoxUPCFirstName.Text = "";
                            textBoxUPCLastName.Text = "";
                            textBoxUPCPrivateCustomerAddress.Text = "";
                            break;
                        case 101:
                            lblUPCFirstNamePF.Text = "Kundens förnamn har uppdaterats";
                            lblUPCFirstNamePF.Visible = true;
                            lblUPCPrivateCustomerAddressPF.Text = "Kundens adress har uppdaterats";
                            lblUPCPrivateCustomerAddressPF.Visible = true;
                            textBoxUPCSubmittCustomerID.Text = "";
                            textBoxUPCFirstName.Text = "";
                            textBoxUPCLastName.Text = "";
                            textBoxUPCPrivateCustomerAddress.Text = "";
                            break;
                        case 110:
                            lblUPCLastNamePF.Text = "Kundens efternamn har uppdaterarts";
                            lblUPCLastNamePF.Visible = true;
                            lblUPCPrivateCustomerAddressPF.Text = "Kundens adress har uppdaterats";
                            lblUPCPrivateCustomerAddressPF.Visible = true;
                            textBoxUPCSubmittCustomerID.Text = "";
                            textBoxUPCFirstName.Text = "";
                            textBoxUPCLastName.Text = "";
                            textBoxUPCPrivateCustomerAddress.Text = "";
                            break;
                        case 111:
                            lblUPCFirstNamePF.Text = "Kundens förnamn har uppdaterats";
                            lblUPCFirstNamePF.Visible = true;
                            lblUPCLastNamePF.Text = "Kundens efternamn har uppdaterarts";
                            lblUPCLastNamePF.Visible = true;
                            lblUPCPrivateCustomerAddressPF.Text = "Kundens adress har uppdaterats";
                            lblUPCPrivateCustomerAddressPF.Visible = true;
                            textBoxUPCSubmittCustomerID.Text = "";
                            textBoxUPCFirstName.Text = "";
                            textBoxUPCLastName.Text = "";
                            textBoxUPCPrivateCustomerAddress.Text = ""; 
                            break;
                        default:
                            break; 
                    }
                }
            }
        }

        // Delete
        private void BtnDeleteAllProducts_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            bool temp = Controller.DeleteAllProducts();
            if (temp)
            {
                lblDeleteAllProductsPF.Text = "Alla produkter har raderats";
                lblDeleteAllProductsPF.Visible = true;
            }
            else
            {
                lblDeleteAllProductsNF.Text = "Finns inga produkter";
                lblDeleteAllProductsNF.Visible = true;
            }
        }
        private void BtnDeleteSpecificProduct_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            string tempProductID = textBoxDSPSubmittProductID.Text;
            if (tempProductID.Length == 0)
            {
                lblDeleteSpecificProductNF.Text = "Ange produktID:t";
                lblDeleteSpecificProductNF.Visible = true;
            }
            else
            {
                if (Models.ModelMethods.ControllInputIsInteger(tempProductID))
                {
                    if (Controller.DeleteSpecificProduct(Int32.Parse(tempProductID)))
                    {
                        lblDeleteSpecificProductPF.Text = "Raderingen har genomförts";
                        lblDeleteSpecificProductPF.Visible = true;
                        textBoxDSPSubmittProductID.Text = "";
                    }
                    else
                    {
                        lblDeleteSpecificProductNF.Text = "ProduktID:t finns ej";
                        lblDeleteSpecificProductNF.Visible = true;
                    }


                }
                else
                {
                    lblDeleteSpecificProductNF.Text = "Ange enbart siffror";
                    lblDeleteSpecificProductNF.Visible = true;
                }
            }
        }
        private void BtnDeleteCustomerUnSpecific_Click(object sender, EventArgs e)
        {
            ClearAllFeedback(); 
            int feedback = 0; 
            if (radioBtnDeleteAllPrivateCustomersUnSpecific.Checked)
            {
                feedback = Controller.DeleteAllOfASpecificCustomerType(1);
            }
            if (radioBtnDeleteAllCompanyCustomersUnSpecific.Checked)
            {
                feedback = Controller.DeleteAllOfASpecificCustomerType(2);
            }
            if (radioBtnDeleteAllCustomersUnSpecific.Checked)
            {
                feedback = Controller.DeleteAllOfASpecificCustomerType(3); 
            }
            switch (feedback)
            {
                case -5:
                    lblDeleteCustomerUnSpecificPF.Text = "Alla företagskunder har raderats (finns inga privatkunder)";
                    lblDeleteCustomerUnSpecificPF.Visible = true;
                    break;
                case -4:
                    lblDeleteCustomerUnSpecificPF.Text = "Alla privatkunder har raderats (finns inga företagskunder)";
                    lblDeleteCustomerUnSpecificPF.Visible = true;
                    break;
                case -3:
                    lblDeleteCustomerUnSpecificNF.Text = "Finns inga privatkunder eller företagskunder";
                    lblDeleteCustomerUnSpecificNF.Visible = true;
                    break;
                case -2:
                    lblDeleteCustomerUnSpecificNF.Text = "Finns inga företagskunder";
                    lblDeleteCustomerUnSpecificNF.Visible = true;
                    break; 
                case -1:
                    lblDeleteCustomerUnSpecificNF.Text = "Finns inga privatkunder";
                    lblDeleteCustomerUnSpecificNF.Visible = true; 
                    break;
                case 1:
                    lblDeleteCustomerUnSpecificPF.Text = "Alla privatkunder har raderats";
                    lblDeleteCustomerUnSpecificPF.Visible = true; 
                    break;
                case 2:
                    lblDeleteCustomerUnSpecificPF.Text = "Alla företagskunder har raderats";
                    lblDeleteCustomerUnSpecificPF.Visible = true;
                    break;
                case 3:
                    lblDeleteCustomerUnSpecificPF.Text = "Alla privatkunder och företagskunder har raderats";
                    lblDeleteCustomerUnSpecificPF.Visible = true;
                    break;
                default:
                    break;
            }
        }
        private void BtnDeleteCustomerSpecific_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            string tempCustomerID = textBoxDeleteCustomerSpecific.Text;
            if (tempCustomerID.Length == 0)
            {
                lblDeleteCustomerSpecificNF.Text = "Ange kundID";
                lblDeleteCustomerSpecificNF.Visible = true;
            }
            else
            {
                if (!Controller.ControllInputIsInteger(tempCustomerID))
                {
                    lblDeleteCustomerSpecificNF.Text = "Ange enbart siffror";
                    lblDeleteCustomerSpecificNF.Visible = true;
                }
                else
                {
                    int checkedID = Int32.Parse(tempCustomerID);
                    if (Controller.DeleteSpecificCustomer(checkedID))
                    {
                        lblDeleteCustomerSpecificPF.Text = "Kunden har raderats";
                        lblDeleteCustomerSpecificPF.Visible = true;
                        textBoxDeleteCustomerSpecific.Text = ""; 
                    }
                    else
                    {
                        lblDeleteCustomerSpecificNF.Text = "KundID:t finns ej";
                        lblDeleteCustomerSpecificNF.Visible = true;
                    }
                }
            }


        }
        private void BtnDODeleteUnspecifikOrders_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            if (Controller.DeleteAllOrders())
            {
                lblDODeleteUnspecifikOrdersPF.Text = "Alla ordrar har raderats";
                lblDODeleteUnspecifikOrdersPF.Visible = true; 
            }
            else
            {
                lblDODeleteUnspecifikOrdersNF.Text = "Finns inga ordrar";
                lblDODeleteUnspecifikOrdersNF.Visible = true; 
            }
        }
        private void BtnDODeleteSpecifikOrders_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            string tempOrderID = textBoxSubmittSpecificOrderID.Text; 
            if (tempOrderID.Length == 0)
            {
                lblDODeleteSpecifikOrdersNF.Text = "Ange orderID";
                lblDODeleteSpecifikOrdersNF.Visible = true; 
            }
            else
            {
                if (!Controller.ControllInputIsInteger(tempOrderID))
                {
                    lblDODeleteSpecifikOrdersNF.Text = "Ange enbart siffror";
                    lblDODeleteSpecifikOrdersNF.Visible = true; 
                }
                else
                {
                    int checkedOrderID = Int32.Parse(tempOrderID);
                    if (!Controller.CheckIfOrderIDExist(checkedOrderID))
                    {
                        lblDODeleteSpecifikOrdersNF.Text = "OrderID finns ej";
                        lblDODeleteSpecifikOrdersNF.Visible = true; 
                    }
                    else
                    {
                        if (Controller.DeleteOrder(checkedOrderID))
                        {
                            lblDODeleteSpecifikOrdersPF.Text = "Ordern har raderats";
                            lblDODeleteSpecifikOrdersPF.Visible = true;
                            textBoxSubmittSpecificOrderID.Text = "";
                        }
                        else
                        {
                            lblDODeleteSpecifikOrdersNF.Text = "Ordern kunde inte raderas";
                            lblDODeleteSpecifikOrdersNF.Visible = true; 
                        }
                    }
                }
            }
        }


    }
}

