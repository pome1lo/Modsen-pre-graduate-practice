using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Services.Auth;

public class JwtConfig
{
    [Required]
    [MinLength(32)]
    public required string Secret { get; set; }

    [Required]
    [MinLength(1)]
    public required string Issuer { get; set; }

    [Required]
    [MinLength(1)]
    public required string Audience { get; set; }
}