import React from "react";
const CompaniasContext = React.createContext({
  data: [],
  columns: [
    { title: "ID", field: "id" },
    { title: "Clave", field: "clave" },
    { title: "Nombre", field: "nombre" },
    { title: "RFC", field: "rfc" },
    { title: "CP", field: "cp" },
    { title: "Telefono", field: "telefono" },
    { title: "Catalogo Precio", field: "razonSocial" },
    { title: "Email", field: "email" },
    { title: "Status", field: "status" },
    { title: "Catalogo Precio", field: "catPrecioId" },

  ],
  onClick: () => undefined
});
export default CompaniasContext;