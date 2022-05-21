import React, { useState, useContext } from "react";

import { useFormik } from "formik";
import API from "../../utils/API"
import ComponentContext from "../../utils/ComponentContext";
import IndicacionesContext from "../../utils/IndicacionesContext";
import ConfigNav from "../../components/ConfigNav";
import Table from "../../components/Table";


const Indicaciones = (props) => {
    const { classes } = props;
    const component = useContext(ComponentContext);
    const indicaciones = useContext(IndicacionesContext);

    const formik = useFormik({
        initialValues: {
            search: "",
            clave: "",
            nombre: "",
        },
        onSubmit: values => {
          console.log(values);
          API.getIndicaciones(values)
              .then(res => {
                  console.log(res.data);
                  indicaciones.onClick(res.data)
              })
              .catch(err => console.log(err));
        }
    })

    return (
        <>
        <ConfigNav />
            <nav class="level">
              <div class="level-left">
                <p class="is-size-4 has-text-weight-bold" >Catalogo de Indicaciones.</p>
              </div>
            </nav>
            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <div class="field has-addons">
                    <p class="control">
                      <input class="input" type="text" placeholder="Buscar una indiacion" onChange={formik.handleChange} value={formik.values.nombre} id="nombre" name="nombre" />
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
                <p class="level-item"><a class="button is-success" onClick={() => { component.onClick("NuevaIndicacion") }}>NUEVO</a></p>
              </div>
            </nav>

            <Table data={indicaciones.data} columns={indicaciones.columns} component={component} edit="NuevaIndicacion" />
        </>
    );
}
export default Indicaciones;