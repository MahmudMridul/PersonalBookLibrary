// app/components/Layout.js
export default function Layout({ children }) {
  return (
    <div className="min-h-screen bg-gray-100 flex items-center justify-center">
      <div className="max-w-md w-full">{children}</div>
    </div>
  );
}
