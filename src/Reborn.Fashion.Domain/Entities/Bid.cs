namespace Reborn.Fashion.Domain.Entities;

public class Bid
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public decimal Amount { get; private set; }
    public bool IsCurrent { get; internal set; }

    public Bid(Guid userId, decimal amount, bool isCurrent)
    {
        UserId = userId;
        Amount = amount;
        IsCurrent = isCurrent;
    }
}
