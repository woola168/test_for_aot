using System.Text.Json.Serialization;
using YouniLab.Member.Domain.Member;

namespace YouniLab.Member.Application.Serialization
{
    [JsonSerializable(typeof(bool))]
    [JsonSerializable(typeof(Domain.Member.Member))]
    [JsonSerializable(typeof(MemberAccount))]
    public partial class AppJsonSerializerContext : JsonSerializerContext { }
}
