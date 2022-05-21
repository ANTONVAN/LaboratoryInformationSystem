import React from "react";
const AreasContext = React.createContext({
  data: [],
  columns: [
        {title: "ID", field: "_id"},
        {title: "Clave", field: "clave"},
        {title: "Nombre", field: "nombre"},
        {title: "Departamento", field: "departamento.nombre"},
        ],
  onClick: () => undefined
});
export default AreasContext;