namespace OptiLoan.enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrganizationClass
    {
        Agent,
        SuperAgent,
        MasterAgent,
        Staff
    }
}