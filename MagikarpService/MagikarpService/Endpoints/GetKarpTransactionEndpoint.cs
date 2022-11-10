using FastEndpoints;
using MagikarpService.Contracts.Requests;
using MagikarpService.Contracts.Responses;
using MagikarpService.Services;
using Microsoft.AspNetCore.Authorization;

namespace Customers.Api.Endpoints;

[HttpGet("karpTransaction/{id:guid}"), AllowAnonymous]
public class GetKarpTransactionEndpoint : Endpoint<GetKarpTransactionRequest, KarpTransactionResponse>
{
    private readonly IKarpTransactionService _karpTransactionService;

    public GetKarpTransactionEndpoint(IKarpTransactionService karpTransactionService)
    {
        _karpTransactionService = karpTransactionService;
    }

    public override async Task HandleAsync(GetKarpTransactionRequest req, CancellationToken ct)
    {
        var karpTransaction = await _karpTransactionService.GetAsync(req.Id);

        if (karpTransaction is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var karpTransactionResponse = karpTransaction.ToKarpTransactionResponse();
        await SendOkAsync(karpTransactionResponse, ct);
    }
}
