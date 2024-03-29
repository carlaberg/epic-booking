import Cookies from "js-cookie";
import { sharedFetch } from "../lib/sharedFetch";
import useSWR from "swr";

interface ApiHookResult<UseApiResponse> {
  data: UseApiResponse;
  error: Error;
  isLoading: boolean;
  mutate: () => {};
}

interface UseApiRequest<UseApiRequestBody> {
  path: string;
  body?: UseApiRequestBody;
  method?: string;
}

interface ApiFetcherProps {
  path: string;
  method?: string;
  body?: any;
}

export const apiFetcher = async <T = any>({
  path,
  method,
  body,
}: ApiFetcherProps): Promise<T> => {
  let options: RequestInit = {
    headers: {
      Authorization: `Bearer ${Cookies.get("token")}`,
      "Content-Type": "application/json",
    },
  };

  if (body) {
    options.body = JSON.stringify(body);
  }
  
  if (method) {
    options.method = method;
  }

  return sharedFetch(`/dotnet-api${path}`, options);
};

export const useApi = <UseApiResponse, UseApiRequestBody = any>({
  path,
}: UseApiRequest<UseApiRequestBody>): ApiHookResult<UseApiResponse> => {
  const { data, error, mutate } = useSWR(path, () => apiFetcher({ path }));
  return { data, error, isLoading: !data && !error, mutate };
};
