using FastEndpoints;
using MagikarpService.Contracts.Requests;
using MagikarpService.Services;
using Microsoft.AspNetCore.Authorization;

namespace Customers.Api.Endpoints;

[HttpDelete("karpTransaction/{id:guid}"), AllowAnonymous]
public class DeleteKarpTransactionEndpoint : Endpoint<DeleteKarpTransactionRequest>
{
    private readonly IKarpTransactionService _karpTransactionService;

    public DeleteKarpTransactionEndpoint(IKarpTransactionService karpTransactionService)
    {
        _karpTransactionService = karpTransactionService;
    }

    public override async Task HandleAsync(DeleteKarpTransactionRequest req, CancellationToken ct)
    {
        var deleted = await _karpTransactionService.DeleteAsync(req.Id);
        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}
