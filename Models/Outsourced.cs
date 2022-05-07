namespace ThuyTienNguyen_C968_InventoryManagement.Models
{
    public class Outsourced : Part
    {

        public string CompanyName { get; set; }
        public Outsourced(string name, decimal price, int inStock, int min, int max, string companyName)
            : base(name, price, inStock, min, max)
        {
            CompanyName = companyName;
        }

        public Outsourced(int id, string name, decimal price, int inStock, int min, int max, string companyName)
           : base(id, name, price, inStock, min, max)
        {
            CompanyName = companyName;
        }
       

    }
}
