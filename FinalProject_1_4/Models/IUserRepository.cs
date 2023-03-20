using System;
namespace FinalProject_1_4.Models
{
	public interface IUserRepository
	{
        public IEnumerable<User> GetAllUser();
        public User GetUser(int id);
        public void UpdateUser(User user);

        public void InsertUser(User userToInsert);
        public IEnumerable<Category> GetCategories();

        public User AssignCategory();
        public void DeleteUser(User User);
    }
}

