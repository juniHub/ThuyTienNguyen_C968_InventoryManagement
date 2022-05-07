namespace ThuyTienNguyen_C968_InventoryManagement.Models
{
    public abstract class Part
    {
        public static int count = 1;

        public int PartID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public Part(string name, decimal price, int inStock, int min, int max)
        {
            PartID = count++;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
        }

        public Part(int partID, string name, decimal price, int inStock, int min, int max)
        {
            PartID = partID;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
        }

        

    }

}
