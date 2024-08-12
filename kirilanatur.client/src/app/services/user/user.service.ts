import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";

export interface Product {
  name: string | null;
  description: string | null;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl: string = 'https://localhost:44387/api/Users';
  constructor(private http: HttpClient) { }

  addUser(product: Product): Observable<any> {
    return this.http.post<{ message: string }>(`${this.apiUrl}`, product);
  }

  getUsers(): Observable<any> {
    return this.http.get(`${this.apiUrl}`);
  }

}
