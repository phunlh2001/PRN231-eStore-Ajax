using BusinessObjects.Data;
using DataAccess.Repository.Interface;
using eStoreApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace eStoreApi.Controllers
{
    public class OrderDetailsController : BaseApi
    {
        private readonly IOrderDetailRepository _repo;
        public OrderDetailsController(IOrderDetailRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _repo.GetList();
            if (list == null) return NotFound("Order detail empty.");

            return Ok(list);
        }

        [HttpPost]
        public IActionResult Add([FromBody] OrderDetail detail)
        {
            if (detail == null) return BadRequest("Information is required.");

            if (ModelState.IsValid)
            {
                _repo.Add(detail);
                return NoContent();
            }
            else
            {
                return BadRequest("Invalid");
            }

        }
    }
}
