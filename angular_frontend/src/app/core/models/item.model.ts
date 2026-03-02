export interface CrearItemRequest {
  titulo: string;
  fechaEntrega: string;
  esAltaRelevancia: boolean;
}

export interface ItemPendienteResponse {
  id: string;
  titulo: string;
  fechaEntrega: Date;
  esAltaRelevancia: boolean;
  usuarioAsignado: string;
}

export interface CompletarItemRequest {
  itemId: string;
}
