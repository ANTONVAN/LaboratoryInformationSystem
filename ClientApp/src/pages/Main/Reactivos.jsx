import React, { useContext } from "react";

import { useFormik } from "formik";
import API from "../../utils/API"
import Table from "../../components/Table";
import ConfigNav from "../../components/ConfigNav";
import ComponentContext from "../../utils/ComponentContext";
import ReactivosContext from "../../utils/ReactivosContext";


const Reactivos = () => {
  const component = useContext(ComponentContext);
  const reactivos = useContext(ReactivosContext);
  console.log(reactivos)
  const formik = useFormik({
    initialValues: {
      search: "",
      nombre: "",
      clave: "",

    },
    onSubmit: values => {
      API.getReactivos(values)
        .then(res => {
          reactivos.onClick(res.data);
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
          <p class="is-size-4 has-text-weight-bold" >Catalogo de Reactivos.</p>
        </div>
      </nav>
      <nav class="level">
        <div class="level-left">
          <div class="level-item">
            <div class="field has-addons">
              <p class="control">
                <input class="input is-radiusless" type="text" placeholder="Buscar un reactivo" onChange={formik.handleChange} value={formik.values.nombre} id="nombre" name="nombre" />
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
          <p class="level-item"><a class="button is-success" onClick={() => { component.onClick("NuevoReactivo") }}>NUEVO</a></p>
        </div>
      </nav>

      <Table data={reactivos.data} columns={reactivos.columns} component={component} edit="NuevoReactivo" />
    </>
  );
}
export default Reactivos;
