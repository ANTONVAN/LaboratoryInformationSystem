import React, { useState, useContext } from "react";
import { Form, Field, Formik } from "formik";
import Grid from "@material-ui/core/Grid";
import {
  FormControl,
  FormGroup,
  TextField,
  Button,
} from "@material-ui/core";
import PropTypes from 'prop-types';
import API from "../../utils/API"
import ConfigNav from "../../components/ConfigNav";
import ComponentContext from "../../utils/ComponentContext";


const NuevoPaciente = (props) => {
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


  const initialValues = {
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
    }
  }

  function _onSubmit(values) {
    if (component.data) {
      API.updatePaciente(values)
        .then(res => {
          console.log(res);
        })
        .catch(err => console.log(err));
    } else {
      console.log(values)
      API.addPaciente(values.paciente)
        .then(res => {
          console.log(res);
        })
        .catch(err => console.log(err));
    }
  }



  return (
    <>
      <Formik
        initialValues={initialValues}
        onSubmit={values => { _onSubmit(values) }}
        render={({ values, setFieldValue }) => (

          <Form>

            <nav class="level">
              <div class="level-left">
                <p class="is-size-4 has-text-weight-bold" >Catalogo de pacientes.</p>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <p>REGISTRO NUEVO</p>
              </div>

              <div class="level-right">
                <p class="level-item"><button class="button is-primary" type="submit" onClick={() => { setEditable(false) }}> Guardar </button></p>
                <p class="level-item">{component.data ? <button class="button is-primary" onClick={() => { setEditable(true) }}>MODIFY</button> : null}</p>
                <p class="level-item"><a class="button is-success" type="submit" onClick={() => { component.onClick("Pacientes") }}>CERRAR</a></p>
              </div>
            </nav>

        <div class="columns">
          <div class="column is-one-quarter">
            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <p class="control">
                    <span class="">Nombre</span>
                    <Field disabled={component.data && !editable} class="input is-small" type="text" name="paciente.nombre" placeholder="" />
                  </p>
                </div>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                      <p class="control">
                        <span class="">Apellidos</span>
                    <Field disabled={component.data && !editable} class="input is-small" type="text" name="paciente.apellidos" placeholder="" />
                  </p>
                </div>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                      <p class="control">
                        <span class="">Direccion</span>
                    <Field disabled={component.data && !editable} class="input is-small" type="text" name="paciente.direccion"  />
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
                        <span class="">Sexo</span>
                    <Field disabled={component.data && !editable} class="input is-small" type="text" name="paciente.sexo"  />
                  </p>
                </div>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                      <p class="control">
                        <span class="">Edad</span>
                    <Field disabled={component.data && !editable} class="input is-small" type="number" name="paciente.edad" />
                  </p>
                </div>
              </div>
            </nav>


            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                      <p class="control">
                        <span class="">Fecha nacimiento</span>
                    <Field disabled={component.data && !editable} class="input is-small" type="date" name="paciente.fechaNacimiento" />
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
                        <span class="">Celular</span>
                        <Field disabled={component.data && !editable} class="input is-small" type="number" name="paciente.celular"  />
                  </p>
                </div>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                      <p class="control">
                        <span class="">Telefono</span>
                        <Field disabled={component.data && !editable} class="input is-small" type="number" name="paciente.telefono"  />
                  </p>
                </div>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                      <p class="control">
                        <span class="">Codigo postal</span>
                    <Field disabled={component.data && !editable} class="input is-small" type="number" name="paciente.cp"  />
                  </p>
                </div>
              </div>
            </nav>
          </div>
            </div>

          </Form>
        )} />
    </>
  );

}

export default NuevoPaciente;