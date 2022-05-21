import React, { useState, useContext } from "react";
import { useFormik } from "formik";
import API from "../../utils/API"
import ComponentContext from "../../utils/ComponentContext";
import MaquiladoresContext from "../../utils/MaquiladoresContext";
import ConfigNav from "../../components/ConfigNav";
import Table from "../../components/Table";


const Maquiladores = (props) => {

    const component = useContext(ComponentContext);
    const maquiladores = useContext(MaquiladoresContext);

    const formik = useFormik({
        initialValues: {
            search: "",
            clave: "",
            nombre: "",
        },
        onSubmit: values => {
            console.log(values);
            API.getMaquiladores(values)
            .then(res => {
                console.log(res.data);
                maquiladores.onClick(res.data)
            })
            .catch(err => console.log(err));
        }
    })

    return (
        <>
            <ConfigNav />
            <nav class="level">
              <div class="level-left">
                <p class="is-size-4 has-text-weight-bold" >Catalogo de Maquiladores.</p>
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
                <p class="level-item"><a class="button is-success" onClick={() => { component.onClick("NuevoMaquilador") }}>NUEVO</a></p>
              </div>
            </nav>

            <Table data={maquiladores.data} columns={maquiladores.columns} component={component} edit="NuevoMaquilador" />
        </>
    );
}
export default Maquiladores;