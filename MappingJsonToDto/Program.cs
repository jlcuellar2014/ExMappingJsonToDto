using MappingJsonToDto;

// Example JSON data
string jsonData = "{\"userId\": 1, \"id\": 1, \"title\": \"Post Title\", \"body\": \"Post Body\"}";

PostDto postDto1 = PostDtoMapper.MapJsonToPostDTOManual(jsonData);

/*
    The .NET JsonSerializer class is case-sensitive by default. 
    This means that the properties in your target class must exactly match the name 
    and capitalization of the JSON keys for the deserialization process to be successful. 
    If the keys in the JSON are in lowercase and the properties in your class are in uppercase, 
    or vice versa, they will not match and deserialization may not work correctly.

    In this case, the conversion will fail.
 */
PostDto postDto2 = PostDtoMapper.MapJsonToPostDTOJsonSerializer(jsonData);

/*
    To address this, you can use data attributes in your target class to specify how the match should be performed. 
    You can use the [JsonProperty] attribute of the System.Text.Json.Serialization 
    namespace to manually set the name of the property to bind to during deserialization.

    This will be discussed in the dto class.

    Or:

    To make deserialization work for both upper and lower case, you can use the 
    JsonSerializerOptions.PropertyNameCaseInsensitive option available in System.Text.Json.JsonSerializer.
 */

PostDto postDto3 = PostDtoMapper.MapJsonToPostDTOJsonSerializerPropertyNameCaseInsensitive(jsonData);

Post post = PostDtoMapper.MapPostDTOToPostAutoMapper(postDto1);


Console.ReadLine();