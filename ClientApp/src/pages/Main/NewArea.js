import React, { useState, useEffect, useContext } from "react";
import { Form, Field, Formik } from "formik";
import API from "../../utils/API"
import ConfigNav from "../../components/ConfigNav";
import ComponentContext from "../../utils/ComponentContext";

const NewArea = (props) => {
  const component = useContext(ComponentContext);
  const [editable, setEditable] = useState(false)

    const [departamentos, setDepartamentos] = useState([""]);
    useEffect(() => {
      const fetchData = async () => {
        const result = await API.getDepartments({id:"",clave:"",nombre:""});
        console.log(result)
        setDepartamentos(result.data);
      };
      fetchData();
    }, []);
  
    if (component.data) {
      console.log(component.data)
    var nombre = component.data.nombre;
    var id = component.data.id;
    var clave = component.data.clave;
    var activo = component.data.activo;
    var departamentoId = component.data.departamentoId;
   }

  const initialValues = {
    area: {
      clave: clave,
      nombre: nombre,
      id: id,
      activo: activo,
      departamentoId: departamentoId,
    }
  }

  function _onSubmit(values) {
    if (component.data) {
      console.log(values)
      API.updateArea(values)
        .then(res => {
          console.log(res.data);
        })
        .catch(err => console.log(err));
    } else {
      API.addArea(values)
        .then(res => {
          setEditable(false);
          values.area.id = res.data.id
          var data = values.area;
          component.onClick("NewArea", {data});

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
            <p class="is-size-4 has-text-weight-bold" >Catalogo de areas.</p>
          </div>
        </nav>

        <nav class="level">
          <div class="level-left">
            <p>REGISTRO NUEVO</p>
          </div>

          <div class="level-right">
            <p class="level-item"><button class="button is-primary" type="submit" onClick={() => { setEditable(false) }}> Guardar </button></p>
            <p class="level-item">{component.data ? <button class="button is-primary" onClick={() => { setEditable(true) }}>MODIFY</button> : null}</p>
            <p class="level-item"><a class="button is-success" type="submit" onClick={() => { component.onClick("Areas") }}>CERRAR</a></p>
          </div>
        </nav>

        <nav class="level">
          <div class="level-left">
            <div class="level-item">
              <p class="control">
                <span class="tag is-light">Nombre</span>
                <Field disabled={component.data && !editable} class="input" type="text" name="area.nombre" placeholder="Nombre" />
              </p>
            </div>
          </div>
        </nav>


        <nav class="level">
          <div class="level-left">
            <div class="level-item">
              <p class="control">
                <span class="tag is-light">Clave</span>
                <Field disabled={component.data && !editable} class="input" type="text" name="area.clave" placeholder="Clave" />
              </p>
            </div>
          </div>
        </nav>

        <nav class="level">
          <div class="level-left">
            <div class="level-item">
                  <p class="control">
                    <span class="tag is-light">Departamento</span>
                    <Field disabled={component.data && !editable} component="select" onChange={(e) => { setFieldValue("area.departamentoId", parseInt(e.target.value)); }}
                  name="area.departamentoId" id="area.departamentoId" class="input" placeholder="Departamento">
                  <option>SELECCIONAR</option>
                  {departamentos.map(item => (<option value={item.id}>{item.nombre}</option>))}
                    </Field>
                  </p>
            </div>
          </div>
        </nav>


        <nav class="level">
          <div class="level-left">
            <div class="level-item">
              <div id="my-radio-group">Activo</div>
              <div role="group" aria-labelledby="my-radio-group">
                <label>
                  <Field type="radio" name="area.activo" value="1" />
                  Si
                </label>
                <label>
                  <Field type="radio" name="area.activo" value="0" />
                  No
                </label>
              </div>
            </div>
          </div>
        </nav>

    </Form>
    )} />
    </>
  );
   
}
export default NewArea;