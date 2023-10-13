using TestingTimeToMssql.Modules;

namespace TestingTimeToMssql.Services
{
    public interface ITestingService
    {
        Task<bool> Add(User user);
        Task<bool> AddBis(UserBis userBis);
        Task<bool> DeleteUser(int Id);
        Task<bool> DeleteUserBis(int Id);
        Task<User> EditUser(string name, User user);
        Task<UserBis> EditUserBis(string name, UserBis userBis);
        Task<User> FindUser(string name);
        Task<UserBis> FindUserBis(string name);
    }
}