using System.Text.Json.Serialization;

namespace Business.Models;

//Tuaj ten DTO jest tylko jako pokazanie że data transfer object slużą do przenoszenia informacji miedzy warstwami,
//nie chcąc mieszać warstwy bussiness i infra dodalem go natomiast spotyklaem sie z projektami gdzie
//modele byly w osobnym projekcie albo byly reuzywane przez rozne warstwy 

//Recordy w dto  dla tego ze sa immutable co oddaje specyfike tyhc obiektow 
public record ProductDto
(
    [property: JsonPropertyName("id")]
    int Id,

    [property: JsonPropertyName("title")]
    string Title,

    [property: JsonPropertyName("price")]
    string Price,

    [property: JsonPropertyName("category")]
    string Category,

    [property: JsonPropertyName("description")]
    string Description,

    [property: JsonPropertyName("image")]
    string Image,

    [property: JsonPropertyName("rating")]
    RatingDto Rating
);