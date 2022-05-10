using System;
using System.ComponentModel;
using System.Windows.Forms;
using ThuyTienNguyen_C968_InventoryManagement.Models;

namespace ThuyTienNguyen_C968_InventoryManagement
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();

            Inventory.SelectedPartIndex = -1;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.DataSource = Inventory.Parts;


            Inventory.SelectedProductIndex = -1;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            dataGridView2.RowHeadersVisible = true;
            dataGridView2.DataSource = Inventory.Products;
        }

        private void SetSelectedPartIndex()
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

        private void SetSelectedProductIndex()
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView2.SelectedRows[0];
                Inventory.SelectedProductIndex = row.Index;
            }
            else
            {
                Inventory.SelectedProductIndex = -1;
            }
        }


        private void MainScreen_Load(object sender, EventArgs e)
        {


            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();

        }

        private void Grid1Search_Click(object sender, EventArgs e)
        {
            BindingList<Part> TempPartList = new BindingList<Part>();
            bool found = false;
            if (searchTextBox1.Text != "")
            {
                for (int i = 0; i < Inventory.Parts.Count; i++)
                {
                    if (Inventory.Parts[i].Name.ToUpper().Contains(searchTextBox1.Text.ToUpper()))
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
                MessageBox.Show("Sorry. No Part Found.");
                dataGridView1.DataSource = Inventory.Parts;
            }

        }


        private void ResetGrid1Search_TextChanged(object sender, EventArgs e)
        {

            dataGridView1.DataSource = Inventory.Parts;
            dataGridView1.ClearSelection();

        }

        private void Grid1SearchEnter_TextChanged(object sender, EventArgs e)
        {
            if (searchTextBox1.Text == "Search Part Name Here...")
            {
                searchTextBox1.Text = "";

            }
        }
        private void Grid1SearchLeave_TextChanged(object sender, EventArgs e)
        {
            if (searchTextBox1.Text == "")
            {
                searchTextBox1.Text = "Search Part Name Here...";

            }
        }

        private void Grid2Search_Click(object sender, EventArgs e)
        {
            BindingList<Product> TempPartList = new BindingList<Product>();
            bool found = false;
            if (searchTextBox2.Text != "")
            {
                for (int i = 0; i < Inventory.Products.Count; i++)
                {
                    if (Inventory.Products[i].Name.ToUpper().Contains(searchTextBox2.Text.ToUpper()))
                    {
                        TempPartList.Add(Inventory.Products[i]);
                        found = true;
                    }
                }
                if (found)
                    dataGridView2.DataSource = TempPartList;
            }
            if (!found)
            {
                MessageBox.Show("Sorry. No Product Found.");
                dataGridView2.DataSource = Inventory.Products;
            }

        }


        private void ResetGrid2Search_TextChanged(object sender, EventArgs e)
        {

            dataGridView2.DataSource = Inventory.Products;
            dataGridView2.ClearSelection();
        }


        private void Grid2SearchEnter_TextChanged(object sender, EventArgs e)
        {
            if (searchTextBox2.Text == "Search Product Name Here...")
            {
                searchTextBox2.Text = "";

            }
        }
        private void Grid2SearchLeave_TextChanged(object sender, EventArgs e)
        {
            if (searchTextBox2.Text == "")
            {
                searchTextBox2.Text = "Search Product Name Here...";

            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SetSelectedPartIndex();
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Yellow;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SetSelectedProductIndex();
            dataGridView2.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Yellow;

        }

        private void Grid1Add_Click(object sender, EventArgs e)
        {

            Inventory.CurrentPart = null;
            AddPart AddPartForm = new AddPart();
            AddPartForm.Show();
            this.Hide();
        }

        private void Grid1Modify_Click(object sender, EventArgs e)
        {
            SetSelectedPartIndex();
            if (Inventory.SelectedPartIndex >= 0)
            {
                Inventory.CurrentPart = Inventory.Parts[Inventory.SelectedPartIndex];
                this.Hide();
                ModifyPart ModifyPartForm = new ModifyPart();
                ModifyPartForm.Show();
            }
            else
            {
                MessageBox.Show("Please select something to modify.");
            }

        }


        private void Grid1Delete_Click(object sender, EventArgs e)
        {
            SetSelectedPartIndex();
            if (Inventory.SelectedPartIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this part?", "", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Inventory.Parts.RemoveAt(Inventory.SelectedPartIndex);
                }
            }
            else
            {
                MessageBox.Show("Please select a part to delete.");
            }

        }

        private void Grid2Add_Click(object sender, EventArgs e)
        {

            Inventory.CurrentProduct = null;
            AddProduct AddProductForm = new AddProduct();
            AddProductForm.Show();
            this.Hide();
        }

        private void Grid2Modify_Click(object sender, EventArgs e)
        {
            SetSelectedProductIndex();
            if (Inventory.SelectedProductIndex >= 0)
            {
                Inventory.CurrentProduct = Inventory.Products[Inventory.SelectedProductIndex];
                this.Hide();
                ModifyProduct ModifyProductForm = new ModifyProduct();
                ModifyProductForm.Show();
            }
            else
            {
                MessageBox.Show("Please select something to modify.");
            }

        }


        private void Grid2Delete_Click(object sender, EventArgs e)
        {
            SetSelectedProductIndex();

            if (Inventory.SelectedProductIndex >= 0)
            {
                Inventory.CurrentProduct = Inventory.Products[Inventory.SelectedProductIndex];
                if (Inventory.CurrentProduct.AssociatedParts.Count == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this product?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Inventory.Products.RemoveAt(Inventory.SelectedProductIndex);
                    }
                }
                else
                {
                    MessageBox.Show("Cannot delete product with parts associated.");
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
