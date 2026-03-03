import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../../core/services/user.service';
import { UsuarioResponse } from '../../../core/models/user.model';

/**
 * Componente para la gestión de usuarios del sistema.
 * Permite el registro, edición y eliminación de usuarios con validaciones de integridad.
 */
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

  /**
   * Al iniciar, recupera la lista actualizada de usuarios.
   */
  ngOnInit() {
    this.userService.listar();
  }

  /**
   * Registra un nuevo usuario en la base de datos.
   */
  guardar() {
    this.userService.registrar(this.form).subscribe({
      next: () => {
        this.form = { username: '', nombreCompleto: '' };
      },
    });
  }

  /**
   * Solicita la eliminación de un usuario.
   * El Backend validará si el usuario posee tareas asignadas antes de proceder.
   * @param username Identificador del usuario a eliminar.
   */
  eliminar(username: string) {
    if (
      confirm(
        `¿Está seguro de eliminar al usuario ${username}? El sistema verificará que no tenga tareas pendientes.`,
      )
    ) {
      this.userService.eliminar(username).subscribe();
    }
  }

  /**
   * Permite la edición rápida del nombre completo de un usuario.
   * @param user Objeto con la información actual del usuario.
   */
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
