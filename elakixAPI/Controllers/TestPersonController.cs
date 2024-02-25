using Dapper;
using elakixAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace elakixAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestPersonController : ControllerBase
    {
        private readonly IDbConnection _dbConnection;

        public TestPersonController(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestPersonModel>>> Get()
        {
            var sql = "SELECT * FROM TestPerson";
            var people = await _dbConnection.QueryAsync<TestPersonModel>(sql);
            foreach (var person in people)
            {
                var numbersSql = "SELECT PhoneNumber FROM TestPhoneNumbers WHERE testperson_id = @Id";
                var numbers = await _dbConnection.QueryAsync<string>(numbersSql, new { Id = person.Id });
                person.Numbers = numbers.ToList();
            }
            return Ok(people);
        }
    }
}
