using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public class UserRepository : IUserRepository
{

    public UserRepository()
    {

    }
    public async Task<User> login(string name, string password)
    {
        using (var _CoronaAppDBContext = new CoronaAppDBContext())
        {

            return await _CoronaAppDBContext.Users.FirstOrDefaultAsync(user => user.Name.Equals(name) && user.Password.Equals(password));
        }
    }
    public async Task<User> signUp(string name, string password)
    {
        // User existingUser = await _CoronaAppDBContext.Users.FirstOrDefaultAsync(user => user.Name.Equals(name)).FirstOrDefaultAsync();
        using (var _CoronaAppDBContext = new CoronaAppDBContext())
        {
            bool existingUser = await _CoronaAppDBContext.Users.AnyAsync(user => user.Name.Equals(name));
            if (existingUser)
            {
                return null;
            }
            else
            {
                User user = new User();
                user.Name = name;
                user.Password = password;
                try
                {
                    await _CoronaAppDBContext.Users.AddAsync(user);
                    await _CoronaAppDBContext.SaveChangesAsync();
                    return user;
                }
                catch (Exception)
                {
                    throw new DbUpdateException();
                }
            }

        }
    }
}
