namespace ThuyTienNguyen_C968_InventoryManagement.Models
{
    public class Inhouse : Part
    {

        public int MachineID { get; set; }
        public Inhouse(string name, decimal price, int inStock, int min, int max, int machineID)
            : base(name, price, inStock, min, max)
        {
            MachineID = machineID;
        }

        public Inhouse(int id, string name, decimal price, int inStock, int min, int max, int machineID)
           : base(id, name, price, inStock, min, max)
        {
            MachineID = machineID;
        }
        

    }
}
