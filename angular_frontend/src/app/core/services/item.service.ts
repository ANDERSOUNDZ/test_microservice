import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { NotificationService } from './notification.service';
import { environment } from '../../../environments/environment';
import { tap } from 'rxjs';
import { ApiResponse } from '../models/api-response.model';
import { CompletarItemRequest, CrearItemRequest } from '../models/item.model';

@Injectable({
  providedIn: 'root',
})
export class ItemService {
  private http = inject(HttpClient);
  private notify = inject(NotificationService);
  private baseUrl = `${environment.apiUrl}/items-service`;
  private userUrl = `${environment.apiUrl}/users-service`;

  items = signal<any[]>([]);
  usuariosDisponibles = signal<any[]>([]);

  cargarUsuarios() {
    this.http.get<ApiResponse<any[]>>(`${this.userUrl}/listar`).subscribe((res) => {
      if (res.success) this.usuariosDisponibles.set(res.data);
    });
  }

  listarTodos() {
    this.http.get<ApiResponse<any[]>>(`${this.baseUrl}/listar-todo`).subscribe((res) => {
      if (res.success) this.items.set(res.data);
    });
  }

  asignarItem(request: CrearItemRequest) {
    return this.http.post<ApiResponse<string>>(`${this.baseUrl}/asignar`, request).pipe(
      tap((res) => {
        if (res.success) {
          const mensajeCompleto = `${res.message}: ${res.data}`;
          this.notify.show(mensajeCompleto, true);
          this.listarTodos();
        } else {
          this.notify.show(res.message, false);
        }
      }),
    );
  }

  listarPendientes(username: string) {
    this.http.get<ApiResponse<any[]>>(`${this.baseUrl}/pendientes/${username}`).subscribe((res) => {
      if (res.success) this.items.set(res.data);
    });
  }

  completarItem(request: CompletarItemRequest) {
    return this.http.patch<ApiResponse<any>>(`${this.baseUrl}/completar`, request).pipe(
      tap((res) => {
        this.notify.show(res.message, res.success);
        if (res.success) this.listarTodos();
      }),
    );
  }
}
