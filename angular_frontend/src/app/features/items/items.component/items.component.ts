import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { ItemService } from '../../../core/services/item.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CrearItemRequest } from '../../../core/models/item.model';

@Component({
  selector: 'app-items.component',
  imports: [CommonModule, FormsModule],
  templateUrl: './items.component.html',
  styleUrl: './items.component.css',
})
export class ItemsComponent implements OnInit {
  itemService = inject(ItemService);

  filtroBusqueda = signal('');
  paginaActual = signal(1);
  itemsPorPagina = 5;

  nuevoItem: CrearItemRequest = {
    titulo: '',
    fechaEntrega: '',
    esAltaRelevancia: false,
  };

  ngOnInit() {
    this.itemService.cargarUsuarios();
    this.itemService.listarTodos();
  }

  itemsFiltrados = computed(() => {
    const texto = this.filtroBusqueda().toLowerCase();
    const todos = this.itemService.items();

    const filtrados = todos.filter(
      (item) =>
        item.titulo.toLowerCase().includes(texto) ||
        item.usuarioAsignado.toLowerCase().includes(texto),
    );

    const inicio = (this.paginaActual() - 1) * this.itemsPorPagina;
    return filtrados.slice(inicio, inicio + this.itemsPorPagina);
  });

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

  cambiarPagina(nuevaPagina: number) {
    if (nuevaPagina >= 1 && nuevaPagina <= this.totalPaginas()) {
      this.paginaActual.set(nuevaPagina);
    }
  }

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
  completar(id: string) {
    if (confirm('¿Marcar esta tarea como completada?')) {
      this.itemService.completarItem({ itemId: id }).subscribe(() => {
        this.paginaActual.set(1);
      });
    }
  }
}
