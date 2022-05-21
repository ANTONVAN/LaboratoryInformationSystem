import React, { useContext } from "react";

import { useFormik } from "formik";
import API from "../../utils/API"
import Table from "../../components/Table";
import ConfigNav4 from "../../components/ConfigNav4";
import ComponentContext from "../../utils/ComponentContext";
import SucursalesContext from "../../utils/SucursalesContext";


const Sucursales = () => {
  const component = useContext(ComponentContext);
  const sucursales = useContext(SucursalesContext);
  console.log(sucursales)
  const formik = useFormik({
    initialValues: {
      search: "",
      nombre: "",
      clave: "",

    },
    onSubmit: values => {
      API.getSucursales(values)
        .then(res => {
          sucursales.onClick(res.data);
          console.log(res.data)
        })
        .catch(err => console.log(err));
    }
  })

  return (
    <>
      <ConfigNav4 />
      <nav class="level">
        <div class="level-left">
          <p class="is-size-4 has-text-weight-bold" >Catalogo de Sucursales.</p>
        </div>
      </nav>
      <nav class="level">
        <div class="level-left">
          <div class="level-item">
            <div class="field has-addons">
              <p class="control">
                <input class="input is-radiusless" type="text" placeholder="Buscar un sucursal" onChange={formik.handleChange} value={formik.values.nombre} id="nombre" name="nombre" />
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
          <p class="level-item"><a class="button is-success" onClick={() => { component.onClick("NuevaSucursal") }}>NUEVO</a></p>
        </div>
      </nav>

      <Table data={sucursales.data} columns={sucursales.columns} component={component} edit="NuevaSucursal" />
    </>
  );
}
export default Sucursales;
