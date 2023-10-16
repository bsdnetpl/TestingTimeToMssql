using Bogus;
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
        public async Task<User> FindUser(string pesel)
        {
            var userSeek = await _ContextMssql.users.FirstAsync(f => f.pesel == pesel);
            return userSeek;
        }
        public async Task<UserBis> FindUserBis(string pesel)
        {
            var userSeek = await _ContextMssql.userBis.FirstAsync(f => f.pesel == pesel);
            return userSeek;
        }
        public async Task<User> EditUser(string pesel, User user)
        {

            var editUser = await _ContextMssql.users.FirstOrDefaultAsync(s => s.pesel == pesel);
            if (editUser == null)
            {
                return editUser;
            }

            editUser.name = user.name;
            editUser.pesel = user.pesel;
            _ContextMssql.SaveChanges();
            return user;
        }
        public async Task<UserBis> EditUserBis(string pesel, UserBis userBis)
        {
            var editUser = await FindUserBis(pesel);
            if (editUser is null)
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
        public async Task<bool> AddRangeUser(int val)
        {
            var fake = new Faker<User>()
                .RuleFor(u => u.name, f => f.Name.FindName())
                .RuleFor(u => u.pesel, f => f.Phone.PhoneNumber());
            var res = fake.Generate(val);
            await _ContextMssql.users.AddRangeAsync(res);
            await _ContextMssql.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AddRangeUserBis(int val)
        {
            var fake = new Faker<UserBis>()
                .RuleFor(u => u.name, f => f.Name.FindName())
                .RuleFor(u => u.pesel, f => f.Phone.PhoneNumber());
            var res = fake.Generate(val);
            await _ContextMssql.userBis.AddRangeAsync(res);
            await _ContextMssql.SaveChangesAsync();
            return true;
        }
    }
}
