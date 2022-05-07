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

        public static bool InvBetweenMinMax(string inv, string min, string max)
        {
            int InStock;
            int MinInv;
            int MaxInv;

            Int32.TryParse(inv, out InStock);
            Int32.TryParse(min, out MinInv);
            Int32.TryParse(max, out MaxInv);

            return (InStock >= MinInv) && (MaxInv >= InStock);
        }

    }
}
