using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Notes_App_Frontend.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Language
{
    [EnumMember(Value = "GERMAN")]
    GERMAN, 
    [EnumMember(Value = "ENGLISH")]
    ENGLISH
}