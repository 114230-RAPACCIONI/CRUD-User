import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private readonly http = inject(HttpClient);


  getAllUsers(): Observable<User[]> {
    const url = "http://localhost:5070/users/getAllUser";
    return this.http.get<User[]>(url);
  } 

  getUserById(idUser: number): Observable<User> {
    const url = `http://localhost:5070/users/getUserById/${idUser}`;
    return this.http.get<User>(url);
  }

  createUser(user: User): Observable<User> {
    const url = "http://localhost:5070/users/createUser"
    return this.http.post<User>(url, user);
  }

  updateUser(user: User): Observable<User> {
    const url = `http://localhost:5070/users/updateUser/${user.idUser}`;
    return this.http.put<User>(url, user);
  }

  deleteUser(idUser: number): Observable<User> {
    const url = `http://localhost:5070/users/deleteUser/${idUser}`;
    return this.http.delete<User>(url);
  } 
}
