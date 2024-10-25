import { Component, inject } from '@angular/core';
import { User } from '../../models/user';
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
export class CreateFormComponentsComponent {

  user: User = new User();
  isEdit: boolean = false;
  private subscription = new Subscription();
  private readonly service = inject(UserService);
  private readonly router = inject(Router)



  sendForm(form: NgForm) {
    if(form.valid) {
      if(this.isEdit) {
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
