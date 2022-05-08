using System;
using System.ComponentModel;
using System.Linq;

namespace ThuyTienNguyen_C968_InventoryManagement.Models
{


    public class Product
    {


        public BindingList<Part> AssociatedParts = new BindingList<Part>();
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public static int count = 1;
        
        public Product(string name, decimal price, int inStock, int min, int max)
        {
            ProductID = count++;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;

        }

        public Product()
        {
            ProductID = -1;
            Name = "name";
            Price = 0;
            InStock = 0;
            Min = 0;
            Max = 0;

        }

        public void AddAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);
        }

        public bool RemoveAssociatedPart(int PartID)
        {
            var partToRemove = AssociatedParts.Where(p => p.PartID == PartID).FirstOrDefault();
            if (partToRemove == null)
                throw new Exception(message: $"A part with ID #{PartID} is not associated with this product.");

            AssociatedParts.Remove(partToRemove);
            return true;
        }


        public Part LookupAssociatedPart(int PartID)
        {
            var part = AssociatedParts.Where(p => p.PartID == PartID).FirstOrDefault();

            if (part == null)
                throw new Exception(message: $"A part with ID #{PartID} is not associated with this product.");

            return part;
        }

    }
}
