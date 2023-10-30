using DataAccess.Repository.Interface;
using eStoreApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace eStoreApi.Controllers
{
    public class CategoriesController : BaseApi
    {
        private readonly ICategoryRepository _repo;
        public CategoriesController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _repo.GetAll();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _repo.GetById(id);
            if (category == null) return NotFound("Not found.");

            return Ok(category);
        }
    }
}
