using System;
using System.ComponentModel;
using System.Windows.Forms;
using ThuyTienNguyen_C968_InventoryManagement.Models;

namespace ThuyTienNguyen_C968_InventoryManagement
{
    public partial class ModifyProduct : Form
    {

        private Product product;
        private BindingList<Part> tempList;
        private bool found = false;

        private bool allowSave()
        {
            if (!ValidateFields.IsNotNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("this field must not be blank");
                return false;
            }

            if (!ValidateFields.IsDecimal(PriceTextBox.Text))
            {
                MessageBox.Show("price/cost must be a number");
                return false;
            }

            if (!ValidateFields.IsInt(InventoryTextBox.Text))
            {
                MessageBox.Show("inventory/instock must be a number");
                return false;
            }

            if (!ValidateFields.IsInt(MinTextBox.Text))
            {
                MessageBox.Show("min must be a number");
                return false;
            }

            if (!ValidateFields.IsInt(MaxTextBox.Text))
            {
                MessageBox.Show("max must be a number");
                return false;
            }

            if (!ValidateFields.InvBetweenMinMax(InventoryTextBox.Text, MinTextBox.Text, MaxTextBox.Text))
            {
                MessageBox.Show("inventory/ instock must be in range between min and max");
                return false;
            }

                    
            return true;

        }

        public ModifyProduct()
        {
            InitializeComponent();

            product = Inventory.CurrentProduct;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = Inventory.Parts;

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.DefaultCellStyle.SelectionForeColor = dataGridView2.DefaultCellStyle.ForeColor;
            dataGridView2.RowHeadersVisible = false;



            if (product != null)
            {
                IDTextBox.Text = product.ProductID.ToString();
                NameTextBox.Text = product.Name.ToString();
                PriceTextBox.Text = product.Price.ToString();
                InventoryTextBox.Text = product.InStock.ToString();
                MinTextBox.Text = product.Min.ToString();
                MaxTextBox.Text = product.Max.ToString();

                for (int i = 0; i < product.AssociatedParts.Count; i++)
                {
                    Part productpart = product.AssociatedParts[i];

                    for (int j = 0; j < Inventory.Parts.Count; j++)
                    {
                        Part part = Inventory.Parts[j];
                        Inventory.ReplacePart(part, productpart);
                    }
                }
                tempList = new BindingList<Part>();
                for (int i = 0; i < product.AssociatedParts.Count; i++)
                {
                    tempList.Add(product.AssociatedParts[i]);
                }
            }
            else
            {
                product = new Product
                {
                    AssociatedParts = new BindingList<Part>()
                };

            }
            dataGridView2.DataSource = product.AssociatedParts;
        }

