import { Component, inject, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { User, UserDto } from '../../models/user.model';
import { UserService } from '../../services/user.service';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-list-component',
  standalone: true,
  imports: [RouterModule, CommonModule, FormsModule],
  templateUrl: './list-component.component.html',
  styleUrl: './list-component.component.css'
})
export class ListComponentComponent implements OnInit {

  private readonly service = inject(UserService);
  private readonly modalService = inject(NgbModal);
  @ViewChild('editModal') editModal!: TemplateRef<any>

  users: User[] = [];
  editUser: UserDto = {
    name: '',
    email: '',
    password: ''
  }
  updateSucces: boolean = false;


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

  deleteUsers(idUser?: number) {
    if (!idUser) return;
    console.log("eliminando usuario con id: " + idUser);
    this.service.deleteUsers(idUser).subscribe({
      next: (data) => {
        console.log("Respuesta: " + data);
        alert("El usuario se elimino con exito");
        this.getAllUsers();
      },
      error: (err) => {
        console.log("error: " + err);
        alert("Error al eliminar el usuario");
      }
    });
  }

  updateUser(user: User) {
    this.editUser = {
      name: user.name,
      email: user.email,
      password: user.password
    }
    this.modalService.open(this.editModal);
  }

  savedChanges() {
    this.service.updateUser(this.editUser).subscribe({
      next: (data) => {
        this.updateSucces = true;
        this.getAllUsers();
        this.modalService.dismissAll();
      },
      error: () => {
        alert("Error al actualizar el usuario.")
      }
    })
  }

}
