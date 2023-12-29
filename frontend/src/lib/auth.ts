import { jwtVerify } from "jose";

export async function isAuthorized(token: string): Promise<boolean> {
  try {
    const secret = new TextEncoder().encode(process.env.JWT_SECRET);
    await jwtVerify(token, secret);

    return true;
  } catch (error) {
    return false;
  }
}
