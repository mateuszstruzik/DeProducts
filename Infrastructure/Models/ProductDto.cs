﻿using System.Text.Json.Serialization;

namespace Infrastructure.Models;

//w modelach nie tylko w tym projekcie mozna by dodac opsiy i przyklady dla swaggera 
public record ProductDto(
    [property: JsonPropertyName("id")]
    int Id,

    [property: JsonPropertyName("title")]
    string Title,

    [property: JsonPropertyName("price")] 
    decimal Price,

    [property: JsonPropertyName("category")]
    string Category,

    [property: JsonPropertyName("description")]
    string Description,

    [property: JsonPropertyName("image")] 
    string Image,

    [property: JsonPropertyName("rating")] 
    RatingDto Rating
);