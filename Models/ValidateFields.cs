using System;
using System.Windows.Forms;

namespace ThuyTienNguyen_C968_InventoryManagement.Models
{
    class ValidateFields
    {
        public static bool IsInt(string text)
        {
            return IsNotNullOrWhiteSpace(text) && Int32.TryParse(text, out _);
        }
        public static bool IsNotNullOrWhiteSpace(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }

        public static bool IsDecimal(string text)
        {
            return IsNotNullOrWhiteSpace(text) &&
                Decimal.TryParse(text, out _);
        }

        public static bool InvBetweenMinMax(string inv, string min, string max)
        {
         

            Int32.TryParse(inv, out int inStock);
            Int32.TryParse(max, out int maxInv);
            Int32.TryParse(min, out int minInv);

            return (maxInv >= inStock) && (minInv <= inStock);
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
