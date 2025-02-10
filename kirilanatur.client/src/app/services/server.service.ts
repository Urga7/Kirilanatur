import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { lastValueFrom, Observable } from "rxjs";
import { ServerResponse } from "../models/server-response";

export enum ControllerFunction {
  GetProducts = "/api/Products/GetProducts",
  AddProduct = "/api/Products/AddProduct",
  RegisterUser = "/api/Users/Register",
  GetUsers = "/api/Users/GetUsers",
  LoginUser = "/login",
}

export enum RequestMethodType {
  "GET" = 0,
  "POST" = 1
}

@Injectable({
  providedIn: 'root'
})
export class ServerService {

  private serverUrl: string = 'https://localhost:44387';
  constructor(private httpClient: HttpClient) { }

  async ExecuteServerFunction(controllerFunction: ControllerFunction, parameters: any = null, method: RequestMethodType = RequestMethodType.GET): Promise<any> {
    let response: Observable<ServerResponse>;
    switch(method) {
      case RequestMethodType.GET:
        response = this.httpClient.get<ServerResponse>(`${this.serverUrl}${controllerFunction}`);
        break;

      case RequestMethodType.POST:
        response = this.httpClient.post<ServerResponse>(`${this.serverUrl}${controllerFunction}`, parameters);
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
