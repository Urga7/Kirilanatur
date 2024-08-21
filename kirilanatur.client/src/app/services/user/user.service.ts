import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { ServerService } from "../server/server.service";

export interface Product {
  name: string | null;
  description: string | null;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl: string = 'https://localhost:44387/api/Users';
  constructor(private http: HttpClient, private serverService: ServerService) { }

  async addUser(product: Product): Promise<any> {
    return await this.serverService.ExecuteServerFunction("Users", product, "POST");
  }

  getUsers(): Observable<any> {
    return this.http.get(`${this.apiUrl}`);
  }

}
