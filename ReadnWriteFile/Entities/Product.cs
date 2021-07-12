using System;
namespace ReadnWriteFile.Entities
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + "\nName: " + Name + "\nPrice: " + Price + "\nQuantity: " + Quantity;
        }
    }
}
