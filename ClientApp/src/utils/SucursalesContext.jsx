import React from "react";
const SucursalesContext = React.createContext({
  data: [],
  columns: [
    { title: "ID", field: "id" },
    { title: "Clave", field: "clave" },
    { title: "Nombre", field: "nombre" },
    { title: "CP", field: "cp" },
    { title: "Estado", field: "estado" },
    { title: "Ciudad", field: "ciudad" },
    { title: "NumeroExterior", field: "numeroexterior" },
    { title: "Calle", field: "calle" },
    { title: "Colonia", field: "colonia" },
    { title: "Correo", field: "correo" },
    { title: "Min", field: "min" },
    { title: "Max", field: "max" },
    { title: "Activo", field: "activo" },
  ],
  onClick: () => undefined
});
export default SucursalesContext;
