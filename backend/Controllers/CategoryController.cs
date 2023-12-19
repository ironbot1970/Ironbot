using irobotservice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace irobotservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IRobotRepository _robotRepository;

        public CategoryController(IRobotRepository robotRepository)
        {
            _robotRepository = robotRepository;
        }

        [HttpGet]
        [Route("GetCategories")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var categories = _robotRepository.GetCategories();
            return Ok(categories);
        }

        [HttpPost]
        [Route("CreateCategory")]
        public ActionResult<bool> CreateCategory([FromBody] Category category)
        {
            var result = _robotRepository.CreateCategory(category);
            if (result)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public ActionResult<bool> DeleteCategory(int categoryId)
        {
            var result = _robotRepository.DeleteCategory(categoryId);
            if (result)
                return Ok(result);
            else
                return NotFound();
        }
    }
}
