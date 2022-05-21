import React from "react";
const EstudiosContext = React.createContext({
    data: [],
    columns: [
        { title: "ID", field: "id" },
        { title: "Clave", field: "clave" },
        { title: "Nombre", field: "nombre" },
        { title: "Area", field: "area.nombre" },
        { title: "Metodo", field: "metodo.nombre" },
        { title: "Maquilador", field: "maquilador.nombre" }
    ],
    onClick: () => undefined
});
export default EstudiosContext;