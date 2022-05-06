using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThuyTienNguyen_C968_InventoryManagement.Models;

namespace ThuyTienNguyen_C968_InventoryManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Inhouse wheel = new Inhouse("Wheel", 12.11M, 15, 5, 25, 111);
            Inhouse pedal = new Inhouse("Pedal", 8.22M, 11, 5, 25, 121);
            Outsourced chain = new Outsourced("Chain", 8.33M, 12, 5, 25, "Juni");
            Outsourced seat = new Outsourced("Seat", 4.55M, 8, 2, 15, "Juni");

            Product redbicycle = new Product("Red Bicycle", 11.44M, 15, 1, 25);
            Product yellowbicycle = new Product("Yellow Bicycle", 9.66M, 19, 1, 20);
            Product bluebicycle = new Product("Blue Bicycle", 12.77M, 5, 1, 25);

            Inventory.Parts.Add(wheel);
            Inventory.Parts.Add(pedal);
            Inventory.Parts.Add(chain);
            Inventory.Parts.Add(seat);

            Inventory.Products.Add(redbicycle);
            Inventory.Products.Add(yellowbicycle);
            Inventory.Products.Add(bluebicycle);

            redbicycle.AssociatedParts.Add(wheel);
            redbicycle.AssociatedParts.Add(pedal);
            redbicycle.AssociatedParts.Add(chain);
            redbicycle.AssociatedParts.Add(seat);

            yellowbicycle.AssociatedParts.Add(wheel);
            yellowbicycle.AssociatedParts.Add(pedal);
            yellowbicycle.AssociatedParts.Add(chain);
            yellowbicycle.AssociatedParts.Add(seat);

            bluebicycle.AssociatedParts.Add(wheel);
            bluebicycle.AssociatedParts.Add(pedal);
            bluebicycle.AssociatedParts.Add(chain);
            bluebicycle.AssociatedParts.Add(seat);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());
        }
    }
}
