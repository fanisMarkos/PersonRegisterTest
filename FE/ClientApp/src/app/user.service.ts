import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './user-list/user-list.component';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http : HttpClient) { }

  getUsers(): Observable<User[]>
  {
     return this.http.get<User[]>("https://localhost:7193/api/User")
  }
}
