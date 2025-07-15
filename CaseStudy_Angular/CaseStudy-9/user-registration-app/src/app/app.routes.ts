import { Routes } from '@angular/router';
import { TemplateDrivenRegistration } from './template-driven/template-driven-registration/template-driven-registration';
import { ReactiveRegistration } from './reactive/reactive-registration/reactive-registration';

export const routes: Routes = [
  { path: '', redirectTo: 'template-driven', pathMatch: 'full' },
  { path: 'template-driven', component: TemplateDrivenRegistration },
  { path: 'reactive', component: ReactiveRegistration }
];
