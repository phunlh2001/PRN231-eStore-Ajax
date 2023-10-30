using BusinessObjects.Data;
using DataAccess.Repository.Interface;
using eStoreApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;

namespace eStoreApi.Controllers
{
    public class OrdersController : BaseApi
    {
        private readonly IOrderRepository _repo;
        public OrdersController(IOrderRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetList());
        }

        [HttpGet("{userId}")]
        public IActionResult GetAll([FromRoute] string userId)
        {
            return Ok(_repo.GetOrdersByUser(userId));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var od = _repo.GetOrder(id);
            if (od == null) return NotFound("Order not found.");

            return Ok(od);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Order order)
        {
            if (order == null) return BadRequest("Information is required");

            if (ModelState.IsValid)
            {
                _repo.InsertOrder(order);
                return Ok(order);
            }

            return BadRequest("ModelState invalid");
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Order order)
        {
            if (order == null) return BadRequest("Information must be fulfill.");

            var od = _repo.GetOrder(id);
            if (od == null) return NotFound("Order not found.");

            _repo.UpdateOrder(order);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var ord = _repo.GetOrder(id);
            if (ord == null) return NotFound("Order not found.");

            _repo.DeleteOrder(id);
            return NoContent();
        }

        [HttpGet("filter")]
        public IActionResult Filter([FromQuery] string startDate, string endDate)
        {
            string format = "dd/MM/yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;

            if (DateTime.TryParseExact(startDate, format, provider, DateTimeStyles.None, out DateTime start)
                && DateTime.TryParseExact(endDate, format, provider, DateTimeStyles.None, out DateTime end))
            {
                var orders = _repo.Filter(start, end);

                if (orders.Count() == 0) return NotFound("Not found.");
                return Ok(orders);
            }
            else
            {
                return BadRequest("Invalid date format. Please use 'dd/MM/yyyy' format.");
            }
        }
    }
}
