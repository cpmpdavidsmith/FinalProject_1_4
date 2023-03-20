using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace FinalProject_1_4.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _conn;

        public UserRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public User AssignCategory()
        {
            var categoryList = GetCategories();
            var user = new User();
            user.Categories = categoryList;
            return user;
        }

        public void DeleteUser(User User)
        {
            _conn.Execute("DELETE FROM REVIEWS WHERE UserID = @id;", new { id = User.UserID });
            _conn.Execute("DELETE FROM Sales WHERE UserID = @id;", new { id = User.UserID });
            _conn.Execute("DELETE FROM Products WHERE UserID = @id;", new { id = User.UserID });
        }

        public IEnumerable<User> GetAllUser()
        {
            const string Sql = "SELECT * FROM USER;";
            return _conn.Query<User>(Sql);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM CATEGORIES;");
        }

        public User GetUser(int id)
        {
            return _conn.QuerySingle<User>("SELECT * FROM USER WHERE USERID = @id",
                new { id = id });
        }

        public void InsertUser(User userToInsert)
        {
            _conn.Execute("INSERT INTO user  (FIRSTNAME, LASTNAME, CATEGORYID," +
                "USERTOTALALLOWEDHOURS, USERSCHEDULEDHOURS,USERCOMPLETEDHOURS," +
                "USERAVAILABLESCHEDULEDHOURS, USERAVAILABLEFREEHOURS," +
                "USERPHONENUMBER) VALUES (@firstname, @lastname, @categoryid," +
                "@usertotalallowedhours, @price, @userscheduledhours," +
                "@usercompletedhours, @useravailablescheduledhours," +
                "@useravailablefreehours, @userphonenumber);",
        new
        {
            firstname = userToInsert.FirstName,
            lastname = userToInsert.LastName,
            categoryid = userToInsert.CategoryID,
            usertotalallowedhours = userToInsert.UserTotalAllowedHours,
            userscheduledhours = userToInsert.UserScheduledHours,
            usercompletedhours = userToInsert.UserCompletedHours,
            useravailablescheduledhours = userToInsert.UserAvailableScheduledHours,
            useravailablefreehours = userToInsert.UserAvailableFreeHours,
            userphonenumber = userToInsert.UserPhoneNumber
        });
        }

        public void UpdateUser(User user)
        {
            _conn.Execute("UPDATE user SET FirstName = @firstname, LastName = @lastname," +
                "UserTotalAllowedHours = @usertotalallowedhours, " +
                "UserScheduledHours = @userscheduledhours, UserCompletedHours = " +
                "@usercompletedhours, UserAvailableScheduledHours = @useravailablescheduledhours," +
                " UserAvailableFreeHours = @useravailablefreehours, UserPhoneNumber = " +
                "@userphonenumber WHERE UserID = @id",
             new
             {
                 firstname = user.FirstName,
                 lastname = user.LastName,
                 usertotalallowedhours = user.UserTotalAllowedHours,
                 userscheduledhours = user.UserScheduledHours,
                 UserCompletedHours = user.UserCompletedHours,
                 useravailablescheduledhours = user.UserAvailableScheduledHours,
                 useravailablefreehours = user.UserAvailableFreeHours,
                 userphonenumber = user.UserPhoneNumber,
                 id = user.UserID
             });
        }
    }
}

