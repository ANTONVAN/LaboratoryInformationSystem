import React, { useState, useContext } from "react";
import { useFormik } from "formik";
import PropTypes from 'prop-types';
import API from "../../utils/API"
import ComponentContext from "../../utils/ComponentContext";
import EtiquetasContext from "../../utils/EtiquetasContext";
import ConfigNav from "../../components/ConfigNav";
import Table from "../../components/Table";


const Etiquetas = (props) => {

    const component = useContext(ComponentContext);
    const etiquetas = useContext(EtiquetasContext);

    const formik = useFormik({
        initialValues: {
            search: "",
            clave: "",
            nombre: "",
        },
        onSubmit: values => {
            console.log(values);
            API.getEtiquetas(values)
                .then(res => {
                    console.log(res.data);
                    etiquetas.onClick(res.data)

                })
                .catch(err => console.log(err));
        }
    })

    return (
        <>
            <ConfigNav />
            <nav class="level">
              <div class="level-left">
                <h6 class="is-size-4 has-text-weight-bold" >Catalogo de Etiquetas.</h6>
              </div>
            </nav>
            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <div class="field has-addons">
                    <p class="control">
                      <input class="input" type="text" placeholder="Buscar una etiquetas" onChange={formik.handleChange} value={formik.values.nombre} id="nombre" name="nombre" />
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
                <p class="level-item"><a class="button is-success" onClick={() => { component.onClick("NuevaEtiqueta") }}>NUEVO</a></p>
              </div>
            </nav>

            <Table data={etiquetas.data} columns={etiquetas.columns} component={component} edit="NuevaEtiqueta" />
        </>
    );
}
export default Etiquetas;