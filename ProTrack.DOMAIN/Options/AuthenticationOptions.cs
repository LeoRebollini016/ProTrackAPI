namespace ProTrack.DOMAIN.Options;

public class AuthenticationOptions
{
    public const string SectionName = "Authentication";
    public string SecretKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int Expire { get; set; }
    public bool IsDevelopmentMode { get; set; }
}