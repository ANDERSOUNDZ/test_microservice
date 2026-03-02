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

  registrar(request: { username: string; nombreCompleto: string }) {
    return this.http.post<ApiResponse<any>>(`${this.baseUrl}/registrar`, request)
      .pipe(
        tap(res => {
          this.notify.show(res.message, res.success);
          if (res.success) this.listar();
        })
      );
  }

  listar() {
    this.http.get<ApiResponse<UsuarioResponse[]>>(`${this.baseUrl}/listar`)
      .subscribe(res => {
        if (res.success) this.usuarios.set(res.data);
      });
  }
}
