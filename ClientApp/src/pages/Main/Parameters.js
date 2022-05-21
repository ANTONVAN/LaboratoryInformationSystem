import React, {useState, useContext} from "react";

import {useFormik} from "formik";
import API from "../../utils/API"
import Table from "../../components/Table";
import ConfigNav from "../../components/ConfigNav";
import ComponentContext from "../../utils/ComponentContext";
import ParametersContext from "../../utils/ParametersContext";


const Parameters = () => {

  const component = useContext(ComponentContext);
  const parameters = useContext(ParametersContext);
  const formik = useFormik({
    initialValues: {
      area: "All",
      search: "",
      clave: "",
      nombre: "",    
    },
    onSubmit: values => {
      API.getParameters(values) 
        .then(res => {
          console.log(res.data)
          parameters.onClick(res.data);
        })
       .catch(err => console.log(err));
    }
  })

  return (
      <>
      <ConfigNav />
      <nav class="level">
        <div class="level-left">
          <p class="is-size-4 has-text-weight-bold" >Catalogo de Parametros.</p>
        </div>
      </nav>
      <nav class="level">
        <div class="level-left">
          <div class="level-item">
            <div class="field has-addons">
              <p class="control">
                <input class="input" type="text" placeholder="Buscar un parametro" onChange={formik.handleChange} value={formik.values.nombre} id="nombre" name="nombre" />
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
          <p class="level-item"><a class="button is-success" onClick={() => { component.onClick("NewParameter") }}>NUEVO</a></p>
        </div>
      </nav>

      <Table data={parameters.data} columns={parameters.columns} component={component} edit="NewParameter"/>
    </>
  );
}

export default Parameters;
