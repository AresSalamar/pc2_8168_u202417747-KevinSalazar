namespace CatchUpPlatform.API.Settlements.Domain.Model.ValueObjects;

public sealed record StoreIdentifier
{
    public Guid Value { get; }
    public StoreIdentifier(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("StoreIdentifier cannot be an empty GUID.", nameof(value));
        Value = value;
    }
    public override string ToString() => Value.ToString();
}