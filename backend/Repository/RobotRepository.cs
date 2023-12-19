using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using irobotservice.Models;
using Microsoft.EntityFrameworkCore;

public class RobotRepository : IRobotRepository
{
    private readonly IronBotDBContext _context;

    public RobotRepository(IronBotDBContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    #region Category

    public IEnumerable<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public bool CreateCategory(Category category)
    {
        try
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool DeleteCategory(int categoryId)
    {
        try
        {
            _context.Categories.Remove(_context.Categories.FirstOrDefault(r => r.Id == categoryId));
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    #endregion

    #region Robots

    public IEnumerable<Robot> GetAllRobots()
    {
        return _context.Robots.ToList();
    }

    public IEnumerable<Robot> GetRobotsByCategoryId(int categoryId)
    {
        return _context.Robots
            .Where(x => x.Category.Id == categoryId)
            .ToList();
    }

    public Robot GetRobotById(int robotId)
    {
        return _context.Robots.Find(robotId);
    }

    public bool CreateRobot(Robot robot)
    {
        try
        {
            _context.Robots.Add(robot);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool DeleteRobot(int robotId)
    {
        try
        {
            _context.Robots.Remove(_context.Robots.FirstOrDefault(r => r.Id == robotId));
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    #endregion

    #region Users

    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        var valid = HashHelper.VerifyMD5Hash(password, user.PasswordSalt, user.PasswordHash);

        if (valid)
        {
            return user;
        }
        
        return null;
    }

    public async Task<bool> RegisterUserAsync(RegistrationInfo registrationInfo)
    {
        try
        {
            var userExists = _context.Users.Any(x => x.Email == registrationInfo.Email);
            if (userExists)
            {
                return false;
            }

            var salt = HashHelper.GenerateSalt();
            var newUser = new User
            {
                Username = registrationInfo.Email,
                PasswordHash = HashHelper.GenerateMD5Hash(registrationInfo.Password, salt),
                PasswordSalt = salt,
                Email = registrationInfo.Email,
                Phone = "",
                Mobile = registrationInfo.Mobile,
                FirstName = registrationInfo.FirstName,
                LastName = registrationInfo.LastName,
                Country = "",
                City = registrationInfo.City,
                Zip = registrationInfo.Zip,
                Address = registrationInfo.Address,
                Status = 0,
                IsValidated = 0,
                ValidationUrl = Guid.NewGuid().ToString(),
                IsAdmin = 0,
                TimeStamp = DateTime.Now
            };
            
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
        catch(Exception ex)
        {
            return false;
        }

        return true;
    }

    #endregion
}
