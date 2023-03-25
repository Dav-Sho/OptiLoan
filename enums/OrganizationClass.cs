namespace OptiLoan.enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public class OrganizationClass
    {
        public string  Agent { get; set; } = "Agent";
        public string  SuperAgent { get; set; } = "SuperAgent";
        public string  MasterAgent { get; set; } = "Master Agent";
        public string  Staff { get; set; } = "Staff";
    }
}