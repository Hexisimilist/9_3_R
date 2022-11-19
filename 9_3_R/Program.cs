
namespace _9_3
{
    enum ClothingSize
    {
        XXS = 32,
        XS = 34,
        S = 36,
        M = 38,
        L = 40
    }


    interface IMansClothing
    {
        void DressAMan(double price, string color, ClothingSize size);
    }

    interface IWomensClothing
    {
        void DressAWoman(double price, string color, ClothingSize size);
    }

    abstract class Clothes
    {
        public bool sex;
        public ClothingSize size;
        public double price;
        public string color;


    }

    class TShirt : Clothes, IMansClothing, IWomensClothing
    {
        public TShirt(double price, string color, ClothingSize size, bool sex)
        {
            if (sex)
            {
                DressAMan(price, color, size);
                this.sex = true;
            }
            else
            {
                DressAWoman(price, color, size);
                this.sex = false;
            }
        }
        public void DressAMan(double price, string color, ClothingSize size)
        {
            this.price = price;
            this.color = color;
            this.size = size;

            //price = 1000.0;
            //color = "Black";
            //size = ClothingSize.M;
        }

        public void DressAWoman(double price, string color, ClothingSize size)
        {
            this.price = price;
            this.color = color;
            this.size = size;

            //price = 1500.0;
            //color = "Violet";
            //size = ClothingSize.S;
        }
    }

    class Skirt : Clothes, IWomensClothing
    {
        public Skirt(double price, string color, ClothingSize size)
        {
            DressAWoman(price, color, size);
            this.sex = false;
        }

        public void DressAWoman(double price, string color, ClothingSize size)
        {
            this.price = price;
            this.color = color;
            this.size = size;
            //price = 30000000.0;
            //color = "red";
            //size = clothingsize.l;
        }
    }

    class Pants : Clothes, IMansClothing, IWomensClothing
    {
        public Pants(double price, string color, ClothingSize size, bool sex)
        {
            if (sex)
            {
                DressAMan(price, color, size);
                this.sex = true;
            }
            else
            {
                DressAWoman(price, color, size);
                this.sex = false;
            }
        }
        public void DressAMan(double price, string color, ClothingSize size)
        {
            this.price = price;
            this.color = color;
            this.size = size;

            //price = 3200.0;
            //color = "Blue";
            //size = ClothingSize.L;
        }

        public void DressAWoman(double price, string color, ClothingSize size)
        {
            this.price = price;
            this.color = color;
            this.size = size;

            //price = 2600.0;
            //color = "Pink";
            //size = ClothingSize.XXS;
        }
    }

    class Tie : Clothes, IMansClothing
    {
        public Tie(double price, string color, ClothingSize size)
        {
            DressAMan(price, color, size);
            this.sex = true;
        }

        public void DressAMan(double price, string color, ClothingSize size)
        {
            this.price = price;
            this.color = color;
            this.size = size;

            //price = 1250.0;
            //color = "Black";
            //size = ClothingSize.S;
        }
    }

    //class Atelier<T> where T : Clothes, IMansClothing, IWomensClothing
    //{
    //    public void DressAMan(T[] BAza)
    //    {
    //        for (int i = 0; i < BAza.Length; i++)
    //        {
    //            if (typeof(IMansClothing).IsAssignableFrom(BAza[i].GetType()))
    //            {
    //                // BAza[i].DressAMan();
    //                Console.WriteLine($"{BAza[i].GetType()} : ");
    //                Console.WriteLine($"  Price : {BAza[i].price}");
    //                Console.WriteLine($"  Size : {BAza[i].size}");
    //                Console.WriteLine($"  Color : {BAza[i].color}");

    //            }

    //        }

    //    }

    //    public void DressAWoman(T[] BAza)
    //    {
    //        for (int i = 0; i < BAza.Length; i++)
    //        {
    //            if (typeof(IWomensClothing).IsAssignableFrom(BAza[i].GetType()))
    //            {
    //                // BAza[i].DressAWoman();
    //                Console.WriteLine($"  {BAza[i].GetType()} : ");
    //                Console.WriteLine($"  Price : {BAza[i].price}");
    //                Console.WriteLine($"  Size : {BAza[i].size}");
    //                Console.WriteLine($"  Color : {BAza[i].color}");
    //            }

    //        }
    //    }
    //}

    class Atelier : Clothes
    {
        public void DressAMan(Clothes[] BAza)
        {
            for (int i = 0; i < BAza.Length; i++)
            {
                if (BAza[i].sex == true)
                {
                    Print(BAza[i]);
                }
            }
        }

        public void DressAWoman(Clothes[] BAza)
        {
            for (int i = 0; i < BAza.Length; i++)
            {
                if (BAza[i].sex == false)
                {
                    Print(BAza[i]);
                }
            }
        }
        private void Print(Clothes BAza)
        {
            Console.WriteLine($"{BAza.GetType().Name} : ");
            Console.WriteLine($"  Price : {BAza.price}");

            Console.WriteLine($"  Size : {BAza.size}, {BAza.size.Size_Value()}");
            Console.WriteLine($"  Color : {BAza.color}");
            if (BAza.sex)
            {
                Console.WriteLine("  Sex : man");
            }
            else
            {
                Console.WriteLine("  Sex : woman");
            }
            Console.WriteLine();

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Clothes[] clothes = { new Tie(100.0,"red", ClothingSize.S),
            new TShirt(200.0, "blue", ClothingSize.M, true),
            new Pants(40.0, "black", ClothingSize.M, true),
            new TShirt(150.0, "pinke", ClothingSize.XXS, false),
            new Skirt(30000.0, "pinke", ClothingSize.S) };
            Atelier Atello = new Atelier();
            Console.WriteLine("Мужская одежда: ");
            Console.WriteLine();
            Atello.DressAMan(clothes);
            Console.WriteLine("Женская одежда: ");
            Console.WriteLine();

            Atello.DressAWoman(clothes);
            //Atelier<Clothes> atelier = new Atelier<Clothes>();
            // atelier.DressAWoman(clothes);


        }
    }
}
