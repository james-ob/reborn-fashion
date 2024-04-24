import { Tile } from "./Tile";

export enum ListingStatus {
  Draft = "Draft",
  Published = "Published",
  Live = "Live",
  Closed = "Closed"
}

export interface Listing {
  id: string,
  title: string,
  description: string,
  imageSrc: string,
  start: string,
  end: string,
  status: ListingStatus
}

export default async function Home() {
  let listings = await getListings();

  if (listings.length == 0)
    return <NoListings />;

  return <ListingsGrid listings={listings} />
}

function ListingsGrid(props: { listings: Listing[] }) {
  return <div className="grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-4 pt-4 pb-4">
    {props.listings.sort(sortListings).map(l => <Tile listing={l} key={l.id} />)}
  </div>;
}

function NoListings() {
  return <div className="flex-1 flex items-center">
    <div>no listings...</div>
  </div>;
}

async function getListings() {
  const res = await fetch('http://localhost:5157/listings', { cache: 'no-store' });
  if (!res.ok)
    throw new Error("Failed to fetch listings");

  const listings = await res.json() as Listing[];
  return listings;
}

function sortListings(a: Listing, b: Listing) {
  if (a.status == b.status)
    return a.status == ListingStatus.Live ? sortLiveListings(a, b) : sortNonLiveListings(a, b);

  return a.status == ListingStatus.Live ? -1 : 1;
}

const sortLiveListings = (a: Listing, b: Listing) => a.end > b.end ? 1 : -1;

const sortNonLiveListings = (a: Listing, b: Listing) => a.start > b.start ? 1 : -1;

