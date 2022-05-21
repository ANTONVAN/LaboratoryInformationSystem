import React from "react";
const ReactivosContext = React.createContext({
  data: [],
  columns: [
    { title: "ID", field: "id" },
    { title: "Clave", field: "clave" },
    { title: "Nombre", field: "nombre" },
    { title: "Activo", field: "area.activo" }
  ],
  onClick: () => undefined
});
export default ReactivosContext;