using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestExercise.Models.OrderModel
{
    public class Order
    {
        public Order()
        {
            CreationTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }
        
        [Key]
        public string ID { get; set; }

        public int Number { get; set; }

        public string CreationTime { get; set; }

        public Manager Manager { get; set; }

        public string Note { get; set; }
    }
}
