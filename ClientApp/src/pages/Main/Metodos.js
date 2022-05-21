import React, { useState, useContext } from "react";
import { makeStyles, withStyles } from "@material-ui/core/styles";
import { useFormik } from "formik";
import API from "../../utils/API"
import ComponentContext from "../../utils/ComponentContext";
import MetodosContext from "../../utils/MetodosContext";
import ConfigNav from "../../components/ConfigNav";
import Table from "../../components/Table";


const Metodos = (props) => {
    const component = useContext(ComponentContext);
    const metodos = useContext(MetodosContext);

    const formik = useFormik({
        initialValues: {
            search: "",
            clave: "",
            nombre: "",
        },
        onSubmit: values => {
            console.log(values);
            API.getMetodos(values)
                .then(res => {
                    console.log(res.data);
                    metodos.onClick(res.data)
            })
            .catch(err => console.log(err));
        }
    })

    return (
        <>
            <ConfigNav />
            <nav class="level">
              <div class="level-left">
                <p class="is-size-4 has-text-weight-bold" >Catalogo de Metodos.</p>
              </div>
            </nav>
            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <div class="field has-addons">
                    <p class="control">
                      <input class="input" type="text" placeholder="Buscar un maquilador" onChange={formik.handleChange} value={formik.values.nombre} id="nombre" name="nombre" />
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
                <p class="level-item"><a class="button is-success" onClick={() => { component.onClick("NuevoMetodo") }}>NUEVO</a></p>
              </div>
            </nav>
            <Table data={metodos.data} columns={metodos.columns} component={component} edit="NuevoMetodo" />
        </>
    );
}
export default Metodos;