/**
 * Estructura genérica para todas las respuestas del Backend.
 * @template T Tipo de dato contenido en la propiedad data.
 */
export interface ApiResponse<T> {
  success: boolean;
  message: string;
  data: T;
  code: number;
}
