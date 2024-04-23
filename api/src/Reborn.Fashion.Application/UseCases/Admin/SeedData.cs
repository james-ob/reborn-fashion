using Reborn.Fashion.Domain.Entities;
using Reborn.Fashion.Domain.ValueObjects;

public static class SeedData
{
    public static Listing[] Listings =>
        [
            new()
            {
                Title = "Old Poncho",
                Description = "A cool old poncho from Mexico.",
                ImageSrc = "/poncho.avif",
                DateRange = new DateRange(DateTime.UtcNow, DateTime.UtcNow.AddMinutes(1))
            },
            new()
            {
                Title = "Old Grey Hoodie",
                Description = "It's seen better days!",
                ImageSrc = "/grey-hoodie.avif",
                DateRange = new DateRange(DateTime.UtcNow, DateTime.UtcNow.AddHours(1))
            },
            new()
            {
                Title = "Vintage Levi's",
                Description = "32 inch waist, ready for the club.",
                ImageSrc = "/vintage-levis.avif",
                DateRange = new DateRange(
                    DateTime.UtcNow.AddMinutes(2),
                    DateTime.UtcNow.AddMinutes(30)
                )
            },
            new()
            {
                Title = "Denim Dungarees with Front Pocket and Logo",
                Description = "32 inch waist, ready for the club.",
                ImageSrc = "/denim-dungarees.avif",
                DateRange = new DateRange(
                    DateTime.UtcNow.AddMinutes(5),
                    DateTime.UtcNow.AddMinutes(20)
                )
            },
            new()
            {
                Title = "Baggy Beige Overcoat",
                Description = "Perfect for autumn.",
                ImageSrc = "/beige-overcoat.avif",
                DateRange = new DateRange(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2))
            },
            new()
            {
                Title = "Fitted Leather Jacket",
                Description = "Size M, well loved.",
                ImageSrc = "/leather-jacket.avif",
                DateRange = new DateRange(DateTime.UtcNow.AddHours(2), DateTime.UtcNow.AddHours(5))
            },
            new()
            {
                Title = "Black and White Patterned Jacket",
                Description = "Exquisite design.",
                ImageSrc = "/patterned-jacket.avif",
                DateRange = new DateRange(DateTime.UtcNow.AddHours(-1), DateTime.UtcNow.AddHours(4))
            },
            new()
            {
                Title = "Orange Folk Skirt",
                Description = "Hippy Chick.",
                ImageSrc = "/folk-skirt.avif",
                DateRange = new DateRange(DateTime.UtcNow.AddDays(5), DateTime.UtcNow.AddDays(10))
            },
            new()
            {
                Title = "Tribal Knit",
                Description = "For cool nights by the beach.",
                ImageSrc = "/tribal-knitwear.avif",
                DateRange = new DateRange(DateTime.UtcNow.AddDays(5), DateTime.UtcNow.AddDays(10))
            },
            new()
            {
                Title = "Maxi Print",
                Description = "Look great in the office.",
                ImageSrc = "/patterned-dress.avif",
                DateRange = new DateRange(DateTime.UtcNow.AddDays(5), DateTime.UtcNow.AddDays(10))
            }
        ];
}
