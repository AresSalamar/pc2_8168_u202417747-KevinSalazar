using CatchUpPlatform.API.Settlements.Domain.Model.ValueObjects;
using CatchUpPlatform.API.Shared.Domain.Model.ValueObjects;
using Microsoft.VisualBasic;

namespace CatchUpPlatform.API.Settlements.Domain.Model.Commands;

public record CreateDisbursementOrderCommand(
    OpenpayReference OrderTrackingCode,
    StoreIdentifier AffiliateStoreId,
    DateInterval ExecutionSchedule,
    FinancialAmount TransferCap,
    DisbursementStatus? Status,
    string User,
    string? Remarks);

