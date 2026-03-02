import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'tareas',
    loadComponent: () =>
      import('./features/items/items.component/items.component').then((m) => m.ItemsComponent),
  },

  {
    path: 'users',
    loadComponent: () =>
      import('./features/users/users.component/users.component').then((m) => m.UsersComponent),
  },
  { path: '', redirectTo: 'tareas', pathMatch: 'full' },
];
