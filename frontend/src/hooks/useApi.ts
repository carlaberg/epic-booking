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
      Authorization: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIyYjhmZmExMC0zMjA2LTQ2YzUtYWE5Yy03NTQzODM5ZWVhZDMiLCJ1bmlxdWVfbmFtZSI6ImNhbGxlc2JyZXZib3hAaG90bWFpbC5jb20iLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE3MDM3ODQ5MDYsImV4cCI6MTcwNDM4OTcwNiwiaWF0IjoxNzAzNzg0OTA2fQ.11uzF2bh1kjWmnGPBT3YGWGsHmb1eL6YzjuArVMVlbo`,
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
