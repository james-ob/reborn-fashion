interface Listing {
  id: string,
  title: string,
  imageSrc: string,
  state: string
}


export default function Home() {
  const listings: Listing[] = [
    {
      id: "675ce57f-a5b5-425a-8c32-339ee87f7df2",
      title: "A Cool Poncho",
      imageSrc: "/poncho.avif",
      state: "Closed"
    },
    {
      id: "d08109ab-ea1b-4e6e-9751-98a8c2bfab32",
      title: "Old Grey Hoodie",
      imageSrc: "/grey-hoodie.avif",
      state: "Closed"
    },
    {
      id: "98409de6-598f-4150-8f7b-d8c8d22bc744",
      title: "Vintage Levi's",
      imageSrc: "/vintage-levis.avif",
      state: "Closed"
    },
    {
      id: "e6fe4761-c53a-447f-aeef-a921b98397e9",
      title: "Denim Dungarees with Front Pocket and Logo",
      imageSrc: "/denim-dungarees.avif",
      state: "Closed"
    },
    {
      id: "f8c033ed-d57e-457b-95f1-fe3b2afdc2c0",
      title: "Baggy Beige Overcoat",
      imageSrc: "/beige-overcoat.avif",
      state: "Closed"
    },
    {
      id: "2f9c1f5b-b519-4d67-bf03-844d55833075",
      title: "Fitted Leather Jacket",
      imageSrc: "/leather-jacket.avif",
      state: "Closed"
    },
    {
      id: "41e1d3cb-ad12-45ac-8ae2-019ab94f8ac2",
      title: "Black and White Patterned Jacket",
      imageSrc: "/patterned-jacket.avif",
      state: "Closed"
    },
    {
      id: "41e1d3cb-ad12-45ac-8ae2-019ab94f8ac2",
      title: "Orange Folk Skirt",
      imageSrc: "/folk-skirt.avif",
      state: "Closed"
    },
    {
      id: "41e1d3cb-ad12-45ac-8ae2-019ab94f8ac2",
      title: "Tribal Knit",
      imageSrc: "/tribal-knitwear.avif",
      state: "Closed"
    },
    {
      id: "41e1d3cb-ad12-45ac-8ae2-019ab94f8ac2",
      title: "Maxi Print",
      imageSrc: "/patterned-dress.avif",
      state: "Closed"
    }
  ]

  if (listings.length == 0)
    return (
      <div className="flex-1 flex items-center justify-center">
        <div>no listings...</div>
      </div>
    );

  return (
    <div className="flex-1">
      <div className="grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-4 pt-4 pb-4">
        {
          listings.map(l =>
            <Tile listing={l} key={l.id} />)
        }
      </div>
    </div>
  );
}

function Tile(props: { listing: Listing }) {
  const listing = props.listing;
  return <div className="rounded-lg w-72 h-96 p-4">
    <img src={listing.imageSrc} alt={listing.title} className="bg-slate-200 size-64 rounded-lg object-cover" />
    <div className="text-lg font-bold pt-1">{listing.title}</div>
    <div className="text-sm">{listing.state}</div>
  </div>
}