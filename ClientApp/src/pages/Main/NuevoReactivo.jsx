import React, { useState, useEffect, useContext } from "react";
import { useFormik, FieldArray, Form, Field, Formik } from "formik";
import API from "../../utils/API"

import ComponentContext from "../../utils/ComponentContext";
import ConfigNav from "../../components/ConfigNav";

const NuevoReactivo = () => {
  const [editable, setEditable] = useState(false)

  //Desestructurando el objeto del estudio a editar de la tabla de estudios
  const component = useContext(ComponentContext);
  if (component.data) {
    console.log(component.data)


    var id = component.data.id;
    var nombre = component.data.nombre;
    var clave = component.data.clave;
    var activo = component.data.activo;

  }
  //Cargando datos de areas, metodos y maquiladores para mostrar en los select input
  //  const [catPrecios, setCatPrecios] = useState([""]);
  useEffect(() => {
    const fetchData = async () => {

    };
    fetchData();
  }, []);

  //Objeto de valores iniciales a utilizar en formularios de Formik 
  const initialValues = {
    reactivo: {

      search: "",
      id: id,
      nombre: nombre,
      clave: clave,
      activo: activo,

    }
  }
  //Guardar o actualizar estudio en BD - Relacionar estudio con parametro
  function _onSubmit(values) {

    if (values.reactivo.id) {
      console.log(values)
      API.updateReactivo(values.reactivo).then(res => { }).catch(err => console.log(err));
    } else {
      API.addReactivo(values.reactivo).then(res => {
        console.log(res);
        setEditable(false);
        values.reactivo.id = res.data.id
        var data = values.reactivo;
        component.onClick("NuevoReactivo", { data });
      }).catch(err => console.log(err));
    }
  }

  return (
    <>
      <ConfigNav />
      <Formik
        initialValues={initialValues}
        onSubmit={values => { _onSubmit(values) }}
        render={({ values, setFieldValue }) => (

          <Form>

            <nav class="level">
              <div class="level-left">
                <p class="is-size-4 has-text-weight-bold" >Catalogo de Reactivos.</p>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <p>REGISTRO NUEVO</p>
              </div>

              <div class="level-right">
                <p class="level-item"><button class="button is-primary" onClick={() => { setEditable(false) }} type="submit"> Guardar </button></p>
                <p class="level-item">{component.data ? <button class="button is-primary" onClick={() => { setEditable(true) }}>MODIFY</button> : null}</p>
                <p class="level-item"><a class="button is-success" type="submit" onClick={() => { component.onClick("Reactivos") }}>CERRAR</a></p>
              </div>
            </nav>

            <div class="columns">

              <div class="column is-one-quarter">
                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Nombre</span>
                        <Field disabled={component.data && !editable} class="input" type="text" name="reactivo.nombre" placeholder="Nombre" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Clave</span>
                        <Field class="input" disabled={component.data && !editable} type="text" name="reactivo.clave" placeholder="Clave" />
                      </p>
                    </div>
                  </div>
                </nav>


              </div>

              <div class="column is-one-quarter">




              </div>

            </div>


          </Form>
        )} />
    </>
  )
}

export default NuevoReactivo;
