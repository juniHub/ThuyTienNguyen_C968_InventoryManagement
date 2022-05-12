using System;
using System.Windows.Forms;
using ThuyTienNguyen_C968_InventoryManagement.Models;

namespace ThuyTienNguyen_C968_InventoryManagement
{
    public partial class ModifyPart : Form
    {
        private bool isInhouse;
        private Part part;
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

           
            if (isInhouse)
            {
                if (!ValidateFields.IsInt(MachineIDTextBox.Text))
                {

                    MessageBox.Show("Machine ID must be a number");
                    return false;
                }
            }

            if (!ValidateFields.IsNotNullOrWhiteSpace(MachineIDTextBox.Text))
            {
                MessageBox.Show("this field must not be blank");
                return false;
            }

            return true;
        }

        public ModifyPart()
        {
            InitializeComponent();
            part = Inventory.CurrentPart;

            if (part != null)
            {
                IDTextBox.Text = part.PartID.ToString();
                NameTextBox.Text = part.Name.ToString();
                PriceTextBox.Text = part.Price.ToString();
                InventoryTextBox.Text = part.InStock.ToString();
                MinTextBox.Text = part.Min.ToString();
                MaxTextBox.Text = part.Max.ToString();

                if (Inventory.CurrentPart is Inhouse)
                {
                    Inhouse e = (Inhouse)part;
                    MachineIDTextBox.Text = e.MachineID.ToString();
                    isInhouse = true;
                    btnInHouse.Checked = true;

                }
                else
                {
                    Outsourced e = (Outsourced)part;
                    MachineIDTextBox.Text = e.CompanyName;
                    isInhouse = false;
                    btnOutsourced.Checked = true;
                }
            }


        }
     
        private void btnInHouse_CheckedChanged(object sender, EventArgs e)
        {
            Label.Text = "Machine ID";
            isInhouse = true;
            bool ValidMachineID = ValidateFields.IsInt(MachineIDTextBox.Text);
            ValidateFields.ValidateField(MachineIDTextBox, ValidMachineID);
           
        }

        private void btnOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            Label.Text = "Company Name";
            isInhouse = false;
            bool NotEmpty = ValidateFields.IsNotNullOrWhiteSpace(MachineIDTextBox.Text);
            ValidateFields.ValidateField(MachineIDTextBox, NotEmpty);
         
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
            {
                bool ValidInventory = ValidateFields.IsInt(InventoryTextBox.Text) &&
                ValidateFields.InvBetweenMinMax(InventoryTextBox.Text, MinTextBox.Text, MaxTextBox.Text);
                ValidateFields.ValidateField(InventoryTextBox, ValidInventory);
                ValidateFields.ValidateField(MinTextBox, ValidInventory);
                ValidateFields.ValidateField(MaxTextBox, ValidInventory);


            }
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

        private void MachineIDtextBox_TextChanged(object sender, EventArgs e)
        {
            if (isInhouse)
            {
                bool MachineID = ValidateFields.IsInt(MachineIDTextBox.Text);
                ValidateFields.ValidateField(MachineIDTextBox, MachineID);
            }
            else
            {
                bool CompanyName = ValidateFields.IsNotNullOrWhiteSpace(MachineIDTextBox.Text);
                ValidateFields.ValidateField(MachineIDTextBox, CompanyName);
            }

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
            this.Hide();
            MainScreen Main = new MainScreen();
            Main.Show();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (this.allowSave())
            {

                if (part == null)
                {
                    CreateNewPart();
                }
                else
                {
                    UpdatePart();
                }

                this.Hide();
                MainScreen Main = new MainScreen();
                Main.Show();

            }

        }

        private void CreateNewPart()
        {
            if (isInhouse)
            {
                Inhouse inhousePart = new Inhouse(NameTextBox.Text, Convert.ToDecimal(PriceTextBox.Text),
                Convert.ToInt32(InventoryTextBox.Text), Convert.ToInt32(MinTextBox.Text),
                Convert.ToInt32(MaxTextBox.Text), Convert.ToInt32(MachineIDTextBox.Text));
                Inventory.AddPart(inhousePart);
            }
            else
            {
                Outsourced outsourcedPart = new Outsourced(NameTextBox.Text, Convert.ToDecimal(PriceTextBox.Text),
                Convert.ToInt32(InventoryTextBox.Text), Convert.ToInt32(MinTextBox.Text),
                Convert.ToInt32(MaxTextBox.Text), MachineIDTextBox.Text);
                Inventory.AddPart(outsourcedPart);
            }

        }

        private void UpdatePart()
        {
            if (isInhouse)
            {
                Inhouse inhousePart = new Inhouse(Convert.ToInt32(IDTextBox.Text), NameTextBox.Text, Convert.ToDecimal(PriceTextBox.Text), Convert.ToInt32(InventoryTextBox.Text),
                Convert.ToInt32(MinTextBox.Text), Convert.ToInt32(MaxTextBox.Text), Convert.ToInt32(MachineIDTextBox.Text));
                Inventory.Swap(inhousePart);
            }
            else
            {
                Outsourced outsourcedPart = new Outsourced(Convert.ToInt32(IDTextBox.Text), NameTextBox.Text, Convert.ToDecimal(PriceTextBox.Text), Convert.ToInt32(InventoryTextBox.Text),
                Convert.ToInt32(MinTextBox.Text), Convert.ToInt32(MaxTextBox.Text), MachineIDTextBox.Text);
                Inventory.Swap(outsourcedPart);
            }
            btnSave.Enabled = allowSave();
        }

      
     

        
    }
}
