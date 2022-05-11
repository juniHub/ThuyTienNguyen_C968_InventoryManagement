using System.ComponentModel;
using System.Windows.Forms;


namespace ThuyTienNguyen_C968_InventoryManagement.Models
{
    public class Inventory
    {


        //--------------------Properties---------------------//

        public static BindingList<Product> Products = new BindingList<Product>();
        public static BindingList<Part> Parts = new BindingList<Part>();

        public static Part CurrentPart { get; set; }
        public static int CurrentPartID { get; set; }
        public static int SelectedPartIndex { get; set; }


        public static Product CurrentProduct { get; set; }
        public static int CurrentProductID { get; set; }
        public static int SelectedProductIndex { get; set; }

      

        //--------------------Product Methods---------------------//

        // add new product
        public static void AddProduct(Product Product)
        {
            Products.Add(Product);
        }

        // remove product
        public static bool RemoveProduct(int ProductID) 
        {
            bool check = false;
            foreach (Product p in Products)
            {
                if (ProductID == p.ProductID)

                {
                    Products.Remove(p);
                    check = true;
                }
                else
                {
                    MessageBox.Show("Product does not Exist");
                    check = false;
                }
            }
            return check;
        }

        // search product
        public static Product LookupProduct(int ProductID) 
        {
            foreach (Product p in Products)
            {
                if (p.ProductID == ProductID)
                {
                    return p;
                }
            }
            return null;
        }

        // update product
        public static void UpdateProduct(int SelectedProductIndex, Product CurrentProduct) 
        {
            Products.Insert(SelectedProductIndex, CurrentProduct);
            Products.RemoveAt(SelectedProductIndex);
        }

        //--------------------Part Methods---------------------//


        //add part
        public static void AddPart(Part part)
        {
            Parts.Add(part);
        }

        //delete part
        public static bool DeletePart(Part part) 
        {
            bool check = false;
            foreach (Part p in Parts)
            {
                if (p.PartID == part.PartID)
                {
                    Parts.Remove(p);
                    check = true;
                }
                else
                {
                    MessageBox.Show("Part does not Exist");
                    check = false;
                }
            }
            return check;
        }

        //search part
        public static Part LookupPart(int PartID) 
        {
            foreach (Part p in Parts)
            {
                if (p.PartID == PartID)
                {
                    return p;
                }
            }
            return null;
        }

        //update part
        public static void UpdatePart(int PartID, Part part) 
        {
            foreach (Part p in Parts)
            {
                if (p.PartID == PartID)
                {
                    p.PartID = part.PartID;
                    p.Name = part.Name;
                    p.Price = part.Price;
                    p.InStock = part.InStock;
                    p.Min = part.Min;
                    p.Max = part.Max;
                    return;
                }
            }
        }

        //--------------------Helper Methods---------------------//
        internal static void Swap(Part Part)
        {
            Parts.Insert(SelectedPartIndex, Part);
            Parts.RemoveAt(SelectedPartIndex + 1);
        }

        
        public static void ReplacePart(Part part, Part product_part)
        {
            int partId = part.PartID;
            int product_partId = product_part.PartID;

            string partName = part.Name;
            string product_partName = product_part.Name;

            decimal partPrice = part.Price;
            decimal product_partPrice = product_part.Price;

            int partInstock = part.InStock;
            int product_partInstock = product_part.InStock;

            int partMin = part.Min;
            int product_partMin = product_part.Min;

            int partMax = part.Max;
            int product_partMax = product_part.Max;

            if (partId == product_partId)
            {
                if ((partName != product_partName) ||
                    (partPrice != product_partPrice) ||
                    (partInstock != product_partInstock) ||
                    (partMin != product_partMin) ||
                    (partMax != product_partMax))
                {
                    CurrentProduct.AssociatedParts.Remove(product_part);
                    CurrentProduct.AssociatedParts.Add(part);
                }
            }
        }
    }
}