        private void SetdataGridView1Index()
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                Inventory.SelectedPartIndex = row.Index;
            }
            else
            {
                Inventory.SelectedPartIndex = -1;
            }
        }

        private void SetdataGridView2Index()
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView2.SelectedRows[0];
                Inventory.SelectedPartIndex = row.Index;
            }
            else
            {
                Inventory.SelectedPartIndex = -1;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            SetdataGridView1Index();
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Yellow;
        }

    
        private void ModifyProduct_Load(object sender, EventArgs e)
        {
            
            
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingList<Part> FoundPartList = new BindingList<Part>();
            
            if (SearchTextBox.Text != "")
            {
                for (int i = 0; i < Inventory.Parts.Count; i++)
                {
                    if (Inventory.Parts[i].Name.ToUpper().Contains(SearchTextBox.Text.ToUpper()))
                    {
                        FoundPartList.Add(Inventory.Parts[i]);
                        Inventory.CurrentPart = Inventory.Parts[i];
                        found = true;
                       
                    }
                }
                if (found)
                    dataGridView1.DataSource = FoundPartList;
            }
            if (!found)
            {
                MessageBox.Show("Sorry. No Part Found.");
                dataGridView1.DataSource = Inventory.Parts;
            }
        }

        private void ResetSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Inventory.Parts;
            dataGridView1.ClearSelection();
            found = false;
        }

        private void SearchEnter_TextChanged(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "Search Part Name Here...")
            {
                SearchTextBox.Text = "";

            }
        }
        private void SearchLeave_TextChanged(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "")
            {
                SearchTextBox.Text = "Search Part Name Here...";

            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

            SetdataGridView1Index();

            if (found)
            {
              
                
                product.AssociatedParts.Add(Inventory.CurrentPart);
                
            
            }
           
                  
            else if (Inventory.SelectedPartIndex >= 0)
            {
                Inventory.CurrentPart = Inventory.Parts[Inventory.SelectedPartIndex];
                product.AssociatedParts.Add(Inventory.CurrentPart);
            }
            else
            {
                MessageBox.Show("Please select a part to add.");
            }
            
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SetdataGridView2Index();
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Yellow;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SetdataGridView2Index();
            if (Inventory.SelectedPartIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this part?", "", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    product.AssociatedParts.RemoveAt(Inventory.SelectedPartIndex);
                }
            }
            else
            {
                MessageBox.Show("Please select a part to delete.");
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.allowSave())
            {
                if (product.ProductID == -1)
                {
                    CreateNewProduct();
                }
                else
                {
                    modifyProduct();
                }
                this.Close();
                this.Hide();
                MainScreen Main = new MainScreen();
                Main.Show();
            }

        }

        void CreateNewProduct()
        {
            Product newProduct = new Product(NameTextBox.Text,
            Convert.ToDecimal(PriceTextBox.Text), Convert.ToInt32(InventoryTextBox.Text),
            Convert.ToInt32(MinTextBox.Text), Convert.ToInt32(MaxTextBox.Text));

            Inventory.AddProduct(newProduct);
            newProduct.AssociatedParts = product.AssociatedParts;
        }
        private void modifyProduct()
        {
            product.Name = NameTextBox.Text;
            product.Price = Convert.ToDecimal(PriceTextBox.Text);
            product.InStock = Convert.ToInt32(InventoryTextBox.Text);
            product.Min = Convert.ToInt32(MinTextBox.Text);
            product.Max = Convert.ToInt32(MaxTextBox.Text);

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {

            product.AssociatedParts = tempList;
            this.Close();
            this.Hide();
            MainScreen Main = new MainScreen();
            Main.Show();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            bool ValidName = ValidateFields.IsNotNullOrWhiteSpace(NameTextBox.Text);
            ValidateFields.ValidateField(NameTextBox, ValidName);
          
        }

        private void PriceTextBox_TextChanged(object sender, EventArgs e)
        {
            bool ValidPrice = ValidateFields.IsDecimal(PriceTextBox.Text);
            ValidateFields.ValidateField(PriceTextBox, ValidPrice);
           
        }

        private void InventoryTextBox_TextChanged(object sender, EventArgs e)
        {
            bool ValidInventory = ValidateFields.IsInt(InventoryTextBox.Text) &&
            ValidateFields.InvBetweenMinMax(InventoryTextBox.Text, MinTextBox.Text, MaxTextBox.Text);
            ValidateFields.ValidateField(InventoryTextBox, ValidInventory);
            ValidateFields.ValidateField(MinTextBox, ValidInventory);
            ValidateFields.ValidateField(MaxTextBox, ValidInventory);
           
        }


        private void MinTextBox_TextChanged(object sender, EventArgs e)
        {
            bool ValidMin = ValidateFields.IsInt(MinTextBox.Text) &&
            ValidateFields.InvBetweenMinMax(InventoryTextBox.Text, MinTextBox.Text, MaxTextBox.Text);
            ValidateFields.ValidateField(MinTextBox, ValidMin);
            ValidateFields.ValidateField(MaxTextBox, ValidMin);
            ValidateFields.ValidateField(InventoryTextBox, ValidMin);
        }

        private void MaxTextBox_TextChanged(object sender, EventArgs e)
        {
            bool ValidMax = ValidateFields.IsInt(MaxTextBox.Text) &&
            ValidateFields.InvBetweenMinMax(InventoryTextBox.Text, MinTextBox.Text, MaxTextBox.Text);
            ValidateFields.ValidateField(MaxTextBox, ValidMax);
            ValidateFields.ValidateField(MinTextBox, ValidMax);
            ValidateFields.ValidateField(InventoryTextBox, ValidMax);
          

        }

     
    }
}
