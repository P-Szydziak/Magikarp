using FastEndpoints;
using MagikarpService.Contracts.Requests;
using MagikarpService.Contracts.Responses;
using MagikarpService.Mapping;
using MagikarpService.Services;
using Microsoft.AspNetCore.Authorization;

namespace Customers.Api.Endpoints;

[HttpPost("karpTransaction"), AllowAnonymous]
public class CreateKarpTransactionEndpoint : Endpoint<CreateKarpTransactionRequest, KarpTransactionResponse>
{
    private readonly IKarpTransactionService _karpTransactionService;

    public CreateKarpTransactionEndpoint(IKarpTransactionService karpTransactionService)
    {
        _karpTransactionService = karpTransactionService;
    }

    public override async Task HandleAsync(CreateKarpTransactionRequest req, CancellationToken ct)
    {
        var karpTransaction = req.ToKarpTransaction();

        await _karpTransactionService.CreateAsync(karpTransaction);

        var customerResponse = karpTransaction.ToKarpTransactionResponse();
        await SendCreatedAtAsync<GetKarpTransactionEndpoint>(
            new { Id = karpTransaction.Id }, customerResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}
