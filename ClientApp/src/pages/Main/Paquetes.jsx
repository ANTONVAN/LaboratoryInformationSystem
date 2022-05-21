import React, { useContext } from "react";

import { useFormik } from "formik";
import API from "../../utils/API"
import Table from "../../components/Table";
import ConfigNav from "../../components/ConfigNav";
import ComponentContext from "../../utils/ComponentContext";
import PaquetesContext from "../../utils/PaquetesContext";


const Paquetes = () => {
  const component = useContext(ComponentContext);
  const paquetes = useContext(PaquetesContext);
  console.log(paquetes)
  const formik = useFormik({
    initialValues: {
      area: "All",
      search: "",
      clave: "",
      nombre: "",
    },
    onSubmit: values => {
      API.getPaquetes(values)
        .then(res => {
          paquetes.onClick(res.data);
          console.log(res.data)
        })
        .catch(err => console.log(err));
    }
  })

  return (
    <>
      <ConfigNav />
      <nav class="level">
        <div class="level-left">
          <p class="is-size-4 has-text-weight-bold" >Catalogo de Paquetes.</p>
        </div>
      </nav>
      <nav class="level">
        <div class="level-left">
          <div class="level-item">
            <div class="field has-addons">
              <p class="control">
                <input class="input is-radiusless" type="text" placeholder="Buscar un paquete" onChange={formik.handleChange} value={formik.values.nombre} id="nombre" name="nombre" />
              </p>
              <p class="control">
                <button class="button is-radiusless" onClick={formik.handleSubmit}>
                  BUSCAR
                </button>
              </p>
            </div>
          </div>
        </div>

        <div class="level-right">
          <p class="level-item"><a class="button is-success" onClick={() => { component.onClick("NuevoPaquete") }}>NUEVO</a></p>
        </div>
      </nav>

      <Table data={paquetes.data} columns={paquetes.columns} component={component} edit="NuevoPaquete" />
    </>
  );
}
export default Paquetes;
