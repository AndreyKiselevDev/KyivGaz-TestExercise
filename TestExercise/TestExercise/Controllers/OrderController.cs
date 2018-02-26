using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TestExercise.Models;
using TestExercise.Context;
using TestExercise.Models.OrderModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace TestExercise.Controllers
{
    [Route("api")]
    public class OrderController : Controller
    {
        private OrderContext _db;

        public OrderController(OrderContext db)
        {
            _db = db;
        }
        
        public async Task<string> GetManagerOrders()
        {
            var query = "SELECT count(Manager) as Count" +
                ",Manager" +
                " FROM Orders " +
                "Group by Manager";

            var orders = await _db.Orders
                .FromSql(query)
                .AsNoTracking()
                .ToListAsync();

            return JsonConvert.SerializeObject(orders);
        }

        [HttpPost("get")]
        public string GetOrders()
        {
            return GetSortedOrders();
        }

        private string GetSortedOrders()
        {
            return JsonConvert.SerializeObject(_db.Orders.ToList().OrderBy(e => e.Number));
        }

        [HttpGet("managers")]
        public string GetManagers()
        {
            var managers = new List<string>();

            foreach (Manager manager in Enum.GetValues(typeof(Manager)))
                managers.Add(manager.ToString());

            return JsonConvert.SerializeObject(managers);
        }

        [HttpPost("edit")]
        public string EditOrder(string note, string id, string manager)
        {
            var order = _db.Orders.ToList().Find(e => e.ID == id);

            order.Note = note;
            order.Manager = (Manager)Enum.Parse(typeof(Manager), manager);

            _db.Update(order);

            _db.SaveChanges();

            return GetSortedOrders();
        }

        [HttpPost("add")]
        public string AddOrder(string manager, string note)
        {
            try
            {
                var order = new Order() { ID = Guid.NewGuid().ToString(), Note = note, Manager = (Manager) Enum.Parse(typeof(Manager), manager), Number = _db.Orders.ToList().Count + 1 };
                
                _db.Add(order);
                
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return GetSortedOrders();
        }
    }
}