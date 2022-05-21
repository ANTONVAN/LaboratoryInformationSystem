import React from "react";
const PacientesContext = React.createContext({
  data: [],
  columns: [
    { title: "ID", field: "id" },
    { title: "Compania", field: "compania" },
    { title: "Importe", field: "importe" },
    { title: "Descuento", field: "descuento" },
    { title: "Total", field: "total" },
    { title: "Saldo", field: "saldo" },
    
  ],
  onClick: () => undefined
});
export default PacientesContext;