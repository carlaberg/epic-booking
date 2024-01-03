import Cookies from "js-cookie";
import * as jose from "jose";
import { useEffect, useState } from "react";

type User = {
    nameid: string;
}

export function useUser() {
  const [user, setUser] = useState<User | undefined>();

  useEffect(() => {
    const token = Cookies.get("token");

    if (!token) {
      throw new Error('You need to be logged in');
    }
    setUser(jose.decodeJwt(token));
  }, []);

  return user;
}
