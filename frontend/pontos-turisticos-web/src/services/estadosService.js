import { api } from "./api";

export async function listarEstados() {
  const response = await api.get("/estados");

  return response.data;
}