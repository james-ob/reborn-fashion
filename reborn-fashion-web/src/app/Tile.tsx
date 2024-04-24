import { Countdown } from "./Countdown";
import { Listing, ListingStatus, } from "./page";

export function Tile(props: { listing: Listing; }) {
    const listing = props.listing;
    return <div className="rounded-lg w-72 h-96 p-4 bg-slate-200">
        <img src={listing.imageSrc} alt={listing.title} className="bg-slate-200 size-64 rounded-lg object-cover" />
        <div className="text-lg  pt-1 h-14">{listing.title}</div>
        <div className="w-full flex justify-between mt-2">
            {listing.status == ListingStatus.Live && <BidPanel listing={listing} />}
            <Status listing={listing} />
        </div>
    </div>;
}

function BidPanel(props: { listing: Listing }) {
    return <div>
        <div className="font-bold">£4.54</div>
        <div className="text-sm">3 bids</div>
    </div>
}

function Status(props: { listing: Listing; }) {
    const listing = props.listing;
    if (listing.status == ListingStatus.Live) return <Countdown end={new Date(listing.end)} />;
    if (listing.status == ListingStatus.Published) return <div className="text-sm">opens {new Date(listing.start).toLocaleDateString()}</div>;
    return <div className="text-sm">{listing.status}</div>
}

