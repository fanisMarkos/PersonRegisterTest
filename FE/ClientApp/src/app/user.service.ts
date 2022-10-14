import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User, UserCreateEdit, UserTitle, UserType } from './Interfaces/UserInterfaces';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  public apiUrl: string = environment.domain;
  constructor(private http: HttpClient) { }


  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl + "api/User")
  }

  createUser(data: UserCreateEdit): Observable<void> {

    return this.http.post<void>(this.apiUrl + "api/User/Create", data)
  }

  getUserByid(id: number): Observable<UserCreateEdit> {
    return this.http.get<User>(this.apiUrl + `api/User/${id}`)
  }

  updateUser(data: UserCreateEdit): Observable<void> {
    return this.http.put<void>(this.apiUrl + `api/User/Update/${data.id}`, data)
  }

  deleteUser(id: number | undefined): Observable<void> {
    return this.http.delete<void>(this.apiUrl + `api/User/Delete/${id}`)
  }

  getUserTitles(): Observable<UserTitle[]> {
    return this.http.get<UserTitle[]>(this.apiUrl + "api/User/UserTitles")
  }

  getUserTypes(): Observable<UserType[]> {
    return this.http.get<UserType[]>(this.apiUrl + "api/User/UserTypes")
  }
}
