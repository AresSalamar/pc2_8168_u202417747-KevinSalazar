namespace CatchUpPlatform.API.Settlements.Domain.Model.ValueObjects;

public sealed record OpenpayReference
{
    public Guid Value { get; }

    public OpenpayReference(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("OpenpayReference cannot be an empty GUID.", nameof(value));
        Value = value;
    }
    public override string ToString() => Value.ToString();
}