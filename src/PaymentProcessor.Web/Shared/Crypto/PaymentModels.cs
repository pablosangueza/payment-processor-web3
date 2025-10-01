// /Shared/Crypto/PaymentModels.cs
using System.Numerics;

namespace YourApp.Shared.Crypto;

public class PaymentRequest
{
    public string RpcUrl { get; set; } = "";
    public string TokenContract { get; set; } = "";
    public string MerchantAddress { get; set; } = "";
    public decimal ExpectedAmount { get; set; }
    public string? OrderId { get; set; }
    public uint ConfirmationsRequired { get; set; } = 3;
    public ulong LookbackBlocks { get; set; } = 10_000;
    public string TokenSymbol { get; set; } = "USDT";
    public string NetworkName { get; set; } = "Ethereum";

    
}

public enum PaymentState { Pending, Confirmed, Failed, Timeout }

public record PaymentResult(
    PaymentState State,
    string? TransactionHash = null,
    decimal Amount = 0m,
    string? From = null,
    string? To = null,
    string? Message = null
);