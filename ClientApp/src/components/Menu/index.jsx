import React, { useContext } from 'react';
import NavbarContext from "../../utils/NavbarContext";
import ComponentContext from "../../utils/ComponentContext";

function Menu() {
  const navbarContext = useContext(NavbarContext);
  const componentContext = useContext(ComponentContext);
  let nav = [
    { id: 'Sesion', children: [{ id: 'Sesion' }] },
    { id: 'Documentacion', children: [{ id: 'Manuales' }] },
    { id: 'Configuracion', children: [{ id: 'Sistema' }, { id: 'Admision' }, { id: 'Estudios' }, { id: 'Companias' }] },

  ];
  switch (navbarContext.name) {
    case "Main":
      nav = [
        { id: 'Sesion', children: [{ id: 'Sesion' }] },
        { id: 'Documentacion', children: [{ id: 'Manuales' }] },
        { id: 'Configuracion', children: [{ id: 'Sistema' }, { id: 'Admision' }, { id: 'Estudios' }, { id: 'Companias' }] },
      ];
      
      break;
    case "Recepcion":
      nav = [{ id: 'Recepcion', children: [{ id: 'Pacientes' }, { id: 'Solicitudes' }, { id: 'Nueva solicitud' }] }];
      break;
      
    case "Resultados":
      nav = [{ id: 'Resultados', children: [{ id: 'Captura' }, { id: 'Impresion' }, { id: 'Listados' }] }];
      
      break;
  }
console.log(navbarContext.name)
  return (

    <aside class="menu has-background-light">
      {nav.map(({ id, children }) => (
        <>
          <p class="menu-label">{id}</p>
          <ul class="menu-list">
          {children.map(({ id: childId }) => (
            <li><a onClick={() => {componentContext.onClick(childId)}}><strong>{childId}</strong></a></li>
          ))}
          </ul>
        </>
      ))}
    </aside>
  )
}
export default Menu;