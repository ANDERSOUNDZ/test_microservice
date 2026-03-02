import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../../core/services/user.service';
import { UsuarioResponse } from '../../../core/models/user.model';

@Component({
  selector: 'app-users.component',
  imports: [CommonModule, FormsModule],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css',
})
export class UsersComponent implements OnInit {
  userService = inject(UserService);

  form = {
    username: '',
    nombreCompleto: '',
  };

  ngOnInit() {
    this.userService.listar();
  }

  guardar() {
    this.userService.registrar(this.form).subscribe({
      next: () => {
        this.form = { username: '', nombreCompleto: '' };
      },
    });
  }

  eliminar(username: string) {
    if (
      confirm(
        `¿Está seguro de eliminar al usuario ${username}? El sistema verificará que no tenga tareas pendientes.`,
      )
    ) {
      this.userService.eliminar(username).subscribe();
    }
  }

  editar(user: UsuarioResponse) {
    const nuevoNombre = prompt(`Editar nombre para ${user.username}:`, user.nombreCompleto);
    if (nuevoNombre && nuevoNombre.trim() !== '' && nuevoNombre !== user.nombreCompleto) {
      this.userService
        .editar({
          username: user.username,
          nuevoNombre: nuevoNombre.trim(),
        })
        .subscribe();
    }
  }
}
