namespace Infrastructure.Configuration
{
    internal class FakeStoreClientConfigurationModel
    {
        public const string SectionName = "FakeStoreClient";
        public string BaseAddress { get; set; } = string.Empty;
    }
}
