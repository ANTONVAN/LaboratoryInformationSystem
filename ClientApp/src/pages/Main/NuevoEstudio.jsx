import React, { useState, useEffect, useContext } from "react";
import { useFormik, FieldArray, Form, Field, Formik } from "formik";
import API from "../../utils/API"

import ComponentContext from "../../utils/ComponentContext";
import EstudiosContext from "../../utils/EstudiosContext";
import ConfigNav from "../../components/ConfigNav";

const NuevoEstudio = () => {
  const [editable, setEditable] = useState(false)
  //Desestructurando el objeto del estudio a editar de la tabla de estudios
  const component = useContext(ComponentContext);
  if (component.data) {
    console.log(component.data)
    var id = component.data.id;
    var nombre = component.data.nombre;
    var clave = component.data.clave;
    var maquiladorId = component.data.maquiladorId;
    var areaId = component.data.areaId;
    var metodoId = component.data.metodoId;
    var parametros = component.data.parametros

  }
  //Cargando datos de areas, metodos y maquiladores para mostrar en los select input
  const [areas, setAreas] = useState([""]);
  const [metodos, setMetodos] = useState([""]);
  const [maquiladores, setMaquiladores] = useState([""]);
  useEffect(() => {
    const fetchData = async () => {
      const areas = await API.getAreas({ clave: "", nombre: "" });
      setAreas(areas.data); 

      const metodos = await API.getMetodos({ clave: "", nombre: "" });
      setMetodos(metodos.data);

      const maquiladores = await API.getMaquiladores({clave: "", nombre: ""});
      setMaquiladores(maquiladores.data);
    };
    fetchData();
  }, []);

  //Objeto de valores iniciales a utilizar en formularios de Formik 
  const initialValues = {
    estudio: {
      id:id,
      search: "",
      clave: clave,
      nombre: nombre,
      areaId: areaId,
      maquiladorId: maquiladorId,
      metodoId: metodoId,
    },
    parametros: parametros,
    parametroClave: ""
  }
  //Guardar o actualizar estudio en BD - Relacionar estudio con parametro
  function _onSubmit(values) {
    
    if (values.estudio.id) {
      API.updateEstudio(values.estudio).then(res => {
        
        //Obtener parametro de BD
        API.getParametersByKey(values.parametroClave).then(res => {
          var par = res.data.pop(-1)
          values.estudio.parametros = []
          values.estudio.parametros.push(par);
          if(values.parametros==null) values.parametros=[]
          values.parametros.push(par)
          console.log(values.parametros)
          //Actualizar estudio relacionado con parametros
          API.updateEstudio(values.estudio);

        });
      });
    } else {
      API.addEstudio(values.estudio).then(res => {
        setEditable(false);
        values.estudio.id = res.data.id
        var data = values.estudio;
        component.onClick("NuevoEstudio", { data });
        console.log(res.data);
      }).catch(err => console.log(err));
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
            <p class="is-size-4 has-text-weight-bold" >Catalogo de Estudios.</p>
          </div>
        </nav>

        <nav class="level">
          <div class="level-left">
            <p>REGISTRO NUEVO</p>
          </div>

          <div class="level-right">
                <p class="level-item"><button class="button is-primary" type="submit" onClick={() => { setEditable(false) }}> Guardar </button></p>
            <p class="level-item">{component.data ? <button class="button is-primary" onClick={() => { setEditable(true) }}>MODIFY</button> : null}</p>
            <p class="level-item"><a class="button is-success" type="submit" onClick={() => { component.onClick("catEstudios") }}>CERRAR</a></p>
          </div>
        </nav>

        <nav class="level">
          <div class="level-left">
            <div class="level-item">
              <p class="control">
                <span class="tag is-light">Nombre</span>
                <Field class="input" disabled={component.data && !editable} type="text" name="estudio.nombre" placeholder="Nombre" />
              </p>
            </div>
          </div>
        </nav>

        <nav class="level">
          <div class="level-left">
            <div class="level-item">
              <p class="control">
                <span class="tag is-light">Clave</span>
                <Field class="input" disabled={component.data && !editable} type="text" name="estudio.clave" placeholder="Clave" />
              </p>
            </div>
          </div>
        </nav>

        <div class="columns">
          <div class="column is-one-quarter">
            {/*First column*/}
            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <p class="control">
                    <span class="tag is-light">Area</span>
                    <Field component="select" onChange={(e) => { setFieldValue("estudio.areaId", parseInt(e.target.value)); }}
                          name="estudio.areaId" id="estudio.areaId" class="input" placeholder="TIPO DE VALOR" disabled={component.data && !editable}>
                      <option>SELECCIONAR</option>
                      {areas.map(item => (<option value={item.id}>{item.nombre}{item.id}</option>))}
                    </Field>
                  </p>
                </div>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <p class="control">
                    <span class="tag is-light">Metodo</span>
                    <Field component="select" onChange={(e) => { setFieldValue("estudio.metodoId", parseInt(e.target.value)); }}
                          name="estudio.metodoId" id="estudio.metodoId" class="input" disabled={component.data && !editable}>
                      <option>SELECCIONAR</option>
                      {metodos.map(item => (<option value={item.id}>{item.nombre}{item.id}</option>))}
                    </Field>
                  </p>
                </div>
              </div>
            </nav>
         </div>

        <div class="column is-one-quarter">
          {/*Second column*/}
          <nav class="level">
            <div class="level-left">
              <div class="level-item">
                <p class="control">
                    <span class="tag is-light">Maquilador</span>
                    <Field component="select" onChange={(e) => { setFieldValue("estudio.maquiladorId", parseInt(e.target.value)); }}
                    name="estudio.maquiladorId" id="estudio.maquiladorId" class="input" disabled={component.data && !editable}>
                    <option>SELECCIONAR</option>
                    {maquiladores.map(item => (<option value={item.id}>{item.nombre}{item.id}</option>))}
                  </Field>
                </p>
              </div>
            </div>
          </nav>
        </div>

      </div>

      <nav class="level">
        <div class="level-left">
          <div class="level-item">
            <p>PARAMETROS DEL ESTUDIO</p>
          </div>
        </div>
      </nav>

      <nav class="level">
        <div class="level-item has-text-centered" onClick={() => { }}>
          MODIFICAR
        </div>
      </nav>

      <FieldArray
        name="parametros"
        render={(arrayHelpers) => (
          <table class="table is-fullwidth">

              <Field name="parametroClave" handleSubmit={() => { arrayHelpers.push("") }} />

            <thead>
              <th>CLAVE</th>
              <th>NOMBRE</th>
              <th>TIPO</th>
              <th></th>    
            </thead>

            <tbody>
              {values.parametros && values.parametros.length > 0 ? (
                values.parametros.map((parametro, index) => (
                  <tr key={index}>
                    <td > { parametro.clave } </td>
                    <td> { parametro.nombre } </td>
                    <td> { parametro.valorTipoId } </td>
                    <td>
                      <button type="button" onClick={() => arrayHelpers.remove(index)} >Eliminar</button>{/*remove a friend from the list*/}
                    </td>
                  </tr>
                )))
                : (<div></div>)
             }
              <button type="button" onClick={() => arrayHelpers.push('')}>Agregar un parametro</button>{/* show this when user has removed all friends from the list */}
              <button type="submit">Guardar</button>
            </tbody>

            </table>
        )}/>
        </Form>
        )}/>
    </>
  )
}

export default NuevoEstudio;
