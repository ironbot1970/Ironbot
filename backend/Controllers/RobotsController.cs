using System.Collections.Generic;
using irobotservice.Models;
using Microsoft.AspNetCore.Mvc;

namespace irobotservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotsController : ControllerBase
    {
        private readonly IRobotRepository _robotRepository;

        public RobotsController(IRobotRepository robotRepository)
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

        [HttpGet]
        [Route("GetRobotsByCategoryId")]
        public ActionResult<IEnumerable<Robot>> GetRobotsByCategoryId(int categoryId)
        {
            var robot = _robotRepository.GetRobotsByCategoryId(categoryId);
            if (robot == null)
            {
                return NotFound();
            }

            return Ok(robot);
        }
    }
}