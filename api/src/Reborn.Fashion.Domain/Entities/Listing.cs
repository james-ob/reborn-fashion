using Reborn.Fashion.Domain.ValueObjects;

namespace Reborn.Fashion.Domain.Entities;

public enum ListingStatus
{
    Draft = 1,
    Published = 2,
    Live = 3,
    Closed = 4
}

public class Listing
{
    public Guid Id { get; private set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageSrc { get; set; }
    public ListingStatus Status { get; private set; } = ListingStatus.Draft;
    public DateRange DateRange { get; set; }
    public List<Bid> Bids { get; } = new List<Bid>();
    public Bid CurrentBid => Bids.Find(b => b.IsCurrent);
    public decimal? Reserve { get; set; }

    public void Publish()
    {
        if (Status == ListingStatus.Published)
            return;

        if (Status != ListingStatus.Draft)
            throw new Exception("Listing cannot be published at this stage");

        Status = ListingStatus.Published;
    }

    public void Open()
    {
        if (Status == ListingStatus.Live)
            return;

        if (Status == ListingStatus.Closed)
            throw new Exception("Listing is closed");

        Status = ListingStatus.Live;
    }

    public void Close()
    {
        if (Status == ListingStatus.Closed)
            return;

        if (Status != ListingStatus.Live)
            throw new Exception("Listing is not live");

        Status = ListingStatus.Closed;
    }

    private Guid AddNewBid(Guid userId, decimal amount)
    {
        var newBid = new Bid(userId, amount, true);

        if (CurrentBid is not null)
            CurrentBid.IsCurrent = false;

        Bids.Add(newBid);
        return newBid.Id;
    }

    public Guid PlaceBid(Guid userId, decimal amount)
    {
        if (Status != ListingStatus.Live)
            throw new Exception("Listing is not taking bids");

        if (amount < 0)
            throw new Exception("Bid too low");

        if (CurrentBid is null && Reserve is not null && amount < Reserve)
            throw new Exception("Reserve not met");

        if (CurrentBid is not null && amount <= CurrentBid.Amount)
            throw new Exception("Bid too low");

        return AddNewBid(userId, amount);
    }
}
