using CatchUpPlatform.API.Settlements.Domain.Model.Aggregates;
using CatchUpPlatform.API.Settlements.Domain.Model.ValueObjects;
using CatchUpPlatform.API.Shared.Domain.Repositories;

namespace CatchUpPlatform.API.Settlements.Domain.Repositories;

public interface IDisbursementOrderRepository : IBaseRepository<DisbursementOrder>

{
    Task<bool> ExistsByOrderTrackingCodeAsync(OpenpayReference orderTrackingCode, CancellationToken cancellationToken = default);
    
}