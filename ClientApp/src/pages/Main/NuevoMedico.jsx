import React, { useState, useEffect, useContext } from "react";
import { useFormik, FieldArray, Form, Field, Formik } from "formik";
import API from "../../utils/API"

import ComponentContext from "../../utils/ComponentContext";
import ConfigNav3 from "../../components/ConfigNav3";

const NuevoMedico = () => {
  const [editable, setEditable] = useState(false)

  //Desestructurando el objeto del estudio a editar de la tabla de estudios
  const component = useContext(ComponentContext);
  if (component.data) {
    console.log(component.data)
    var id = component.data.id;
    var nombre = component.data.nombre;
    var clave = component.data.clave;
    var CP = component.data.cp;
    var telefono = component.data.telefono;
   
    var apellidos = component.data.apellidos;
    var especialidad = component.data.especialidad;
    var ciudad = component.data.ciudad;
    var estado = component.data.estado;
    var correo = component.data.correo;
    var celular = component.data.celular;
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
    medico: {
      id: id,
      search: "",
      clave: clave,
      nombre: nombre,
      apellidos: apellidos,
      especialidad: especialidad,
      CP: CP,
      ciudad: ciudad,
      estado: estado,
      correo: correo,
      telefono: telefono,
      celular: celular,
      activo: activo
      
    }
  }
  //Guardar o actualizar estudio en BD - Relacionar estudio con parametro
  function _onSubmit(values) {

    if (values.medico.id) {
      console.log(values)
      API.updateMedico(values.medico).then(res => { }).catch(err => console.log(err));
    } else {
      API.addMedico(values.medico).then(res => {
        console.log(res);
        setEditable(false);
        values.medico.id = res.data.id
        var data = values.medico;
        component.onClick("NuevoMedico", { data });
      }).catch(err => console.log(err));
    }
  }

  return (
    <>
      <ConfigNav3 />
      <Formik
        initialValues={initialValues}
        onSubmit={values => { _onSubmit(values) }}
        render={({ values, setFieldValue }) => (

          <Form>

          <nav class="level">
            <div class="level-left">
              <p class="is-size-4 has-text-weight-bold" >Catalogo de Médicos.</p>
            </div>
          </nav>

          <nav class="level">
            <div class="level-left">
              <p>REGISTRO NUEVO</p>
            </div>

            <div class="level-right">
              <p class="level-item"><button class="button is-primary" onClick={() => { setEditable(false) }} type="submit"> Guardar </button></p>
              <p class="level-item">{component.data ? <button class="button is-primary" onClick={() => { setEditable(true) }}>MODIFY</button> : null}</p>
              <p class="level-item"><a class="button is-success" type="submit" onClick={() => { component.onClick("Medicos") }}>CERRAR</a></p>
            </div>
          </nav>

          <div class="columns">

            <div class="column is-one-quarter">
              <nav class="level">
                <div class="level-left">
                  <div class="level-item">
                    <p class="control">
                      <span class="tag is-light">Nombre</span>
                       <Field disabled={component.data && !editable} class="input" type="text" name="medico.nombre" placeholder="Nombre" />
                    </p>
                  </div>
                </div>
              </nav>

              <nav class="level">
                <div class="level-left">
                  <div class="level-item">
                    <p class="control">
                       <span class="tag is-light">Apellidos</span>
                       <Field disabled={component.data && !editable} class="input" type="text" name="medico.apellidos" placeholder="Apellidos" />
                    </p>
                  </div>
                </div>
              </nav>
            </div>

            <div class="column is-one-quarter">
              <nav class="level">
                <div class="level-left">
                  <div class="level-item">
                    <p class="control">
                      <span class="tag is-light">Clave</span>
                      <Field class="input" disabled={component.data && !editable} type="text" name="medico.clave" placeholder="Clave" />
                    </p>
                  </div>
                </div>
              </nav>

              <nav class="level">
                <div class="level-left">
                  <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Especialidad</span>
                      <Field class="input" disabled={component.data && !editable} type="text" name="medico.especialidad" placeholder="Especialidad" />
                    </p>
                  </div>
                </div>
              </nav>
            </div>

          </div>


            <div class="columns">
              <div class="column is-one-quarter">
                First column

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Ciudad</span>
                        <Field class="input" disabled={component.data && !editable} type="text" name="medico.ciudad" placeholder="Ciudad" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Estado</span>
                        <Field class="input" disabled={component.data && !editable} type="text" name="medico.estado" placeholder="Estado" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">CP</span>
                        <Field class="input" disabled={component.data && !editable} type="number" name="medico.CP" placeholder="CP" />
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
                        <span class="tag is-light">Telefono</span>
                        <Field class="input" disabled={component.data && !editable} type="number" name="medico.telefono" placeholder="Telefono" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Celular</span>
                        <Field class="input" disabled={component.data && !editable} type="number" name="medico.celular" placeholder="Celular" />
                      </p>
                    </div>
                  </div>
                </nav>


                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Correo electrónico</span>
                        <Field class="input" disabled={component.data && !editable} type="email" name="medico.correo" placeholder="Correo" />
                      </p>
                    </div>
                  </div>
                </nav>




{/*                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <div class="select">
                        <Field component="select" onChange={(e) => { setFieldValue('medico.catPrecioId', parseInt(e.target.value)); }}
                          name="medico.catPrecioId" id="medico.catPrecioId" class="form-control">
                          <option>SELECCIONAR</option>
                          {catPrecios.map(item => (<option value={item.id}>{item.nombre}{item.id}</option>))}
                        </Field>
                      </div>
                    </div>
                  </div>
                </nav>*/}

              </div>
            </div>

          </Form>
        )} />
    </>
  )
}

export default NuevoMedico;
