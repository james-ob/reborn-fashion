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
}
