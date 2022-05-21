import React from "react";
const PacientesContext = React.createContext({
  data: [],
  columns: [
    { title: "ID", field: "id" },
    { title: "Nombre", field: "nombre" },
    { title: "Apellidos", field: "apellidos" },
    { title: "Sexo", field: "sexo" },
    { title: "Direccion", field: "direccion" },
    { title: "Edad", field: "edad" },
    { title: "FechaNacimiento", field: "fechaNacimiento" },
    { title: "Celular", field: "celular" },
    { title: "Telefono", field: "telefono" },
    { title: "CP", field: "cp" }
  ],
  onClick: () => undefined
});
export default PacientesContext;