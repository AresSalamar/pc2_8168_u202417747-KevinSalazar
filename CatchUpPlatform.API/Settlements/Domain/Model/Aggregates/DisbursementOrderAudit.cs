using CatchUpPlatform.API.Shared.Domain.Model;

namespace CatchUpPlatform.API.Settlements.Domain.Model.Aggregates;

public partial class DisbursementOrder : IAuditableEntity
{
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}