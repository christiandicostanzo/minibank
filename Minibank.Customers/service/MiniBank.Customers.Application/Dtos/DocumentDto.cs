using System.Text.Json.Serialization;

namespace MiniBank.CustomersSrv.Application.Dtos;

public class DocumentDto
{
    [JsonPropertyName("document_id")]
    public int DocumentId { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}