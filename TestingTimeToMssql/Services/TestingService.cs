using Microsoft.EntityFrameworkCore;
using TestingTimeToMssql.DB;
using TestingTimeToMssql.Modules;

namespace TestingTimeToMssql.Services
{
    public class TestingService : ITestingService
    {
        protected readonly ContextMssql _ContextMssql;

        public TestingService(ContextMssql contextMssql)
        {
            _ContextMssql = contextMssql;
        }

        public async Task<bool> Add(User user)
        {

            await _ContextMssql.users.AddAsync(user);
            await _ContextMssql.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AddBis(UserBis userBis)
        {

            await _ContextMssql.userBis.AddAsync(userBis);
            await _ContextMssql.SaveChangesAsync();
            return true;
        }
        public async Task<User> FindUser(string name)
        {
            var userSeek = await _ContextMssql.users.FirstAsync(f => f.name == name);
            return userSeek;
        }
        public async Task<UserBis> FindUserBis(string name)
        {
            var userSeek = await _ContextMssql.userBis.FirstAsync(f => f.name == name);
            return userSeek;
        }
        public async Task<User> EditUser(string name, User user)
        {

            var editUser = await _ContextMssql.users.FirstOrDefaultAsync(s => s.name == name);
            if (editUser == null)
            {
                return editUser;
            }
            
            editUser.name = user.name;
            editUser.pesel = user.pesel;
             _ContextMssql.SaveChanges();
            return user;
        }
        public async Task<UserBis> EditUserBis(string name, UserBis userBis)
        {
            var editUser = await FindUserBis(name);
            if(editUser is null)
            {
                return editUser;
            }
            editUser.pesel = userBis.pesel;
            editUser.name = userBis.name;
            await _ContextMssql.SaveChangesAsync();
            return userBis;
        }
        public async Task<bool> DeleteUser(int Id)
        {
            var userForDel = _ContextMssql.users.Where(i => i.id == Id).First();
            _ContextMssql.users.Remove(userForDel);
            await _ContextMssql.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUserBis(int Id)
        {
            var userForDel = _ContextMssql.userBis.Where(i => i.id == Id).First();
            _ContextMssql.userBis.Remove(userForDel);
            await _ContextMssql.SaveChangesAsync();
            return true;
        }
    }
}
