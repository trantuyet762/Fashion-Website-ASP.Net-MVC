 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Migrations;

namespace WebBanHangOnline.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> items { get; set; }
       public ShoppingCart()
        {
            this.items = new List<ShoppingCartItem>();
        }
        public void AddToCart(ShoppingCartItem item, int Quantity)
        {
            var checkExits = items.FirstOrDefault(x => x.ProductId == item.ProductId && x.SizeId== item.SizeId && x.ColorId== item.ColorId);
            if(checkExits!= null)
            {
               
                checkExits.Quantity += Quantity;
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }
            else
            {
                items.Add(item);
            }
        }
        public void Remove(int id, int sizeId, int colorId)
        {
            var checkExits = items.SingleOrDefault(x => x.ProductId == id && x.SizeId== sizeId && x.ColorId == colorId);
            if(checkExits != null)
            {
                items.Remove(checkExits);
             
            }
        }

        public void UpdateQuantity(int productId, int quantity, int sizeId, int colorId)
        {
            var itemToUpdate = items.FirstOrDefault(x => x.ProductId == productId && x.SizeId == sizeId && x.ColorId== colorId);
            if (itemToUpdate != null)
            {
                itemToUpdate.Quantity = quantity;
                itemToUpdate.TotalPrice = itemToUpdate.Price * itemToUpdate.Quantity;
            }
        }

        public decimal GetTotalPrice()
        {
            return items.Sum(x => x.TotalPrice);
        }
        public int GetTotalQuantity()
        {
            return items.Sum(x => x.Quantity);
        }
        public void ClearCart()
        {
            items.Clear();
        }
    }
    public class ShoppingCartItem
    {
        public int ColorId { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public string ProductName { get; set; }
        public string ColorName { get; set; }
        public string Alias { get; set; }
        public string SizeName { get; set; }
        public string CategoryName { get; set; }
        public string ProductImg { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}