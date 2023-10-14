using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingTimeToMssql.Modules;
using TestingTimeToMssql.Services;

namespace TestingTimeToMssql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingsController : ControllerBase
    {
        protected readonly ITestingService _testingService;

        public TestingsController(ITestingService testingService)
        {
            _testingService = testingService;
        }
        [HttpPost("AddUser")]
       public  async Task<IActionResult>AddUser(User user)
        {
            await _testingService.Add(user);
            return Ok();
        }

        [HttpPost("AddUserBis")]
        public async Task<IActionResult> AddUserBis(UserBis userBis)
        {
            await _testingService.AddBis(userBis);
            return Ok();
        }
        
        [HttpGet("FindUser")]
        public async Task <ActionResult<User>> FindUser(string name)
        {
            var result = await _testingService.FindUser(name);
            return Ok(result);
        }
        [HttpGet("FindUserBis")]
        public async Task<ActionResult<User>> FindUserBis(string name)
        {
            return Ok(await _testingService.FindUserBis(name));
        }
        [HttpPut("EditUser")]
        public async Task<ActionResult<User>>EditUser(string name, User user )
        {
            return Ok(await _testingService.EditUser(name, user));
        }
        [HttpPut("EditUserBis")]
        public async Task<ActionResult<UserBis>> EditUserBis(string name, UserBis userBis)
        {
            return Ok(await _testingService.EditUserBis(name,userBis));
        }
        [HttpPut("AddBogusDataFotUser")]
        public async Task<IActionResult> AddBogusDataFotUser(int val)
        {
            await _testingService.AddRangeUser(val);
            return Ok();
        }
        [HttpPut("AddBogusDataFotUserBis")]
        public async Task<IActionResult> AddBogusDataFotUserBis(int val)
        {
            await _testingService.AddRangeUserBis(val);
            return Ok();
        }
        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<bool>>DelUser(int Id)
        {
            return Ok(await _testingService.DeleteUser(Id));
        }
        [HttpDelete("DeleteUserBis")]
        public async Task<ActionResult<bool>> DelUserBis(int Id)
        {
            return Ok(await _testingService.DeleteUserBis(Id));
        }
        
    }
}
