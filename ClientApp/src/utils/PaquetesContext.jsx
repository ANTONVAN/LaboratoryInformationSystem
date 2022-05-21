import React from "react";
const PaquetesContext = React.createContext({
  data: [],
  columns: [
    { title: "ID", field: "id" },
    { title: "Clave", field: "clave" },
    { title: "Nombre", field: "nombre" },
    { title: "Activo", field: "activo" },
  ],
  onClick: () => undefined
});
export default PaquetesContext;
