import { NextRequest, NextResponse } from "next/server";
import { isAuthorized } from "./lib/auth";

export const config = {
  matcher: ["/bookings/:path*"],
};

export async function middleware(req: NextRequest) {
  const token = req.cookies.get("token");

  if (!token) {
    return NextResponse.redirect(new URL("/login", req.url));
  }

  const allowed = await isAuthorized(token.value);

  if (!allowed) {
    return NextResponse.redirect(new URL('/login', req.url));
  }

  return NextResponse.next();
}
