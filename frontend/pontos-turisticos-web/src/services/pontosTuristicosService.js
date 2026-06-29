import { api } from "./api";

export async function listarPontosTuristicos({
  searchTerm = "",
  page = 1,
  pageSize = 5,
}) {
  const response = await api.get("/pontos-turisticos", {
    params: {
      searchTerm,
      page,
      pageSize,
    },
  });

  return response.data;
}

export async function buscarPontoTuristicoPorId(id) {
  const response = await api.get(`/pontos-turisticos/${id}`);

  return response.data;
}

export async function criarPontoTuristico(data) {
  const response = await api.post("/pontos-turisticos", data);

  return response.data;
}