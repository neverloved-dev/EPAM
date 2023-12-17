using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_Classes.Models
{
    public class Order
    {
        public int ID { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
        public int ProductId { get; set; }

        public Order(int id, Status status, DateTime createdDate, DateTime updatedDate, int productId)
        {
            ID = id;
            Status = status;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            ProductId = productId;
        }
    }



}
