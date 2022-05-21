import React, { useContext } from "react";

import { useFormik } from "formik";
import API from "../../utils/API"
import Table from "../../components/Table";
import ConfigNav2 from "../../components/ConfigNav2";
import ComponentContext from "../../utils/ComponentContext";
import CatalogoPreciosContext from "../../utils/CatalogoPreciosContext";


const CatalogoPrecios = () => {
  const component = useContext(ComponentContext);
  const catalogoPrecios = useContext(CatalogoPreciosContext);
  console.log(catalogoPrecios)
  const formik = useFormik({
    initialValues: {
      area: "All",
      search: "",
      clave: "",
      nombre: "",
    },
    onSubmit: values => {
      API.getCatPrecios(values)
        .then(res => {
          console.log(res.data)
          catalogoPrecios.onClick(res.data);
          
        })
        .catch(err => console.log(err));
    }
  })

  return (
    <>
      <ConfigNav2 />
      <nav class="level">
        <div class="level-left">
          <p class="is-size-4 has-text-weight-bold" >Catalogo de Precios.</p>
        </div>
      </nav>
      <nav class="level">
        <div class="level-left">
          <div class="level-item">
            <div class="field has-addons">
              <p class="control">
                <input class="input is-radiusless" type="text" placeholder="Buscar un estudio" onChange={formik.handleChange} value={formik.values.nombre} id="nombre" name="nombre" />
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
          <p class="level-item"><a class="button is-success" onClick={() => { component.onClick("NuevoCatalogoPrecio") }}>NUEVO</a></p>
        </div>
      </nav>

      <Table data={catalogoPrecios.data} columns={catalogoPrecios.columns} component={component} edit="NuevoCatalogoPrecio" />
    </>
  );
}
export default CatalogoPrecios;
