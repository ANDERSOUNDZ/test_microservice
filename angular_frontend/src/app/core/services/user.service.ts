import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { NotificationService } from './notification.service';
import { environment } from '../../../environments/environment';
import { ApiResponse } from '../models/api-response.model';
import { tap } from 'rxjs';
import { UsuarioResponse } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private http = inject(HttpClient);
  private notify = inject(NotificationService);
  private baseUrl = `${environment.apiUrl}/users-service`;

  usuarios = signal<UsuarioResponse[]>([]);

  listar() {
    this.http.get<ApiResponse<UsuarioResponse[]>>(`${this.baseUrl}/listar`).subscribe((res) => {
      if (res.success) this.usuarios.set(res.data);
    });
  }

  registrar(request: { username: string; nombreCompleto: string }) {
    return this.http.post<ApiResponse<any>>(`${this.baseUrl}/registrar`, request).pipe(
      tap((res) => {
        this.notify.show(res.message, res.success);
        if (res.success) this.listar();
      }),
    );
  }

  editar(request: { username: string; nuevoNombre: string }) {
    return this.http.put<ApiResponse<any>>(`${this.baseUrl}/editar`, request).pipe(
      tap((res) => {
        this.notify.show(res.message, res.success);
        if (res.success) this.listar();
      }),
    );
  }

  eliminar(username: string) {
    return this.http.delete<ApiResponse<any>>(`${this.baseUrl}/eliminar/${username}`).pipe(
      tap({
        next: (res) => {
          this.notify.show(res.message, res.success);
          if (res.success) this.listar();
        },
        error: (err) => {
          const apiRes = err.error as ApiResponse<any>;
          const msgToShow = apiRes?.data || apiRes?.message || 'Error al eliminar usuario';
          this.notify.show(msgToShow, false);
        },
      }),
    );
  }
}
