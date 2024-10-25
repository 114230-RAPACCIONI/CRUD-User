import { Component, inject, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-list-component',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './list-component.component.html',
  styleUrl: './list-component.component.css'
})
export class ListComponentComponent implements OnInit {


  private readonly service = inject(UserService);
  private readonly router = inject(Router);

  users: User[] = [];

  ngOnInit(): void {
    this.getAllUsers();
  }


  getAllUsers() {
    this.service.getAllUsers().subscribe({
      next: (response: any) => {
        this.users = response.data || [];
      },
      error: () => {
        this.users = []
      }
    });
  }

  deleteUser(idUser?: number) {
    if(idUser == null) return;
    this.service.deleteUser(idUser).subscribe({
      next: (data) => {
        console.log(data);
        alert("Usuario eliminado: " + data.name);
        this.getAllUsers();
      },
      error: (error) => {
        console.log(error);
        alert("Error al eliminar el usuario: " + error);
      }
    })
  }

  updateUser(user: User) {
   this.router.navigate(['form', user.idUser])
  }

}
