import { Component, inject, OnInit } from '@angular/core';
import { User } from '../../models/user.model';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Subscription } from 'rxjs';
import { UserService } from '../../services/user.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-form-components',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './create-form-components.component.html',
  styleUrl: './create-form-components.component.css'
})
export class CreateFormComponentsComponent implements OnInit {

  user: User = new User();
  isEdit: boolean = false;
  id: number = 0;

  private subscription = new Subscription();
  private readonly service = inject(UserService);
  private readonly router = inject(Router)
  private readonly activatedRouter = inject(ActivatedRoute)


  ngOnInit(): void {
    this.activatedRouter.paramMap.subscribe((data) => {
      const idParam = data.get('id');
      console.log("id param: " + idParam)
      if (idParam) {
        this.id = +idParam;
        this.isEdit = true;
        this.getById(this.id);
      }
    })
  }

  getById(id: number) {
    this.subscription.add(
      this.service.getUserById(id).subscribe({
        next: (data) => {
          this.user = data
          if (!this.user.id) {
            alert("Error: el ID de usuario no esta definido");
          }
        },
        error: (err) => {
          alert("Error al cargar el usuario");
        }
      })
    );
  }

  sendForm(form: NgForm) {
    if (form.valid) {
      if (this.isEdit && this.user.id) {
        this.subscription.add(
          this.service.updateUser(this.user).subscribe({
            next: (data) => alert("Usuario actualizado"),
            error: (error) => alert("Error al actualizar el usuario"),
            complete: () => this.router.navigate(['list'])
          })
        );
      } else {
        this.subscription.add(
          this.service.createUser(this.user).subscribe({
            next: (data) => alert("Usuario creado"),
            error: (error) => alert("Error al crear el usuario"),
            complete: () => this.router.navigate(['list'])
          })
        );
      }

      form.reset();
      this.user = new User();
    }
  }


}
