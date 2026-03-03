import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { ItemService } from '../../../core/services/item.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CrearItemRequest } from '../../../core/models/item.model';

/**
 * Componente para la gestión visual de tareas (Items).
 * Implementa filtrado, ordenamiento por estado y paginación reactiva.
 */
@Component({
  selector: 'app-items.component',
  imports: [CommonModule, FormsModule],
  templateUrl: './items.component.html',
  styleUrl: './items.component.css',
})
export class ItemsComponent implements OnInit {
  itemService = inject(ItemService);

  /** Signals para control de UI */
  filtroBusqueda = signal('');
  paginaActual = signal(1);
  itemsPorPagina = 5;

  /** Modelo para el formulario de creación */
  nuevoItem: CrearItemRequest = {
    titulo: '',
    fechaEntrega: '',
    esAltaRelevancia: false,
  };

  /**
   * Inicializa los datos cargando usuarios y la lista global de ítems.
   */
  ngOnInit() {
    this.itemService.cargarUsuarios();
    this.itemService.listarTodos();
  }

  /**
   * Signal computado que filtra, ordena y pagina la lista de ítems.
   * Prioriza los ítems 'Pendientes' sobre los 'Completados'.
   */
  itemsFiltrados = computed(() => {
    const texto = this.filtroBusqueda().toLowerCase();
    const todos = this.itemService.items();

    const filtrados = todos.filter(
      (item) =>
        item.titulo.toLowerCase().includes(texto) ||
        item.usuarioAsignado.toLowerCase().includes(texto),
    );

    const ordenados = filtrados.sort((a, b) => {
      if (a.estado === 'Pendiente' && b.estado === 'Completado') return -1;
      if (a.estado === 'Completado' && b.estado === 'Pendiente') return 1;
      return 0;
    });

    const inicio = (this.paginaActual() - 1) * this.itemsPorPagina;
    return ordenados.slice(inicio, inicio + this.itemsPorPagina);
  });

  /**
   * Signal computado que calcula el número total de páginas basándose en el filtro actual.
   * Esto garantiza que la paginación sea dinámica y se ajuste a los resultados de búsqueda.
   * @returns {number} Cantidad total de páginas.
   */
  totalPaginas = computed(() => {
    const texto = this.filtroBusqueda().toLowerCase();
    const filtrados = this.itemService
      .items()
      .filter(
        (item) =>
          item.titulo.toLowerCase().includes(texto) ||
          item.usuarioAsignado.toLowerCase().includes(texto),
      );
    return Math.ceil(filtrados.length / this.itemsPorPagina);
  });

  /**
   * Actualiza el estado de la página actual para la navegación de la tabla.
   * @param {number} nuevaPagina - El número de página al que se desea navegar.
   */
  cambiarPagina(nuevaPagina: number) {
    if (nuevaPagina >= 1 && nuevaPagina <= this.totalPaginas()) {
      this.paginaActual.set(nuevaPagina);
    }
  }

  /**
   * Ejecuta la asignación de un nuevo ítem a través del servicio.
   * Limpia el formulario y resetea la página al finalizar con éxito.
   */
  guardar() {
    if (!this.nuevoItem.titulo || !this.nuevoItem.fechaEntrega) {
      alert('Por favor complete el título y la fecha');
      return;
    }

    this.itemService.asignarItem(this.nuevoItem).subscribe({
      next: () => {
        this.nuevoItem = {
          titulo: '',
          fechaEntrega: '',
          esAltaRelevancia: false,
        };
        this.paginaActual.set(1);
      },
    });
  }

  /**
   * Solicita la finalización de un ítem de trabajo específico.
   * Tras la confirmación del usuario, invoca al servicio y reinicia la paginación.
   * @param {string} id - Identificador único del ítem a completar.
   */
  completar(id: string) {
    if (confirm('¿Marcar esta tarea como completada?')) {
      this.itemService.completarItem({ itemId: id }).subscribe(() => {
        this.paginaActual.set(1);
      });
    }
  }
}
