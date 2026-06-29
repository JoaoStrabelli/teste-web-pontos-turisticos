import { useParams } from "react-router-dom";

function DetalhePage() {
  const { id } = useParams();

  return (
    <section>
      <h2>Detalhe do ponto turístico</h2>
      <p>ID selecionado: {id}</p>
    </section>
  );
}

export default DetalhePage;