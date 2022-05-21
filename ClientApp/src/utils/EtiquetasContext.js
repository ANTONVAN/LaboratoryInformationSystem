import React from "react";
const EtiquetasContext = React.createContext({
    data: [],
    columns: [
        { title: "ID", field: "id" },
        { title: "Clave", field: "clave" },
        { title: "Nombre", field: "nombre" },
    ],
    onClick: () => undefined
});
export default EtiquetasContext;