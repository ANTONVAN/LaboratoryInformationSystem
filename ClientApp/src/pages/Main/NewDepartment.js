    import React, { useState, useContext } from "react";
import { Form, Field, Formik } from "formik";
import API from "../../utils/API"
import ConfigNav from "../../components/ConfigNav";
import ComponentContext from "../../utils/ComponentContext";


const NewDepartment = (props) => {
  const [editable, setEditable] = useState(false)
  const component = useContext(ComponentContext);
  
  if (component.data) {
    var nombre = component.data.nombre;
    var id = component.data.id;
    var clave = component.data.clave;
   }


  const initialValues = {
    departamento: {
      id: id,
      clave: clave,
      nombre: nombre,
    }
  }
    
  function _onSubmit(values) {
    if (component.data) {
      API.updateDepartment(values)
      .then(res => {
        console.log(res);
      })
      .catch( err => console.log(err) );
    } else {
      API.addDepartment(values) 
      .then(res => {
        console.log(res);
        setEditable(false);
        values.departamento.id = res.data.id
        var data = values.departamento;
        component.onClick("NewDepartment", { data });
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
                <p class="is-size-4 has-text-weight-bold" >Catalogo de departamentos.</p>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <p>REGISTRO NUEVO</p>
              </div>

              <div class="level-right">
                <p class="level-item"><button class="button is-primary" type="submit" onClick={() => {setEditable(false)}}> Guardar </button></p>
                <p class="level-item">{component.data ? <button class="button is-primary" onClick={() => {setEditable(true)}}>MODIFY</button> : null}</p>
                <p class="level-item"><a class="button is-success" type="submit" onClick={() => { component.onClick("Departments") }}>CERRAR</a></p>
              </div>
            </nav>


            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <p class="control">
                    <span class="tag is-light">Nombre</span>
                    <Field disabled={component.data && !editable} class="input" type="text" name="departamento.nombre" placeholder="Nombre" />
                  </p>
                </div>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <p class="control">
                    <span class="tag is-light">Clave</span>
                    <Field disabled={component.data && !editable} class="input" type="text" name="departamento.clave" placeholder="Clave" />
                  </p>
                </div>
              </div>
            </nav>
          </Form>
        )} />
    </>
  );
   
}

export default NewDepartment;