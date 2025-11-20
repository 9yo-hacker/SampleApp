using Microsoft.AspNetCore.Mvc;
using Bogus;
using SampleApp.API.Dto;
using SampleApp.API.Entities;
using SampleApp.API.Data;
using System.Security.Cryptography;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class SeedController : ControllerBase
{
    private readonly SampleAppContext _db;
    private readonly ITokenService _tokenService;

    public SeedController(SampleAppContext db, ITokenService tokenService)
    {
        _db = db;
        _tokenService = tokenService;
    }

    [HttpGet("generate")]
    public ActionResult SeedUsers()
    {
        using var hmac = new HMACSHA512();

        Faker<UserDto> _faker = new Faker<UserDto>("en")
            .RuleFor(u => u.Login, f => GenerateLogin(f).Trim())
            .RuleFor(u => u.Password, f => GeneratePassword(f).Trim().Replace(" ", ""));

        string GenerateLogin(Faker faker)
        {
            return faker.Random.Word() + faker.Random.Number(3, 5);
        }

        string GeneratePassword(Faker faker)
        {
            return faker.Random.Word() + faker.Random.Number(3, 5);
        }

        var users = _faker.Generate(100).Where(u => u.Login.Length > 4 && u.Login.Length <= 10);

        List<User> userToDb = new List<User>();

        try
        {
            foreach (var user in users)
            {
                var u = new User()
                {
                    Login = user.Login,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
                    PasswordSalt = hmac.Key,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Token = _tokenService.CreateToken(user.Login)
                };
                userToDb.Add(u);
            }
            _db.Users.AddRange(userToDb);
            _db.SaveChanges();
        }
        catch (Exception ex)
        {
            //можно логировать в консоль
            Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
            return Problem(detail: ex.Message);
        }

        return Ok(new { inserted = userToDb.Count });
    }
}

internal class UserRecordDto
{
}