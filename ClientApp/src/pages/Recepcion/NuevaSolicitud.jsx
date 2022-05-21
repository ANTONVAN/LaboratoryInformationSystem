import React, { useState, useContext } from "react";
import { Form, Field, Formik, FieldArray } from "formik";
import API from "../../utils/API"
import ComponentContext from "../../utils/ComponentContext";


const NuevaSolicitud = (props) => {

  // Estado para habilitar o deshabilitar formulario.
  const [editable, setEditable] = useState(false)
  const component = useContext(ComponentContext);

  if (component.data) {
    var nombre = component.data.nombre;
    var id = component.data.id; 
    var clave = component.data.clave;
    var apellidos = component.data.apellidos;
    var direccion = component.data.direccion;
    var edad = component.data.edad;
    var sexo = component.data.sexo;
    var fechaNacimiento = component.data.fechaNacimiento;
    var celular = component.data.celular;
    var telefono = component.data.telefono;
    var cp = component.data.cp;
  }

  //Objeto de valores iniciales a utilizar en formularios de Formik 
  const initialValues = {
    solicitud: {
      total: 0,
      cargo: 0,
      descuento: 0,
      status: "PENDIENTE",
      companiaId: 0,
      medicoId: 0,
      pacienteId: 0,
      estudioSols: [],
      paciente: {
        id: id,
        nombre: nombre,
        apellidos: apellidos,
        direccion: direccion,
        edad: edad,
        sexo: sexo,
        fechaNacimiento: fechaNacimiento,
        celular: celular,
        telefono: telefono,
        cp: cp
      },
    },

    medico: "",
    compania: "",
    
    estudioKey: "",
    companiaKey: "",
    medicoKey: ""
    
  }

  //Guardar o actualizar solicitud en BD 
  function _onSubmit(values) {
    
    if (values.id) {
      API.updateSolicitud(values)
      .then(res => { console.log(res); })
      .catch(err => console.log(err));
    } else {

    if (values.companiaKey) {
      API.getCompaniaByKey(values.companiaKey).then(res => {
        var data = res.data.pop(-1);
        values.compania = data;
        values.solicitud.companiaId = data.id;
      });
    }

    if (values.medicoKey) {
      API.getMedicoByKey(values.medicoKey).then(res => {
        var data = res.data.pop(-1);
        values.medico = data;
        values.solicitud.medicoId = data.id;
      });
    }

    if (values.estudioKey) {
      API.getEstudioByKey(values.estudioKey).then(res => { 
        var data = res.data[res.data.length - 1];
        var estudioId = data.id;
        var estudioNombre = data.nombre;
        var estudioClave = data.clave;
        API.getListaPrecio(estudioId, values.compania.catPrecioId).then(res => {
          var estudioPrecio = res.data[res.data.length-1].precio;
          values.solicitud.estudioSols.push({ "estudioId": estudioId, "nombre": estudioNombre, "precio": estudioPrecio, "clave": estudioClave});
          values.solicitud.total += estudioPrecio;
        })
      })
    }

    if (values.solicitud.medicoId && values.solicitud.companiaId && values.solicitud.estudioSols.length > 0) {
    API.addSolicitud(values.solicitud)
    .then(res => { console.log(res); })
    .catch(err => console.log(err));
    }

      //API.addPaciente(values.paciente).then(res => {console.log(res);}).catch(err => console.log(err));
    }
  }


  


  return (
    <>
      <Formik
      initialValues={initialValues}
      onSubmit={values => { _onSubmit(values) }}
      >
        {({formik, values, setFieldValue }) => (

          <Form>
            <pre>{JSON.stringify(values, null, 2)}</pre>
            <nav class="level">
              <div class="level-left">
                <p class="is-size-4 has-text-weight-bold" >Nueva solicitud</p>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <p>REGISTRO NUEVO</p>
              </div>

              <div class="level-right">
                <p class="level-item"><button class="button is-primary" type="submit" onClick={() => { setEditable(false) }}> Guardar </button></p>
                <p class="level-item">{component.data ? <button class="button is-primary" onClick={() => { setEditable(true) }}>MODIFY</button> : null}</p>
                <p class="level-item"><a class="button is-success" type="submit" onClick={() => { component.onClick("Solicitudes") }}>CERRAR</a></p>
              </div>
            </nav>


            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <p class="control">
                    <span class="tag is-light">TOTAL</span>
                    <Field disabled={component.data && !editable} class="input is-small" type="number" name="solicitud.total"/>
                  </p>
                </div>
                <div class="level-item">
                  <p class="control">
                    <span class="tag is-light">CARGO</span>
                    <Field disabled={component.data && !editable} class="input is-small" type="number" name="solicitud.cargo" />
                  </p>
                </div>
                <div class="level-item">
                  <p class="control">
                    <span class="tag is-light">DESCUENTO</span>
                    <Field disabled={component.data && !editable} class="input is-small" type="number" name="solicitud.descuento" />
                  </p>
                </div>
              </div>
            </nav>




            <div class="columns is-gapless">
              <div class="column is-one-quarter">
                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Nombre</span>
                        <Field disabled={component.data && !editable} class="input is-small" type="text" name="solicitud.paciente.nombre" placeholder="" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Apellidos</span>
                        <Field disabled={component.data && !editable} class="input is-small" type="text" name="solicitud.paciente.apellidos" placeholder="" />
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
                        <span class="tag is-light">Direccion</span>
                        <Field disabled={component.data && !editable} class="input is-small" type="text" name="solicitud.paciente.direccion" />
                      </p>
                    </div>
                  </div>
                </nav>
              

              
                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Sexo</span>
                        <Field disabled={component.data && !editable} class="input is-small" type="text" name="solicitud.paciente.sexo" />
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
                        <span class="tag is-light">Edad</span>
                        <Field disabled={component.data && !editable} class="input is-small" type="number" name="solicitud.paciente.edad" />
                      </p>
                    </div>
                  </div>
                </nav>


                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Fecha nacimiento</span>
                        <Field disabled={component.data && !editable} class="input is-small" type="date" name="solicitud.paciente.fechaNacimiento" />
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
                        <span class="tag is-light">Celular</span>
                        <Field disabled={component.data && !editable} class="input is-small" type="number" name="solicitud.paciente.celular" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Telefono</span>
                        <Field disabled={component.data && !editable} class="input is-small" type="number" name="solicitud.paciente.telefono" />
                      </p>
                    </div>
                  </div>
                </nav>
              </div>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Codigo postal</span>
                        <Field disabled={component.data && !editable} class="input is-small" type="number" name="solicitud.paciente.cp" />
                      </p>
                    </div>
                  </div>
                </nav>
              
            </div>

            <div class="tabs is-boxed">
              <ul>
                <li class="is-active">
                  <a>
                    <span class="icon is-small"><i class="fas fa-image" aria-hidden="true"></i></span>
                    <span>General</span>
                  </a>
                </li>
                <li>
                  <a>
                    <span class="icon is-small"><i class="fas fa-music" aria-hidden="true"></i></span>
                    <span>Estudios</span>
                  </a>
                </li>
              </ul>
            </div>


            <div class="columns">
              <div class="column is-one-quarter">
                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Compania</span>
                        <Field disabled={component.data && !editable} class="input is-small" type="text" name="companiaKey"/> 
                        {/*<Field disabled={true} class="input is-small" type="text" name="companiaKey"  />*/}
                      </p>
                    </div>
                  </div>
                </nav>
                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Medico</span>
                        <Field disabled={component.data && !editable} class="input is-small" type="text" name="medicoKey" placeholder="" />
                        {/*<Field disabled={true} class="input is-small" type="text" name="medico" placeholder="" />*/}
                      </p>
                    </div>
                  </div>
                </nav>
              </div>
            </div>



            <FieldArray
              name="estudioSols"
              render={(arrayHelpers) => (
                <>
                <Field name="estudioKey" handleSubmit={() => { arrayHelpers.push("") }} />
                <table class="table is-fullwidth">

                  <thead>
                    <th>CLAVE</th>
                    <th>NOMBRE</th>
                    <th>PRECIO</th>
                    <th></th>
                  </thead>

                  <tbody>
                    {values.solicitud.estudioSols && values.solicitud.estudioSols.length > 0 ? (
                      values.solicitud.estudioSols.map((estudio, index) => (
                        <tr key={index}>
                          <td > {estudio.clave} </td>
                          <td> {estudio.nombre} </td>
                          <td> {estudio.precio} </td>
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

                </table></>
              )} />


          </Form>
        )} 
      </Formik>
    </>
  );

}

export default NuevaSolicitud;