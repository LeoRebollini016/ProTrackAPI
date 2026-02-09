namespace ProTrack.DOMAIN.Options;

public class DatabaseOptions
{
    public const string Database = "ConnectionStrings";
    public string DefaultConnection { get; set; } = string.Empty;
}
