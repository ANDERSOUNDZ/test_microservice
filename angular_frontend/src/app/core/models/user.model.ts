/**
 * Respuesta básica de información de usuario.
 */
export interface UsuarioResponse {
  username: string;
  nombreCompleto: string;
}

/**
 * DTO para la creación de un nuevo usuario.
 */
export interface CrearUsuarioRequest {
  username: string;
  nombreCompleto: string;
}
