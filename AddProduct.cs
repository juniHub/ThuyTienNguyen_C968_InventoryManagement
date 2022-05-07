using System;
using System.ComponentModel;
using System.Windows.Forms;
using ThuyTienNguyen_C968_InventoryManagement.Models;

namespace ThuyTienNguyen_C968_InventoryManagement
{
    public partial class AddProduct : Form
    {
        private Product product;
        private BindingList<Part> tempList;

        private bool allowSave()
        {
            if (!ValidateFields.IsNotNullOrWhiteSpace(NameTextBox.Text))
            {
                return false;
            }
            if (!ValidateFields.IsDecimal(InventoryTextBox.Text))
            {
                return false;
            }
            if (!ValidateFields.IsInt(InventoryTextBox.Text))
            {
                return false;
            }
            if (!ValidateFields.IsInt(MinTextBox.Text))
            {
                return false;
            }
            if (!ValidateFields.InvBetweenMinMax(InventoryTextBox.Text, MinTextBox.Text, MaxTextBox.Text))
            {
                return false;
            }
            if (!ValidateFields.IsInt(MaxTextBox.Text))
            {
                return false;
            }
            return true;
        }

        public AddProduct()
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
                InventoryTextBox.Text = product.Price.ToString();
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
                product = new Product();
                product.AssociatedParts = new BindingList<Part>();

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


        private void AddProduct_Load(object sender, EventArgs e)
        {
           
            // Call clearSelection 
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();

        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingList<Part> TempPartList = new BindingList<Part>();
            bool found = false;
            if (SearchTextBox.Text != "")
            {
                for (int i = 0; i < Inventory.Parts.Count; i++)
                {
                    if (Inventory.Parts[i].Name.ToUpper().Contains(SearchTextBox.Text.ToUpper()))
                    {
                        TempPartList.Add(Inventory.Parts[i]);
                        found = true;
                    }
                }
                if (found)
                    dataGridView1.DataSource = TempPartList;
            }
            if (!found)
            {
                MessageBox.Show("Sory, No Results Found.");
                dataGridView1.DataSource = Inventory.Parts;
            }
        }


   
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SetdataGridView1Index();
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Yellow;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetdataGridView1Index();
            if (Inventory.SelectedPartIndex >= 0)
            {
                Inventory.CurrentPart = Inventory.Parts[Inventory.SelectedPartIndex];
                product.AssociatedParts.Add(Inventory.CurrentPart);
            }
            else
            {
                MessageBox.Show("Please select a part to add.");
            }
            btnSave.Enabled = allowSave();
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
            btnSave.Enabled = allowSave();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (product.ProductID == -1)
            {
                CreateNewProduct();
            }

            this.Close();
            this.Hide();
            MainScreen Main = new MainScreen();
            Main.Show();
        }

        void CreateNewProduct()
        {
            Product newProduct = new Product(NameTextBox.Text,
            Convert.ToDecimal(InventoryTextBox.Text), Convert.ToInt32(InventoryTextBox.Text),
            Convert.ToInt32(MinTextBox.Text), Convert.ToInt32(MaxTextBox.Text));

            Inventory.AddProduct(newProduct);
            newProduct.AssociatedParts = product.AssociatedParts;
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
            btnSave.Enabled = allowSave();
        }

        private void PriceTextBox_TextChanged(object sender, EventArgs e)
        {
            bool ValidPrice = ValidateFields.IsDecimal(InventoryTextBox.Text);
            ValidateFields.ValidateField(InventoryTextBox, ValidPrice);
            btnSave.Enabled = allowSave();
        }


        private void InventoryTextBox_TextChanged(object sender, EventArgs e)
        {
            bool ValidInventory = ValidateFields.IsInt(InventoryTextBox.Text) &&
            ValidateFields.InvBetweenMinMax(InventoryTextBox.Text, MinTextBox.Text, MaxTextBox.Text);
            ValidateFields.ValidateField(InventoryTextBox, ValidInventory);
            ValidateFields.ValidateField(MinTextBox, ValidInventory);
            ValidateFields.ValidateField(MaxTextBox, ValidInventory);

            btnSave.Enabled = allowSave();
        }

        private void MinTextBox_TextChanged(object sender, EventArgs e)
        {
            bool ValidMin = ValidateFields.IsInt(MinTextBox.Text) &&
            ValidateFields.InvBetweenMinMax(InventoryTextBox.Text, MinTextBox.Text, MaxTextBox.Text);
            ValidateFields.ValidateField(MinTextBox, ValidMin);
            ValidateFields.ValidateField(InventoryTextBox, ValidMin);
            btnSave.Enabled = allowSave();
        }

        private void MaxTextBox_TextChanged(object sender, EventArgs e)
        {
            bool ValidMax = ValidateFields.IsInt(MaxTextBox.Text) &&
            ValidateFields.InvBetweenMinMax(InventoryTextBox.Text, MinTextBox.Text, MaxTextBox.Text);
            ValidateFields.ValidateField(MaxTextBox, ValidMax);
            ValidateFields.ValidateField(InventoryTextBox, ValidMax);
            btnSave.Enabled = allowSave();
        }

    }
}
