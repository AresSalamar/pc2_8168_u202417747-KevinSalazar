using CatchUpPlatform.API.Settlements.Domain.Model.Aggregates;
using CatchUpPlatform.API.Settlements.Domain.Model.ValueObjects;
using CatchUpPlatform.API.Settlements.Domain.Repositories;
using CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatchUpPlatform.API.Settlements.Infrastructure.EFC.Repositories;

public class DisbursementOrderRepository(AppDbContext context)
    : BaseRepository<DisbursementOrder>(context), IDisbursementOrderRepository
{
    public async Task<bool> ExistsByOrderTrackingCodeAsync(OpenpayReference orderTrackingCode, CancellationToken cancellationToken = default)
    {
        return await Context.Set<DisbursementOrder>()
            .AnyAsync(d => d.OrderTrackingCode == orderTrackingCode, cancellationToken);
    }
}