using FastEndpoints;
using MagikarpService.Contracts.Responses;
using MagikarpService.Services;
using Microsoft.AspNetCore.Authorization;

namespace Customers.Api.Endpoints;

[HttpGet("karpTransactions"), AllowAnonymous]
public class GetAlKarpTransactionEndpoint : EndpointWithoutRequest<GetAllKarpTransactionsResponse>
{
    private readonly IKarpTransactionService _karpTransactionService;

    public GetAlKarpTransactionEndpoint(IKarpTransactionService karpTransactionService)
    {
        _karpTransactionService = karpTransactionService;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var karpTransactions = await _karpTransactionService.GetAllAsync();
        var karpTransactionsResponse = karpTransactions.ToKarpTransactionsResponse();
        await SendOkAsync(karpTransactionsResponse, ct);
    }
}
