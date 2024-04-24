'use client'

export default function Error({
  error,
  reset,
}: {
  error: Error & { digest?: string }
  reset: () => void
}) {
  return (
    <div className="flex-1 flex items-center">
      <div className="">
        <h2>Something went wrong!</h2>

      </div>
    </div>
  )
}