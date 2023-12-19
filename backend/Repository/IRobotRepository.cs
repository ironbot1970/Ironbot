using System.Collections.Generic;
using System.Threading.Tasks;
using irobotservice.Models;

public interface IRobotRepository
{
    IEnumerable<Category> GetCategories();
    bool CreateCategory(Category category);
    bool DeleteCategory(int categoryId);

    IEnumerable<Robot> GetAllRobots();
    IEnumerable<Robot> GetRobotsByCategoryId(int categoryId);
    Robot GetRobotById(int robotId);
    bool CreateRobot(Robot robot);
    bool DeleteRobot(int robotId);

    Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
    Task<bool> RegisterUserAsync(RegistrationInfo registrationInfo);
}
