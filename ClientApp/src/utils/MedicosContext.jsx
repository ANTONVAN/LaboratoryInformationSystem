import React from "react";
const MedicosContext = React.createContext({
  data: [],
  columns: [
    { title: "ID", field: "id" },
    { title: "Clave", field: "clave" },
    { title: "Nombre", field: "nombre" },
    { title: "Apellidos", field: "apellidos" },
    { title: "Especialidad", field: "especialidad" },
    { title: "CP", field: "cp" },
    { title: "Ciudad", field: "ciudad" },
    { title: "Estado", field: "estado" },
    { title: "Correo", field: "correo" },
    { title: "Telefono", field: "telefono" },
    { title: "Celular", field: "celular" },
    { title: "Ciudad", field: "ciudad" },
    { title: "Activo", field: "activo" },

    
  ],
  onClick: () => undefined
});
export default MedicosContext;
