// /Shared/Crypto/PaymentModels.cs
using System.Numerics;

namespace YourApp.Shared.Crypto;

public record PaymentRequest(
    string RpcUrl,
    string TokenContract,    // ERC-20 (USDT/USDC)
    string MerchantAddress,  // dirección que recibe el pago
    decimal ExpectedAmount,  // en unidades humanas (p.ej. 7.00 USDT)
    string? OrderId = null,
    uint ConfirmationsRequired = 3,
    ulong LookbackBlocks = 10_000 // rango a revisar hacia atrás
);

public enum PaymentState { Pending, Confirmed, Failed, Timeout }

public record PaymentResult(
    PaymentState State,
    string? TransactionHash = null,
    decimal Amount = 0m,
    string? From = null,
    string? To = null,
    string? Message = null
);
