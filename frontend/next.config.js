/** @type {import('next').NextConfig} */
const nextConfig = {
  async rewrites() {
    return [
      {
        source: "/dotnet-api/:path*",
        destination: `${process.env.BACKEND_HOST}/:path*`,
      },
    ];
  },
};

module.exports = nextConfig;
