namespace Application.Features.Host.Options;

public class UwOptions
{
    public const string Key = "Unibox";
    
    public required string Host { get; set; }
    
    public required string MediaPath { get; set; }
}