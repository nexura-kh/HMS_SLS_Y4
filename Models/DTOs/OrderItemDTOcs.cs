using HMS_SLS_Y4.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Models.DTOs
{
    public class OrderItemDTOcs
    {

        public int orderItemId { get; set; }
        public string itemName { get; set; }
        public decimal totalPrice { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public int quntity { get; set; }
        public FoodOrderStatus status { get; set; }
        public String note { get; set; }

        public int GetOrderItemId() => orderItemId;
        public void SetOrderItemId(int value) => orderItemId = value;

        public string GetItemName() => itemName;
        public void SetItemName(string value) => itemName = value;

        public decimal GetTotalPrice() => totalPrice;
        public void SetTotalPrice(decimal value) => totalPrice = value;

        public string GetDescription() => description;
        public void SetDescription(string value) => description = value;

        public int GetQuantity() => quantity;
        public void SetQuantity(int value) => quantity = value;

        public FoodOrderStatus GetStatus() => status;
        public void SetStatus(FoodOrderStatus value) => status = value;

        public string GetNote() => note;
        public void SetNote(string value) => note = value;
    }
}
