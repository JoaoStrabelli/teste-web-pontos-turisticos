import { createBrowserRouter } from "react-router-dom";
import Layout from "../components/Layout";
import ListagemPage from "../pages/ListagemPage";
import CadastroPage from "../pages/CadastroPage";
import DetalhePage from "../pages/DetalhePage";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <Layout />,
    children: [
      {
        index: true,
        element: <ListagemPage />,
      },
      {
        path: "cadastrar",
        element: <CadastroPage />,
      },
      {
        path: "pontos/:id",
        element: <DetalhePage />,
      },
    ],
  },
]);