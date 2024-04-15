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
    public ListingStatus Status { get; private set; } = ListingStatus.Draft;

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
}
