using System.Text.Json.Serialization;

namespace Infrastructure.Models;

public record RatingDto(

    [property: JsonPropertyName("rate")]
    float Rate,

    [property: JsonPropertyName("count")]
    int Count
);