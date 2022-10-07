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

  createUser(data :User):Observable<void>{

    return this.http.post<void>("https://localhost:7193/api/User/Create",data)
  }

  getUserByid(id:number):Observable<User>
  {
     return this.http.get<User>(`https://localhost:7193/api/User/${id}`)
  }

  updateUser(data :User):Observable<void>
  {
    return this.http.put<void>(`https://localhost:7193/api/User/Update/${data.id}`,data)
  }

  deleteUser(id:number|undefined):Observable<void>
  {
    return this.http.delete<void>(`https://localhost:7193/api/User/Delete/${id}`)
  }
}
