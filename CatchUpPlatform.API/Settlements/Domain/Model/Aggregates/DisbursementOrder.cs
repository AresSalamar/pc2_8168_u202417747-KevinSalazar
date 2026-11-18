using CatchUpPlatform.API.Settlements.Domain.Model.Commands;
using CatchUpPlatform.API.Settlements.Domain.Model.ValueObjects;
using Microsoft.VisualBasic;

namespace CatchUpPlatform.API.Settlements.Domain.Model.Aggregates;

public partial class DisbursementOrder
{
    private const int UserMaxLength = 20;
    private const int RemarksMaxLength = 85;

    protected DisbursementOrder()
    {
        OrderTrackingCode = null!;
        AffiliateStoreId = null!;
        ExecutionSchedule = null!;
        TransferCap = null!;
        User = string.Empty;
    }

    public DisbursementOrder(CreateDisbursementOrderCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);
        ArgumentNullException.ThrowIfNull(command.OrderTrackingCode);
        ArgumentNullException.ThrowIfNull(command.AffiliateStoreId);
        ArgumentNullException.ThrowIfNull(command.ExecutionSchedule);
        ArgumentNullException.ThrowIfNull(command.TransferCap);

        if (string.IsNullOrWhiteSpace(command.User))
            throw new ArgumentException("User cannot be null, empty, or whitespace.", nameof(command));

        if (command.User.Length > UserMaxLength)
            throw new ArgumentException($"User cannot exceed {UserMaxLength} characters.", nameof(command));

        if (command.Remarks is not null && command.Remarks.Length > RemarksMaxLength)
            throw new ArgumentException($"Remarks cannot exceed {RemarksMaxLength} characters.", nameof(command));

        OrderTrackingCode = command.OrderTrackingCode;
        AffiliateStoreId = command.AffiliateStoreId;
        ExecutionSchedule = command.ExecutionSchedule;
        TransferCap = command.TransferCap;
        Status = command.Status ?? DisbursementStatus.Queued;
        User = command.User;
        Remarks = command.Remarks;
    }

    public int Id { get; private set; }
    public OpenpayReference OrderTrackingCode { get; private set; }
    public StoreIdentifier AffiliateStoreId { get; private set; }
    public DateInterval ExecutionSchedule { get; private set; }
    public FinancialAmount TransferCap { get; private set; }
    public DisbursementStatus Status { get; private set; }
    public string User { get; private set; }
    public string? Remarks { get; private set; }
}