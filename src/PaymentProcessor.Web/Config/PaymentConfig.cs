namespace YourApp.Shared.Crypto;

public class PaymentConfig
{
    public string[] SupportedTokens { get; set; } = Array.Empty<string>();
    public NetworkConfig[] Networks { get; set; } = Array.Empty<NetworkConfig>();
}

public class NetworkConfig
{
    public string Name { get; set; } = "";
    public string RpcUrl { get; set; } = "";
    public string MerchantAddress { get; set; } = "";
    public Dictionary<string, string> TokenContracts { get; set; } = new();
}