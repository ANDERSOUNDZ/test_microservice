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

  // URL base configurada para pasar a través del API Gateway
  private baseUrl = `${environment.apiUrl}/items-service`;
  private userUrl = `${environment.apiUrl}/users-service`;

  /** Signals para un estado reactivo y eficiente */
  items = signal<any[]>([]);
  usuariosDisponibles = signal<any[]>([]);

  /**
   * Carga los usuarios desde el microservicio de usuarios para el selector de asignación.
   */
  cargarUsuarios() {
    this.http.get<ApiResponse<any[]>>(`${this.userUrl}/listar`).subscribe((res) => {
      if (res.success) this.usuariosDisponibles.set(res.data);
    });
  }

  /**
   * Lista todos los ítems del sistema.
   */
  listarTodos() {
    this.http.get<ApiResponse<any[]>>(`${this.baseUrl}/listar-todo`).subscribe((res) => {
      if (res.success) this.items.set(res.data);
    });
  }

  /**
   * Envía la solicitud de asignación y maneja la respuesta mediante el mensaje personalizado.
   * @param request Datos del nuevo ítem.
   */
  asignarItem(request: CrearItemRequest) {
    return this.http.post<ApiResponse<string>>(`${this.baseUrl}/asignar`, request).pipe(
      tap({
        next: (res) => {
          if (res.success) {
            const mensajeCompleto = `${res.message}: ${res.data}`;
            this.notify.show(mensajeCompleto, true);
            this.listarTodos();
          }
        },
        error: (err) => {
          const apiRes = err.error as ApiResponse<any>;

          const msgError = apiRes?.message || 'No se pudo asignar la tarea';

          this.notify.show(msgError, false);
        },
      }),
    );
  }

  /**
   * Recupera los ítems pendientes asignados a un usuario específico.
   * Actualiza el signal 'items' con la respuesta.
   * @param username Nombre único del usuario a consultar.
   */
  listarPendientes(username: string) {
    this.http.get<ApiResponse<any[]>>(`${this.baseUrl}/pendientes/${username}`).subscribe((res) => {
      if (res.success) this.items.set(res.data);
    });
  }

  /**
   * Envía la señal de finalización de una tarea al backend.
   * Notifica el resultado y refresca la lista global en caso de éxito.
   * @param request DTO con el ID del ítem a completar.
   */
  completarItem(request: CompletarItemRequest) {
    return this.http.patch<ApiResponse<any>>(`${this.baseUrl}/completar`, request).pipe(
      tap((res) => {
        this.notify.show(res.message, res.success);
        if (res.success) this.listarTodos();
      }),
    );
  }
}
