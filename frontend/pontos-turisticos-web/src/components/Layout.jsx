import { Link, Outlet } from "react-router-dom";

function Layout() {
  return (
    <>
      <header className="app-header">
        <div className="app-header__content">
          <Link to="/" className="app-logo">
            Pontos Turísticos
          </Link>

          <nav className="app-nav">
            <Link to="/">Listagem</Link>
            <Link to="/cadastrar">Cadastrar</Link>
          </nav>
        </div>
      </header>

      <main className="app-container">
        <Outlet />
      </main>
    </>
  );
}

export default Layout;