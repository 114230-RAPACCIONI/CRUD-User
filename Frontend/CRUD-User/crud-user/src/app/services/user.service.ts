import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private readonly http = inject(HttpClient);


  getAllUsers(): Observable<User[]> {
    const url = "http://localhost:5288/users/getAllUser";
    return this.http.get<User[]>(url);
  } 

  getUserById(idUser: number): Observable<User> {
    const url = `http://localhost:5288/users/getUserById/${idUser}`;
    return this.http.get<User>(url);
  }

  createUser(user: User): Observable<User> {
    const url = "http://localhost:5288/users/createUser"
    return this.http.post<User>(url, user);
  }

  updateUser(user: User): Observable<User> {
    const url = `http://localhost:5288/users/updateUser/${user.id}`;
    console.log("user id ",  url)
    return this.http.put<User>(url, user);
  }

  deleteUsers(idUser: number): Observable<User> {
    const url = `http://localhost:5288/users/deleteUser/${idUser}`;
    return this.http.delete<User>(url);
  } 
}
