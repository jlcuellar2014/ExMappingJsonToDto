using AutoMapper;
using System.Text.Json;

namespace MappingJsonToDto
{
    public static class PostDtoMapper
    {
        public static PostDto MapJsonToPostDTOManual(string jsonData)
        {
            // Manual Mapping using System.Text.Json

            var jsonDocument = JsonDocument.Parse(jsonData);
            var root = jsonDocument.RootElement;

            return new PostDto()
            {
                UserId = root.GetProperty("userId").GetInt32(),
                Id = root.GetProperty("id").GetInt32(),
                Title = root.GetProperty("title").GetString() ?? string.Empty,
                Body = root.GetProperty("body").GetString() ?? string.Empty,
            };
        }

        public static PostDto MapJsonToPostDTOJsonSerializer(string jsonData)
        {

            PostDto dto = JsonSerializer.Deserialize<PostDto>(jsonData) ?? new PostDto();

            return dto;
        }

        public static PostDto MapJsonToPostDTOJsonSerializerPropertyNameCaseInsensitive(string jsonData)
        {

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            PostDto dto = JsonSerializer.Deserialize<PostDto>(jsonData, options)?? new PostDto();

            return dto;
        }

        public static Post MapPostDTOToPostAutoMapper(PostDto dto)
        {

            // Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            // Create mapper
            var mapper = config.CreateMapper();

            Post post = mapper.Map<Post>(dto);
            return post;
        }
    }
}
