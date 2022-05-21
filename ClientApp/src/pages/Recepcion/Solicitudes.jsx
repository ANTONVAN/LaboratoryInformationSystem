import React, { useContext } from "react";

import { useFormik } from "formik";
import API from "../../utils/API"
import ComponentContext from "../../utils/ComponentContext";
import SolicitudesContext from "../../utils/SolicitudesContext";
import ConfigNav from "../../components/ConfigNav";
import Table from "../../components/Table";

const Solicitudes = (props) => {

  const component = useContext(ComponentContext);
  const solicitudes = useContext(SolicitudesContext);

  const formik = useFormik({
    initialValues: {
      search: "",
      clave: "",
      nombre: "",
    },
    onSubmit: values => {
      console.log(values);
      API.getSolicitud(values)
        .then(res => {
          console.log(res.data);
          solicitudes.onClick(res.data)
        })
        .catch(err => console.log(err));
    }
  })

  return (
    <>

      <nav class="level">
        <div class="level-left">
          <div class="level-item">
            <div class="field has-addons">
              <p class="control">
                <input class="input" type="text" placeholder="Buscar una solicitud" onChange={formik.handleChange} value={formik.values.nombre} id="nombre" name="nombre" />
              </p>
              <p class="control">
                <button class="button" onClick={formik.handleSubmit}>
                  BUSCAR
                </button>
              </p>
            </div>
          </div>
        </div>

        <div class="level-right">
          <p class="level-item"><a class="button is-success" onClick={() => { component.onClick("NuevaSolicitud") }}>NUEVO</a></p>
        </div>
      </nav>

      <Table class="level" data={solicitudes.data} columns={solicitudes.columns} component={component} edit="NuevaSolicitud" />
    </>
  );
}


export default Solicitudes;