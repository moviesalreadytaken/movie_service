using Newtonsoft.Json;

namespace movie.Utils;

public class DateOnlyConverter : JsonConverter<DateOnly>
{
    public const string Format = "yyyy-MM-dd";


    public override DateOnly ReadJson(JsonReader reader, Type objectType,
     DateOnly existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        return DateOnly.ParseExact((string)reader.Value!, Format);
    }

    public override void WriteJson(JsonWriter writer, DateOnly value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString(Format));
    }
}
