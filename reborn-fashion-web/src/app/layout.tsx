import type { Metadata } from "next";
import "./globals.css";
import Link from "next/link";


export const metadata: Metadata = {
  title: "Reborn Fashion",
  description: "Clothes Reincarnated",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body >
        <main className="flex min-h-screen flex-col items-center justify-between font-mono bg-gradient-to-b from-slate-200 to-slate-100">
          <div className="sticky top-0 z-10 w-full items-center justify-between text-md flex bg-slate-100 p-8">
            <Link href={"/"} className="text-xl font-bold">
              Reborn Fashion
            </Link>
            <div className="space-x-4">
              <Link href={"/login"} className="text-green-500 hover:text-green-600">
                Register
              </Link>
              <Link href={"/login"} className="text-green-500 hover:text-green-600">
                Login
              </Link>
            </div>
          </div>
          {children}
        </main>
      </body>
    </html>
  );
}
