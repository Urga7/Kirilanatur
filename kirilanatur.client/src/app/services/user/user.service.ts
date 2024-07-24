import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";

export interface User {
  name: string | null;
  surname: string | null;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = 'https://localhost:44387/api/Users';
  constructor(private http: HttpClient) { }

  addUser(user: User): Observable<any> {
    return this.http.post<{ message: string }>(this.apiUrl, user);
  }

}
