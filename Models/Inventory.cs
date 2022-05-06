using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;


namespace ThuyTienNguyen_C968_InventoryManagement.Models
{
    public class Inventory
    {
       

        // Properties
        public static BindingList<Product> Products = new BindingList<Product>();
        public static BindingList<Part> Parts = new BindingList<Part>();

        public static Part CurrentPart { get; set; }
        public static int CurrentPartID { get; set; }
        public static int SelectedPartIndex { get; set; }


        public static Product CurrentProduct { get; set; }
        public static int CurrentProductID { get; set; }
        public static int SelectedProductIndex { get; set; }


        internal static void Swap(Part Part)
        {
            Parts.Insert(SelectedPartIndex, Part);
            Parts.RemoveAt(SelectedPartIndex + 1);
        }
        //--------------------Product Methods---------------------//

        // add new products
        public static void AddProduct(Product Product)
        {
            Products.Add(Product);
        }

        // iterate through Products list and remove products if the ProductID is a match
        public static bool RemoveProduct(int ProductID) // bind to remove button
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

        // iterate through Products list and return it if found, else display not found
        public static Product LookupProduct(int ProductID)  //bind to search button
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

        // iterate through Products list and update Product fields with user arguments
        public static void UpdateProduct(int SelectedProductIndex, Product CurrentProduct) // bind to save button
        {
            Products.Insert(SelectedProductIndex, CurrentProduct);
            Products.RemoveAt(SelectedProductIndex);
        }
        //--------------------Part Methods---------------------//

        public static void AddPart(Part part)
        {
            Parts.Add(part);
        }

        // iterate through Parts list and remove products if the partID is a match
        public static bool DeletePart(Part part) // bind to remove button
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

        // iterate through Parts list and return it if found, else display not found
        public static Part LookupPart(int PartID)  //bind to search button
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

        // iterate through Parts list and update Part fields with user arguments
        public static void UpdatePart(int PartID, Part part) // bind to save button
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
