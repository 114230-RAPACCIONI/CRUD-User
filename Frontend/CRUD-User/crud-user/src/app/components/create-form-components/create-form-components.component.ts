import { Component, inject, OnInit } from '@angular/core';
import { User } from '../../models/user.model';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Subscription } from 'rxjs';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';

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


  ngOnInit(): void {

  }

  sendForm(form: NgForm) {
    if (form.valid) {
      console.log(this.user);
      if (this.isEdit) {
        this.user.id = this.id;
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

      this.user = new User();
      console.log(this.user);
    }
  }


}
