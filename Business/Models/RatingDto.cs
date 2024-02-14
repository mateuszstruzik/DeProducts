using System.Text.Json.Serialization;

namespace Business.Models;

public record RatingDto(

    [property: JsonPropertyName("rate")]
    float Rate,

    [property: JsonPropertyName("count")]
    int Count
);