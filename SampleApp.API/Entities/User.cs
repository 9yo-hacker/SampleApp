using System.ComponentModel.DataAnnotations;

namespace SampleApp.API.Entities
{
    public class User : Base
    {
    public string Token {get; set;} = string.Empty;
    [Required]
    [StringLength(100, MinimumLength = 3)]    public required string Login {get; set;}
    public byte[] PasswordHash {get; set;} = Array.Empty<byte>();
    public byte[] PasswordSalt {get; set;} = Array.Empty<byte>();
    }
}
