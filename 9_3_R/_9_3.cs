using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_3
{
    static class SizeValue
    {
        public static string Size_Value(this ClothingSize clothingSize)
        {

            if ((int)clothingSize==32)
                return "Детский размер";
            else
                return "Взрослый размер";

        }
    }
}