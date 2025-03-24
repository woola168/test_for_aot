using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using YouniLab.Member.Application.AppServices;
using YouniLab.Member.Domain.Member;

namespace YouniLab.Member.Application.Serialization
{
    [JsonSerializable(typeof(MemberAppService))]
    [JsonSerializable(typeof(JsonTypeInfo))]
    [JsonSerializable(typeof(OpenApiInfo))]
    [JsonSerializable(typeof(OpenApiDocument))]
    [JsonSerializable(typeof(bool))]
    [JsonSerializable(typeof(Domain.Member.Member))]
    [JsonSerializable(typeof(MemberAccount))]
    public partial class AppJsonSerializerContext : JsonSerializerContext { }
}
