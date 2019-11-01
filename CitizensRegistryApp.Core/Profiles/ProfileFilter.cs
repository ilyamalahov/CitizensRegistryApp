using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace CitizensRegistryApp.Core.Profiles
{
    public class ProfileFilter : Filter
    {
        // [JsonPropertyName("lastName")]
        // public string LastName { get; set; }

        // [JsonPropertyName("firstName")]
        // public string FirstName { get; set; }

        // [JsonPropertyName("middleName")]
        // public string MiddleName { get; set; }

        // [JsonPropertyName("birthdayStartDate")]
        // public DateTime? BirthdayStartDate { get; set; }

        // [JsonPropertyName("birthdayEndDate")]
        // public DateTime? BirthdayEndDate { get; set; }
    }

    public class Filter
    {
        [JsonPropertyName("filters")]
        public IEnumerable<Filter> Filters { get; set; }

        [JsonPropertyName("logic")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FilterLogic Logic { get; set; }

        [JsonPropertyName("operator")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FilterOperator Operator { get; set; }

        [JsonPropertyName("field")]
        public string Field { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public enum FilterOperator
    {
        [EnumMember(Value = "eq")]
        Equals,
        [EnumMember(Value = "gt")]
        GreaterThan,
        [EnumMember(Value = "lt")]
        LowerThan,
        [EnumMember(Value = "null")]
        IsNull,
        [EnumMember(Value = "notnull")]
        IsNotNull,
        [EnumMember(Value = "in")]
        In,
        [EnumMember(Value = "between")]
        Between
    }

    public enum FilterLogic
    {
        [EnumMember(Value = "and")]
        And,
        [EnumMember(Value = "or")]
        Or
    }
}
