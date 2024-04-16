using Reborn.Fashion.Domain.Entities;

namespace Reborn.Fashion.Domain.Tests.Entities;

public class ListingTests
{
    [Fact]
    public void CreateListing_Open_Success()
    {
        var listing = new Listing();
        Assert.Equal(ListingStatus.Draft, listing.Status);
        listing.Open();
        Assert.Equal(ListingStatus.Live, listing.Status);
    }

    [Fact]
    public void CreateListing_Publish_Success()
    {
        var listing = new Listing();
        Assert.Equal(ListingStatus.Draft, listing.Status);
        listing.Publish();
        Assert.Equal(ListingStatus.Published, listing.Status);
    }

    [Fact]
    public void CreateListing_Close_Success()
    {
        var listing = new Listing();
        Assert.Equal(ListingStatus.Draft, listing.Status);
        listing.Open();
        Assert.Equal(ListingStatus.Live, listing.Status);
        listing.Close();
        Assert.Equal(ListingStatus.Closed, listing.Status);
    }

    [Fact]
    public void CreateListing_Close_NotOpen_Fail()
    {
        var listing = new Listing();
        Assert.Equal(ListingStatus.Draft, listing.Status);
        var ex = Assert.Throws<Exception>(listing.Close);
        Assert.Equal("Listing is not live", ex.Message);
    }

    [Fact]
    public void PlaceBid_NoReserve_Success()
    {
        var listing = new Listing();
        listing.Open();
        listing.PlaceBid(Guid.NewGuid(), 10.00M);
        Assert.Equal(10.00M, listing.CurrentBid?.Amount);
    }

    [Fact]
    public void PlaceBid_LessThanReserve_Fail()
    {
        var listing = new Listing() { Reserve = 10.00M };

        listing.Open();
        var ex = Assert.Throws<Exception>(() => listing.PlaceBid(Guid.NewGuid(), 9.00M));
        Assert.Equal("Reserve not met", ex.Message);
    }

    [Fact]
    public void PlaceBid_GreaterThanReserve_BidWins()
    {
        var listing = new Listing() { Reserve = 10.00M };

        listing.Open();
        listing.PlaceBid(Guid.NewGuid(), 11.00M);
        Assert.Equal(11.00M, listing.CurrentBid?.Amount);
    }

    [Fact]
    public void PlaceBid_LessThanExistingBid_Failure()
    {
        var listing = new Listing() { Reserve = 10.00M };

        listing.Open();
        listing.PlaceBid(Guid.NewGuid(), 12.00M);
        Assert.Equal(12.00M, listing.CurrentBid?.Amount);
        var ex = Assert.Throws<Exception>(() => listing.PlaceBid(Guid.NewGuid(), 11.00M));
        Assert.Equal("Bid too low", ex.Message);
    }

    [Fact]
    public void PlaceBid_GreaterThanExistingBid_Success()
    {
        var listing = new Listing() { Reserve = 10.00M };

        listing.Open();
        listing.PlaceBid(Guid.NewGuid(), 12.00M);
        Assert.Equal(12.00M, listing.CurrentBid?.Amount);
        listing.PlaceBid(Guid.NewGuid(), 13.00M);
        Assert.Equal(13.00M, listing.CurrentBid?.Amount);
    }
}
