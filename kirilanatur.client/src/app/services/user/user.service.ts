import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { RequestMethodType, ServerService } from "../server/server.service";

export interface TmpProduct {
  name: string | null;
  description: string | null;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private serverService: ServerService) { }

  /*async addUser(product: TmpProduct): Promise<any> {
    return await this.serverService.ExecuteServerFunction("Users/AddProduct", product, RequestMethodType.POST);
  }

  async getUsers(): Promise<any> {
    return await this.serverService.ExecuteServerFunction("Users/GetProducts", {}, RequestMethodType.GET);
  }*/

}
