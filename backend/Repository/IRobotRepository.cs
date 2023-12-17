using System.Collections.Generic;
using System.Threading.Tasks;
using irobotservice.Models;

public interface IRobotRepository
{
    IEnumerable<Category> GetCategories();
    IEnumerable<Robot> GetAllRobots();
    IEnumerable<Robot> GetRobotsByCategoryId(int categoryId);
    Robot GetRobotById(int robotId);

    Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
    Task<bool> RegisterUserAsync(RegistrationInfo registrationInfo);
}
