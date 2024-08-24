import { Injectable } from '@angular/core';
import { ServerResponse } from "../../models/ServerResponse.model";
import { HttpClient } from "@angular/common/http";
import { lastValueFrom, Observable } from "rxjs";

export enum ControllerFunction {
  GetProducts = "Products/GetProducts",
  AddProduct = "Products/AddProduct",
}

export enum RequestMethodType {
  "GET" = 0,
  "POST" = 1
}

@Injectable({
  providedIn: 'root'
})
export class ServerService {

  private serverUrl: string = 'https://localhost:44387/api/';
  constructor(private httpClient: HttpClient) { }

  async ExecuteServerFunction(functionName: string, parameters: any = null, method: RequestMethodType = RequestMethodType.GET): Promise<any> {
    let response: Observable<ServerResponse>;
    switch(method) {
      case RequestMethodType.GET:
        response = this.httpClient.get<ServerResponse>(`${this.serverUrl}${functionName}`);
        break;

      case RequestMethodType.POST:
        response = this.httpClient.post<ServerResponse>(`${this.serverUrl}${functionName}`, parameters);
        break;

      default:
        throw new Error("Unknown method: " + method);
    }

    try {
      const completeResponse = await lastValueFrom(response);
      if(completeResponse.isError)
        console.error("Server Error: " + completeResponse.messages.toString());

      return completeResponse.data;
    } catch(error) {
      console.error("Any error occured", error);
    }
  }
}
