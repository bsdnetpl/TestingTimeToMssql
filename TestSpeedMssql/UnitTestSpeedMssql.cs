using Moq;
using TestingTimeToMssql.Modules;
using TestingTimeToMssql.Services;

namespace TestSpeedMssql
{
    public class UnitTestSpeedMssql
    {
        [Fact]
        public void Check_time_acces_to_mssql_add_user_return_true()
        {
            User user = new User
            {
                id = 1,
                name = "Test",
                pesel = "1234567890"
            };
            var moqElement = new Mock<ITestingService>();
            moqElement.Setup(m => m.Add(user).Result).Returns(true);
            var result = moqElement.Object.Add(user);
            Assert.True(result.Result);

        }
        [Fact]
        public void Check_time_acces_to_mssql_add_user_bis_return_true()
        {
            UserBis user = new UserBis
            {
                id = 1,
                name = "Test",
                pesel = "1234567890"
            };
            var moqElement = new Mock<ITestingService>();
            moqElement.Setup(m => m.AddBis(user).Result).Returns(true);
            var result = moqElement.Object.AddBis(user);
            Assert.True(result.Result);

        }
        [Fact]
        public void Check_time_acces_to_mssql_find_user_return_user()
        {
            User user = new User
            {
                id = 1,
                name = "Test",
                pesel = "1234567890"
            };
            var moqElement = new Mock<ITestingService>();
            moqElement.Setup(m => m.FindUser(user.pesel).Result).Returns(user);
            var result = moqElement.Object.FindUser(user.pesel);
            Assert.Equal("1234567890", result.Result.pesel);
        }
        [Fact]
        public void Check_time_acces_to_mssql_find_user_bis_return_user()
        {
            UserBis user = new UserBis
            {
                id = 1,
                name = "Test",
                pesel = "1234567890"
            };
            var moqElement = new Mock<ITestingService>();
            moqElement.Setup(m => m.FindUserBis(user.pesel).Result).Returns(user);
            var result = moqElement.Object.FindUserBis(user.pesel);
            Assert.Equal("1234567890", result.Result.pesel);

        }
        [Fact]
        public void Check_time_acces_to_mssql_edit_user_return_user()
        {
            User user = new User
            {
                id = 1,
                name = "Test",
                pesel = "1234567890"
            };
            User userEdit = new User
            {
                id = 1,
                name = "Test1",
                pesel = "1234567890"
            };
            var moqElement = new Mock<ITestingService>();
            moqElement.Setup(m => m.EditUser(user.pesel, userEdit).Result).Returns(userEdit);
            var result = moqElement.Object.EditUser(user.pesel, userEdit);
            Assert.Equal("Test1", result.Result.name);

        }
    }
}