using System;
using System.Windows.Forms;

namespace ThuyTienNguyen_C968_InventoryManagement.Models
{
    class ValidateFields
    {
        public static bool IsInt(string text)
        {
            int number;

         
            return IsNotNullOrWhiteSpace(text) &&
                Int32.TryParse(text, out number);
        }
        public static bool IsNotNullOrWhiteSpace(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }

        public static bool IsDecimal(string text)
        {
            decimal dec;
            return IsNotNullOrWhiteSpace(text) &&
                Decimal.TryParse(text, out dec);
        }

        public static bool InvBetweenMinMax(string inv, string min, string max)
        {
            int inStock;
            int minInv;
            int maxInv;

            Int32.TryParse(inv, out inStock);
            Int32.TryParse(max, out maxInv);
            Int32.TryParse(min, out minInv);

            return (maxInv >= inStock) && (minInv <= inStock);
        }

        public static bool ValidMin(string min, string max)
        {
            
            int minInv;
            int maxInv;

            
            Int32.TryParse(min, out minInv);
            Int32.TryParse(max, out maxInv);



            return (minInv <= maxInv) ;
        }

        public static void ValidateField(TextBox field, bool isValid)
        {
            if (isValid)
            {
                field.BackColor = System.Drawing.Color.White;
            }
            else
            {
                field.BackColor = System.Drawing.Color.Salmon;
            }
        }

    }
}
