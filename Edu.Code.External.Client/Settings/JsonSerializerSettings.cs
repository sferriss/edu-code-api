using System.Text.Json;
using System.Text.Json.Serialization;

namespace Edu.Code.External.Client.Settings;

public static class JsonSerializerSettings
{
    internal static readonly JsonSerializerOptions Config = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        Converters =
        {
            new JsonStringEnumMemberConverter(new UpperCaseJsonNamingPolicy()),
        },
    };

    private class UpperCaseJsonNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return name.ToUpper();
        }
    }
}