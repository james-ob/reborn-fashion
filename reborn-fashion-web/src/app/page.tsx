interface Listing {
  id: string,
  title: string,
  description: string,
  imageSrc: string,
  start: Date,
  end: Date,
  status: string
}

async function getListings() {
  const res = await fetch('http://localhost:5157/listings', { cache: 'no-store' });
  if (!res.ok)
    throw new Error("Failed to fetch listings");

  const listings = await res.json() as Listing[];
  return [];
}


export default async function Home() {
  let listings = await getListings();

  if (listings.length == 0)
    return (
      <div className="h-fill">
        <div className="">no listings...</div>
      </div>
    );

  return (
    <div className="grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-4 pt-4 pb-4">
      {
        listings.sort((a, b) => a.end > b.end ? -1 : 1).map(l =>
          <Tile listing={l} key={l.id} />)
      }
    </div>
  );
}

function Tile(props: { listing: Listing }) {
  const listing = props.listing;
  return <div className="rounded-lg w-72 h-96 p-4">
    <img src={listing.imageSrc} alt={listing.title} className="bg-slate-200 size-64 rounded-lg object-cover" />
    <div className="text-lg font-bold pt-1">{listing.title}</div>
    <div className="text-sm">{listing.status}</div>
  </div>
}