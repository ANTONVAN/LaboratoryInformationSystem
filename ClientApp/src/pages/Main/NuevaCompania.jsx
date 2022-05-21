import React, { useState, useEffect, useContext } from "react";
import { useFormik, FieldArray, Form, Field, Formik } from "formik";
import API from "../../utils/API"

import ComponentContext from "../../utils/ComponentContext";
import ConfigNav2 from "../../components/ConfigNav2";

const NuevaCompania = () => {

  //Desestructurando el objeto del estudio a editar de la tabla de estudios
  const component = useContext(ComponentContext);
  if (component.data) {
    console.log(component.data)
    var id = component.data.id;
    var nombre = component.data.nombre;
    var clave = component.data.clave;
    var RFC = component.data.rfc;
    var CP = component.data.cp;
    var telefono = component.data.telefono;
    var razonsocial = component.data.razonSocial;
    var email = component.data.email;
    var status = component.data.status;
    var catPrecioId = component.data.catPrecioId

  }
  //Cargando datos de areas, metodos y maquiladores para mostrar en los select input
  const [catPrecios, setCatPrecios] = useState([""]);
  useEffect(() => {
    const fetchData = async () => {
      const catPrecios = await API.getCatPrecios({ clave: "", nombre: "" });
      setCatPrecios(catPrecios.data);
    };
    fetchData();
  }, []);

  //Objeto de valores iniciales a utilizar en formularios de Formik 
  const initialValues = {
    compania: {
      id: id,
      search: "",
      clave: clave,
      nombre: nombre,
      RFC: RFC,
      CP: CP,
      Telefono: telefono,
      RazonSocial: razonsocial,
      Email: email,
      status: status,
      catPrecioId: catPrecioId
    }
  }
  //Guardar o actualizar estudio en BD - Relacionar estudio con parametro
  function _onSubmit(values) {

    if (values.compania.id) {
      console.log(values)
      API.updateCompania(values.compania).then(res => { }).catch(err => console.log(err));
    } else {
      API.addCompania(values.compania).then(res => { }).catch(err => console.log(err));
    }
  }

  return (
    <>
      <ConfigNav2 />
      <Formik
        initialValues={initialValues}
        onSubmit={values => { _onSubmit(values) }}
        render={({ values, setFieldValue }) => (

          <Form>

            <nav class="level">
              <div class="level-left">
                <p class="is-size-4 has-text-weight-bold" >Catalogo de Compañias.</p>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <p>REGISTRO NUEVO</p>
              </div>

              <div class="level-right">
                <p class="level-item"><button class="button is-primary" type="submit"> Guardar </button></p>
                <p class="level-item"><a class="button is-success" type="submit" onClick={() => { component.onClick("Companias") }}>CERRAR</a></p>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <p class="control">
                    <span class="tag is-light">Nombre</span>
                    <Field class="input" type="text" name="compania.nombre" placeholder="Nombre" />
                  </p>
                </div>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <p class="control">
                    <span class="tag is-light">Clave</span>
                    <Field class="input" type="text" name="compania.clave" placeholder="Clave" />
                  </p>
                </div>
              </div>
            </nav>

            <div class="columns">
              <div class="column is-one-quarter">
                First column
                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">RFC</span>
                        <Field class="input" type="text" name="compania.RFC" placeholder="RFC" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Razon social</span>
                        <Field class="input" type="text" name="compania.RazonSocial" placeholder="Razon Social" />
                      </p>
                    </div>
                  </div>
                </nav>


              <nav class="level">
                <div class="level-left">
                  <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Correo</span>
                      <Field class="input" type="text" name="compania.Email" placeholder="Email" />
                    </p>
                  </div>
                </div>
              </nav>
              </div>

              <div class="column is-one-quarter">
                Second column

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Status</span>
                        <Field class="input" type="text" name="compania.Status" placeholder="Status" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">CP</span>
                        <Field class="input" type="text" name="compania.CP" placeholder="CP" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <div class="select">
                        <span class="tag is-light">Catalogo de precios</span>
                        <Field component="select" onChange={(e) => { setFieldValue('compania.catPrecioId', parseInt(e.target.value)); }}
                          name="compania.catPrecioId" id="compania.catPrecioId" class="form-control">
                          <option>SELECCIONAR</option>
                          {catPrecios.map(item => (<option value={item.id}>{item.nombre}{item.id}</option>))}
                        </Field>
                      </div>
                    </div>
                  </div>
                </nav>

              </div>
            </div>

          </Form>
        )} />
    </>
  )
}

export default NuevaCompania;
