using System;
using System.Windows.Forms;
using ThuyTienNguyen_C968_InventoryManagement.Models;

namespace ThuyTienNguyen_C968_InventoryManagement
{
    public partial class AddPart : Form
    {
        private bool isInhouse;
        private Part part;

        private bool allowSave()
        {
            if (!ValidateFields.IsNotNullOrWhiteSpace(NameTextBox.Text))
            {
                return false;
            }

            if (!ValidateFields.IsDecimal(PriceTextBox.Text))
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

            if (!ValidateFields.IsInt(MaxTextBox.Text))
            {
                return false;
            }

            if (!ValidateFields.InvBetweenMinMax(InventoryTextBox.Text, MinTextBox.Text, MaxTextBox.Text))
            {
                return false;
            }

            if (isInhouse)
            {
                if (!ValidateFields.IsInt(MachineIDTextBox.Text))
                {
                    return false;
                }
            }

            if (!ValidateFields.IsNotNullOrWhiteSpace(MachineIDTextBox.Text))
            {
                return false;
            }

            return true;

        }

        public AddPart()
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
                    Inhouse inhousePart = (Inhouse)part;
                    MachineIDTextBox.Text = inhousePart.MachineID.ToString();
                    isInhouse = true;
                    btnInHouse.Checked = true;

                }
                else
                {
                    Outsourced outsourcedPart = (Outsourced)part;
                    MachineIDTextBox.Text = outsourcedPart.CompanyName;
                    isInhouse = false;
                    btnOutsourced.Checked = true;
                }
            }

        }


        private void MaxTextBox_TextChanged(object sender, EventArgs e)
        {
            bool validMax = ValidateFields.InvBetweenMinMax(InventoryTextBox.Text, MinTextBox.Text, MaxTextBox.Text) &&
            ValidateFields.IsInt(MaxTextBox.Text);
            ValidateFields.ValidateField(MaxTextBox, validMax);
            ValidateFields.ValidateField(InventoryTextBox, validMax);
            if (!validMax)
            {
                MessageBox.Show("Max in not invalid range");
            }

            btnSave.Enabled = allowSave();
        }

        private void btnInHouse_CheckedChanged(object sender, EventArgs e)
        {
            Label.Text = "Machine ID";
            isInhouse = true;
            bool ValidMachineID = ValidateFields.IsInt(MachineIDTextBox.Text);
            ValidateFields.ValidateField(MachineIDTextBox, ValidMachineID);
            btnSave.Enabled = allowSave();
        }

        private void btnOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            Label.Text = "Company Name";
            isInhouse = false;
            bool NotEmpty = ValidateFields.IsNotNullOrWhiteSpace(MachineIDTextBox.Text);
            ValidateFields.ValidateField(MachineIDTextBox, NotEmpty);
            btnSave.Enabled = allowSave();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (part == null)
            {
                CreateNewPart();
            }
            this.Close();
            this.Hide();
            MainScreen Main = new MainScreen();
            Main.Show();
        }

        void CreateNewPart()
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
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



        private void InventoryTextBox_TextChanged(object sender, EventArgs e)
        {
            {
                bool ValidInventory = ValidateFields.IsInt(InventoryTextBox.Text) &&
                ValidateFields.InvBetweenMinMax(InventoryTextBox.Text, MinTextBox.Text, MaxTextBox.Text);

                ValidateFields.ValidateField(InventoryTextBox, ValidInventory);
                ValidateFields.ValidateField(MinTextBox, ValidInventory);
                ValidateFields.ValidateField(MaxTextBox, ValidInventory);


                btnSave.Enabled = allowSave();
            }

        }
        private void PriceTextBox_TextChanged(object sender, EventArgs e)
        {
            bool ValidPrice = ValidateFields.IsDecimal(PriceTextBox.Text);
            ValidateFields.ValidateField(PriceTextBox, ValidPrice);
            btnSave.Enabled = allowSave();

        }
        private void MinTextBox_TextChanged(object sender, EventArgs e)
        {
            bool ValidMin = ValidateFields.InvBetweenMinMax(InventoryTextBox.Text, MinTextBox.Text, MaxTextBox.Text) &&
            ValidateFields.IsInt(MinTextBox.Text);
            ValidateFields.ValidateField(MinTextBox, ValidMin);
            ValidateFields.ValidateField(InventoryTextBox, ValidMin);
            btnSave.Enabled = allowSave();
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
            btnSave.Enabled = allowSave();

        }

       

    }
}
