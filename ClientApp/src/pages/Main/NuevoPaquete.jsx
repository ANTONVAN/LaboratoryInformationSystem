import React, { useState, useEffect, useContext } from "react";
import { useFormik, FieldArray, Form, Field, Formik } from "formik";
import API from "../../utils/API"

import ComponentContext from "../../utils/ComponentContext";
import PaquetesContext from "../../utils/PaquetesContext";
import ConfigNav from "../../components/ConfigNav";

const NuevoPaquete = () => {

  //Desestructurando el objeto del paquete a editar de la tabla de paquetes
  const component = useContext(ComponentContext);
  if (component.data) {
    console.log(component.data)
    var id = component.data.id;
    var nombre = component.data.nombre;
    var clave = component.data.clave;
    var estudios = component.data.estudios

  }
  //Cargando datos de areas, metodos y maquiladores para mostrar en los select input
  useEffect(() => {
    const fetchData = async () => {

    };
    fetchData();
  }, []);

  //Objeto de valores iniciales a utilizar en formularios de Formik 
  const initialValues = {
    paquete: {
      id: id,
      search: "",
      clave: clave,
      nombre: nombre,
    },
    estudios: estudios,
    estudioClave: ""
  }
  //Guardar o actualizar paquete en BD - Relacionar paquete con estudio
  function _onSubmit(values) {

    if (values.paquete.id) {
      API.updatePaquete(values.paquete).then(res => {

        /*        if (values.estudios) {
                  var param = values.estudios.filter(estudio => estudio.id == null).pop(-1);
                }*/

        //Obtener estudio de BD
        API.getParametersByKey(values.estudioClave).then(res => {
          var par = res.data.pop(-1)
          values.paquete.estudios = []
          values.paquete.estudios.push(par);
          if (values.estudios == null) values.estudios = []
          values.estudios.push(par)
          console.log(values.estudios)
          //Actualizar paquete relacionado con estudios
          API.updatePaquete(values.paquete);
        });
      });
    } else {
      API.addPaquete(values.paquete).then(res => { values.paquete.id = res.data.id; }).catch(err => console.log(err));
    }
  }

  return (
    <>
      <ConfigNav />
      <Formik
        initialValues={initialValues}
        enableReinitialize
        onSubmit={values => { _onSubmit(values) }}
        render={({ values, setFieldValue }) => (

          <Form>

            <nav class="level">
              <div class="level-left">
                <p class="is-size-4 has-text-weight-bold" >Catalogo de Paquetes.</p>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <p>REGISTRO NUEVO</p>
              </div>

              <div class="level-right">
                <p class="level-item"><button class="button is-primary" type="submit"> Guardar </button></p>
                <p class="level-item"><a class="button is-success" type="submit" onClick={() => { component.onClick("Paquetes") }}>CERRAR</a></p>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <p class="control">
                    <Field class="input" type="text" name="paquete.nombre" placeholder="Nombre" />
                  </p>
                </div>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <p class="control">
                    <Field class="input" type="text" name="paquete.clave" placeholder="Clave" />
                  </p>
                </div>
              </div>
            </nav>


            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <p>ESTUDIOS DEL PAQUETE</p>
                </div>
              </div>
            </nav>

            <nav class="level">
              <div class="level-item has-text-centered" onClick={() => { }}>
                MODIFICAR
              </div>
            </nav>

            <FieldArray
              name="estudios"
              render={(arrayHelpers) => (
                <table class="table is-fullwidth">

                  <Field name="estudioClave" handleSubmit={() => { arrayHelpers.push("") }} />

                  <thead>
                    <th>CLAVE</th>
                    <th>NOMBRE</th>
                    <th>TIPO</th>
                    <th></th>
                  </thead>

                  <tbody>
                    {values.estudios && values.estudios.length > 0 ? (
                      values.estudios.map((estudio, index) => (
                        <tr key={index}>
                          <td > {estudio.clave} </td>
                          <td> {estudio.nombre} </td>
                          <td> {estudio.area} </td>
                          <td>
                            <button type="button" onClick={() => arrayHelpers.remove(index)} >Eliminar</button>{/*remove a friend from the list*/}
                          </td>
                        </tr>
                      )))
                      : (<div></div>)
                    }
                    <button type="button" onClick={() => arrayHelpers.push('')}>Agregar un estudio</button>{/* show this when user has removed all friends from the list */}
                    <button type="submit">Guardar</button>
                  </tbody>

                </table>
              )} />
          </Form>
        )} />
    </>
  )
}

export default NuevoPaquete;
