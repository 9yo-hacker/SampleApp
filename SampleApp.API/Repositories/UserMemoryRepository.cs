using SampleApp.API.Entities;
using SampleApp.API.Interfaces;

namespace SampleApp.API.Repositories
{
    public class UserMemoryRepository : IUserRepository
    {
        public IList<User> Users { get; set; } = new List<User>
        {
            new User { Id = 1, Name = "Alice" },
            new User { Id = 2, Name = "Bob" },
        };

        public  User CreateUser(User user)
        {
            user.Id = Users.Count == 0 ? 1 : Users.Max(u => u.Id) + 1;
            Users.Add(user);
            return user;
        }
        public User DeleteUser(int id)
        {
            var result = FindUserById(id);
            Users.Remove(result);
            return result;
        }
        public User EditUser(User user, int id)
        {
            var result = FindUserById(id);
            result.Name = user.Name;
            return result;
        }
        public User FindUserById(int id)
        {
            var result = Users.Where(u => u.Id == id).FirstOrDefault();
            if (result == null) throw new Exception($"Нет пользователя с id = {id}");

            return result;
        }
        public List<User> GetUsers()
        {
            return (List<User>)Users;
        }
    }
}
