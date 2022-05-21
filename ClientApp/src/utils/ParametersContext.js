import React from "react";
const ParametersContext = React.createContext({
  data: [],
  columns: [
      {title: "ID", field: "id"},
      {title: "Clave", field: "clave"},
      {title: "Nombre", field: "nombre"},
      {title: "Unidades", field: "unidades"},
      {title: "Tipo", field: "valorTipo.nombre"},
    ],
  onClick: () => undefined
});
export default ParametersContext;