using _9_3;
using System.Reflection.Metadata;
using System.Collections.Generic;

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
    void DressAMan();
}

interface IWomensClothing
{
    void DressAWoman();
}

abstract class Clothes
{
    public ClothingSize size;
    public double price;
    public string color;
}

class TShirt : Clothes, IMansClothing, IWomensClothing
{
    public void DressAMan()
    {
        price = 1000.0;
        color = "Black";
        size = ClothingSize.M;
    }

    public void DressAWoman()
    {
        price = 1500.0;
        color = "Violet";
        size = ClothingSize.S;
    }
}

class Skirt : Clothes, IWomensClothing
{
    public Skirt()
    {
        DressAWoman();
    }
   
    public void DressAWoman()
    {
        price = 30000000.0;
        color = "Red";
        size = ClothingSize.L;
    }
}

class Pants : Clothes, IMansClothing, IWomensClothing
{
    
    public void DressAMan()
    {
        price = 3200.0;
        color = "Blue";
        size = ClothingSize.L;
    }

    public void DressAWoman()
    {
        price = 2600.0;
        color = "Pink";
        size = ClothingSize.XXS;
    }
}

class Tie : Clothes, IMansClothing
{
    

    public void DressAMan()
    {
        price = 1250.0;
        color = "Black";
        size = ClothingSize.S;
    }
}

class Atelier<T>  where T : Clothes, IMansClothing , IWomensClothing
{
    public void DressAMan(T[] ArrayCloth) 
    { 
        for (int i = 0; i < ArrayCloth.Length; i++)
        {
            if (typeof(IMansClothing).IsAssignableFrom(ArrayCloth[i].GetType()))
            {
                ArrayCloth[i].DressAMan();
                Console.WriteLine($"{ArrayCloth[i].GetType()} : ");
                Console.WriteLine($"  Price : {ArrayCloth[i].price}");
                Console.WriteLine($"  Size : {ArrayCloth[i].size}");
                Console.WriteLine($"  Color : {ArrayCloth[i].color}");

            }

        }

    }

    public void DressAWoman(T[] ArrayCloth)
    {
        for (int i = 0; i < ArrayCloth.Length; i++)
        {
            if (typeof(IWomensClothing).IsAssignableFrom(ArrayCloth[i].GetType()))
            {
                ArrayCloth[i].DressAWoman();
                Console.WriteLine($"  {ArrayCloth[i].GetType()} : ");
                Console.WriteLine($"  Price : {ArrayCloth[i].price}");
                Console.WriteLine($"  Size : {ArrayCloth[i].size}");
                Console.WriteLine($"  Color : {ArrayCloth[i].color}");
            }

        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Clothes[] clothes = {new Tie(), new TShirt(), new Pants(), new Skirt()};
        Atelier<Clothes> atelier = new Atelier();
        atelier.DressAWoman(clothes);

        
    }
}
