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
        [Route("GetAllRobots")]
        public ActionResult<IEnumerable<Robot>> GetAllRobots()
        {
            var robots = _robotRepository.GetAllRobots();
            return Ok(robots);
        }

        [HttpGet]
        [Route("GetRobotsByCategoryId")]
        public ActionResult<IEnumerable<Robot>> GetRobotsByCategoryId(int categoryId)
        {
            var robots = _robotRepository.GetRobotsByCategoryId(categoryId);
            if (robots == null)
            {
                return NotFound();
            }

            return Ok(robots);
        }

        [HttpPost]
        [Route("CreateRobot")]
        public ActionResult<bool> CreateRobot([FromBody] Robot robot)
        {
            var result = _robotRepository.CreateRobot(robot);
            if (result)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        [Route("DeleteRobot")]
        public ActionResult<bool> DeleteRobot(int robotId)
        {
            var result = _robotRepository.DeleteRobot(robotId);
            if (result)
                return Ok(result);
            else
                return NotFound();
        }
    }
}