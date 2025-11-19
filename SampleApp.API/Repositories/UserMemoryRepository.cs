using SampleApp.API.Entities;
using SampleApp.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using SampleApp.API.Data;

namespace SampleApp.API.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private readonly SampleAppContext _db;

        public UsersRepository(SampleAppContext db)
        {
            _db = db;
        }

        public List<User> GetUsers()
        {
            return _db.Users.ToList();
        }

        public User CreateUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }

        public User DeleteUser(int id)
        {
            var user = FindUserById(id);
            _db.Users.Remove(user);
            _db.SaveChanges();
            return user;
        }

        public User EditUser(User user, int id)
        {
            var existing = FindUserById(id);
            existing.Login = user.Login;
            _db.SaveChanges();
            return existing;
        }

        public User FindUserById(int id)
        {
            var result = _db.Users.FirstOrDefault(u => u.Id == id);
            if (result == null) 
                throw new Exception($"Нет пользователя с id = {id}");

            return result;
        }
    }
}
