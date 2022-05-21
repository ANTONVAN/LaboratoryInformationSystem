import React from "react";
const DepartmentsContext = React.createContext({
  data: [],
  columns: [
      {title: "ID", field: "id"},
      {title: "Clave", field: "clave"},
      {title: "Nombre", field: "nombre"},
      ],
  onClick: () => undefined
});
export default DepartmentsContext;