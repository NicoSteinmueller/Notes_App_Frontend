using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Notes_App_Frontend.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Language
{
    [EnumMember(Value = "GERMAN"), Display(Name= "German")]
    GERMAN, 
    [EnumMember(Value = "ENGLISH"), Display(Name = "English")]
    ENGLISH
}