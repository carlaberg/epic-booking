/** @type {import('next').NextConfig} */
const nextConfig = {
  async rewrites() {
    console.log(process.env.BACKEND_HOST);
    return [
      {
        source: "/dotnet-api/:path*",
        destination: `${process.env.BACKEND_HOST}/:path*`,
      },
    ];
  },
};

module.exports = nextConfig;
