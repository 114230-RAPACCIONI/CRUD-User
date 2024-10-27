import { Routes } from '@angular/router';
import { ListComponentComponent } from './components/list-component/list-component.component';
import { CreateFormComponentsComponent } from './components/create-form-components/create-form-components.component';

export const routes: Routes = [
    {path: 'list', component: ListComponentComponent},
    {path: 'form', component: CreateFormComponentsComponent},
    {path: 'form/:id', component: CreateFormComponentsComponent}
];
