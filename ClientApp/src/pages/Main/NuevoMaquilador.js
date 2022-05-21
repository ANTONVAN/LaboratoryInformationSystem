import React, { useState, useContext } from "react";
import { Form, Field, Formik } from "formik";
import API from "../../utils/API"
import ConfigNav from "../../components/ConfigNav";
import ComponentContext from "../../utils/ComponentContext";


const NuevoMaquilador = (props) => {
  const [editable, setEditable] = useState(false)
  const component = useContext(ComponentContext);

  if (component.data) {
    var nombre = component.data.nombre;
    var id = component.data.id;
    var clave = component.data.clave;
  }

  const initialValues = {
    maquilador: {
      clave: clave,
      nombre: nombre,
      id: id,
    }
  }

  function _onSubmit(values) {
    if (component.data) {
      console.log(values)
      API.updateMaquilador(values)
        .then(res => {
          console.log(res.data);
        })
        .catch(err => console.log(err));
    } else {
      API.addMaquilador(values)
        .then(res => {
          setEditable(false);
          values.maquilador.id = res.data.id
          var data = values.maquilador;
          component.onClick("NuevoMaquilador", { data });
          console.log(res.data);
        })
        .catch(err => console.log(err));
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
                <p class="is-size-4 has-text-weight-bold" >Catalogo de maquiladores.</p>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <p>REGISTRO NUEVO</p>
              </div>

              <div class="level-right">
                <p class="level-item"><button class="button is-primary" type="submit" onClick={() => { setEditable(false) }}> Guardar </button></p>
                <p class="level-item">{component.data ? <button class="button is-primary" onClick={() => { setEditable(true) }}>MODIFY</button> : null}</p>
                <p class="level-item"><a class="button is-success" type="submit" onClick={() => { component.onClick("Maquiladores") }}>CERRAR</a></p>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <p class="control">
                    <span class="tag is-light">Clave</span>
                    <Field disabled={component.data && !editable} class="input" type="text" name="maquilador.clave" placeholder="Clave" />
                  </p>
                </div>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <p class="control">
                    <span class="tag is-light">Nombre</span>
                    <Field disabled={component.data && !editable} class="input" type="text" name="maquilador.nombre" placeholder="Nombre" />
                  </p>
                </div>
              </div>
            </nav>

          </Form>
        )} />
    </>
  );

}
export default NuevoMaquilador;