namespace OptiLoan.enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public class OrganizationClass
    {
        public string  Agent { get; set; } = string.Empty;
        public string  SuperAgent { get; set; } = string.Empty;
        public string  MasterAgent { get; set; } = "Master Agent";
        public string  Staff { get; set; } = string.Empty;
    }
}