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

        //helper method
        internal static void Swap(Part Part)
        {
            Parts.Insert(SelectedPartIndex, Part);
            Parts.RemoveAt(SelectedPartIndex + 1);
        }

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

        //replace part
        public static void ReplacePart(Part part, Part productpart)
        {
            int partid = part.PartID;
            int productpartid = productpart.PartID;

            string partname = part.Name;
            string productpartname = productpart.Name;

            decimal partprice = part.Price;
            decimal productpartprice = productpart.Price;

            int partinstock = part.InStock;
            int productpartinstock = productpart.InStock;

            int partmin = part.Min;
            int productpartmin = productpart.Min;

            int partmax = part.Max;
            int productpartmax = productpart.Max;

            if (partid == productpartid)
            {
                if ((partname != productpartname) ||
                    (partprice != productpartprice) ||
                    (partinstock != productpartinstock) ||
                    (partmin != productpartmin) ||
                    (partmax != productpartmax))
                {
                    CurrentProduct.AssociatedParts.Remove(productpart);
                    CurrentProduct.AssociatedParts.Add(part);
                }
            }
        }
    }
}
