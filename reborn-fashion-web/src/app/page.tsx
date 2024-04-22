import Link from "next/link";

export default function Home() {
  return (
    <main className="flex min-h-screen flex-col items-center justify-between font-mono bg-gradient-to-b from-slate-200 to-slate-100">
      <div className="sticky top-0 z-10 w-full items-center justify-between text-md flex bg-slate-100 p-8">
        <Link href={"/"} className="text-xl font-bold">
          Reborn Fashion
        </Link>
        <Link href={"/login"} className="text-green-500 hover:text-green-600">
          Login
        </Link>
      </div>

      <div className="flex-1">
        <div className="grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-4 pt-4 pb-4">
          {
            ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten"].map(n =>
              <Tile n={n} />)
          }
        </div>
      </div>
      {/* <div className="flex-1 flex items-center justify-center">
        <div>no listings...</div>
      </div> */}
    </main>
  );
}

function Tile(props: { n: string }) {
  return <div className="rounded-lg w-72 h-96 p-4">
    <img src="/poncho.jpg" alt="poncho" className="bg-fuchsia-200 size-64 rounded-lg" />
    <div className="text-lg font-bold pt-1">listing {props.n} this is a really long title</div>
    <div className="text-sm">closed</div>
  </div>
}