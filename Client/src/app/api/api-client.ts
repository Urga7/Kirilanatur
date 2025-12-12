import { HttpClient, HttpParams, HttpResponse } from "@angular/common/http";
import { catchError, lastValueFrom, Observable, throwError, timeout, TimeoutError } from "rxjs";

export interface ApiResponse<T> {
  statusCode: number;
  data: T;
  errorData: any
}

export enum HttpRequestMethodType {
  GET,
  POST,
  PUT,
  DELETE,
  PATCH,
}

export class ApiClient {
  constructor(
    private readonly httpClient: HttpClient,
    private readonly apiUrl: string,
    private readonly timeout: number = 80 * 1000 // 50 seconds
  ) {
  }

  public async callApi<T>(
    endpoint: string,
    urlParams: { [key: string]: any } = {},
    method: HttpRequestMethodType = HttpRequestMethodType.GET,
    body: any = undefined,
    queryParams?: { [key: string]: any }
  ): Promise<ApiResponse<T>> {
    try {
      const requestPath: string = this.constructUrl(this.apiUrl + endpoint, urlParams)
      let response$: Observable<HttpResponse<T>>

      const httpOptions: {
        observe: 'response';
        params?: HttpParams | Record<string, any>;
      } = {observe: 'response'};

      if (queryParams) {
        this.addQueryParams(httpOptions, queryParams)
      }

      switch (method) {
        case HttpRequestMethodType.GET:
          response$ = this.httpClient.get<T>(requestPath, httpOptions)
          break
        case HttpRequestMethodType.POST:
          response$ = this.httpClient.post<T>(requestPath, body, httpOptions)
          break
        case HttpRequestMethodType.PUT:
          response$ = this.httpClient.put<T>(requestPath, body, httpOptions)
          break
        case HttpRequestMethodType.DELETE:
          response$ = this.httpClient.delete<T>(requestPath, httpOptions)
          break
        case HttpRequestMethodType.PATCH:
          response$ = this.httpClient.patch<T>(requestPath, body, httpOptions)
          break
        default:
          return {
            statusCode: 400,
            errorData: `Unknown method: ${method}`
          } as ApiResponse<T>
      }

      const response = await lastValueFrom(
        response$.pipe(timeout(this.timeout), catchError(err => throwError(() => err)))
      );

      return {
        statusCode: response.status,
        data: response.body,
      } as ApiResponse<T>

    } catch (error: any) {
      return this.HandleError<T>(error)
    }
  }

  private HandleError<T>(error: any): ApiResponse<T> {
    if (error instanceof TimeoutError) {
      return {
        statusCode: 408,
        errorData: `Request timed out after ${this.timeout / 1000} seconds`,
      } as ApiResponse<T>
    }

    const statusCode = error.status ?? 500
    if (statusCode === 500) {
      console.error('Internal server error:', error)
    }

    if (error.error?.detail) {
      return {
        statusCode,
        errorData: error.error.detail,
      } as ApiResponse<T>
    }

    return {
      statusCode,
      errorData: error.error ?? 'Unknown error occurred',
    } as ApiResponse<T>
  }

  private addQueryParams(httpOptions: any, queryParams?: { [key: string]: any }) {
    const filteredParams: { [key: string]: any } = {}
    for (const key in queryParams) {
      if (Object.prototype.hasOwnProperty.call(queryParams, key) &&
        queryParams[key] !== null &&
        queryParams[key] !== undefined) {
        filteredParams[key] = queryParams[key]
      }
    }

    if (Object.keys(filteredParams).length > 0) {
      httpOptions.params = filteredParams
    }
  }

  private constructUrl(url: string, params: { [key: string]: any }): string {
    Object.keys(params).forEach(key => {
      url = url.replace(`:${key}`, encodeURIComponent(params[key]));
    })

    return url
  }
}
