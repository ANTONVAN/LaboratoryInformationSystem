import React, {useState, useEffect, useContext } from "react";
import API from "../../utils/API"
import ConfigNav from "../../components/ConfigNav";
import ComponentContext from "../../utils/ComponentContext";
import {Formik, Form, Field, FieldArray, useFormikContext} from "formik";

const NewParameter = () => {
  
  // Estado para habilitar o deshabilitar formulario.
  const [editable, setEditable] = useState(false);
  
  //Desestructurando el objeto del parametro a editar de la tabla de parametros
  const component = useContext(ComponentContext);
  let id, clave, nombre, unidades, areaId, valorTipoId, reactivoId, valorReferencias;
  if (component.data) {
    ({ id, clave, nombre, unidades, areaId, valorTipoId, reactivoId, valorReferencias } = component.data)    
  }
  //Cargando datos de areas y valortipos para mostrar en los select input
  const [areas, setAreas] = useState([""]);
  const [reactivos, setReactivos] = useState([""]);
  const [valorTipos, setValorTipos] = useState([""]);
  useEffect(() => {
    const fetchData = async () => {
      const areas = await API.getAreas({id:"",nombre:""});
      setAreas(areas.data);
      const reactivos = await API.getReactivos({ id: "", nombre: "" })
      setReactivos(reactivos.data)
      const valorTipos = await API.getValorTipos();
      setValorTipos(valorTipos.data);            
    };
    fetchData();  
  },[]);

  //Objeto de valores iniciales a utilizar en formularios de Formik 
  const initialValues = {
    parameter:{ 
      id: id,
      clave: clave,
      nombre: nombre,
      unidades: unidades,
      areaId: areaId,
      valorTipoId: valorTipoId,
      reactivoId: reactivoId
    },
    valorReferencias: valorReferencias,
  }

  //Guardar o actualizar parametro en BD - Guardar valor de referencia
  function _onSubmit(values) {

    if (values.parameter.id) {
      
      API.updateParameter(values).then(res => {
        //Asignar el ID del parametro a cada valorReferencia para que se relacionen en BDs
        values.valorReferencias.forEach(valorReferencia => { valorReferencia.parametroId = values.parameter.id; });
        //Filtrar valores de referencia nuevos que se crearan del array
        var newValRefs = values.valorReferencias.filter(valorReferencia => valorReferencia.id == null);
        //Filtrar valores de referencia existentes a modificar (si es necesario) - del array
        var valRefs = values.valorReferencias.filter(valorReferencia => valorReferencia.id );
        //Agregar valores de referencia
        if (newValRefs.length > 0) {
          newValRefs.forEach(newValRef => { API.addValorReferencias(newValRef) });
        }
        //Editar valores de referencia
        if (valRefs.length > 0) {
          valRefs.forEach(valRef => { API.updateValorReferencias(valRef) });
        }
        
      }).catch(err => console.log(err));
    } else {
      //Agregar parametro
      API.addParameter(values).then(res => {
        setEditable(false);
        values.parameter.id = res.data.id;
        var data = values.parameter;
        component.onClick("NewParameter", { data });
      }).catch(err => console.log(err));
    }
    setEditable(false);
  }

    return(
      <>
      <ConfigNav />
      <Formik
        initialValues={initialValues}
        onSubmit={values => { _onSubmit(values) }}
        render={({ values, setFieldValue }) => (
          <Form>

            <nav class="level">
              <div class="level-left">
                <p class="is-size-3 has-text-weight-bold" >Catalogo de Parametros.</p>
              </div>
            </nav>
            <nav class="level">
              <div class="level-left">
                <p>REGISTRO NUEVO</p>
              </div>
              <div class="level-right">
                {component.data ? <p class="level-item"><a class="button is-primary" type="submit" onClick={()=>{setEditable(true)}}>Modificar</a></p> : null}
                <p class="level-item"><button class="button is-primary" type="submit"> Guardar </button></p>
                <p class="level-item"><a class="button is-primary" type="submit" onClick={()=>{component.onClick("Parameters")}}>Cerrar</a></p>
              </div>
            </nav>

            <div class="columns">
              <div class="column is-one-quarter">
                <fieldset disabled={component.data && !editable}>
                <nav class="level">
                  <div class="level-left">
                      <div class="level-item">
                        <span class="tag is-light">Clave</span>
                        <p class="control">                          
                          <Field class="input" type="text" name="parameter.clave" placeholder="Clave" />
                      </p>
                    </div>
                  </div>
                </nav>
                <nav class="level">
                  <div class="level-left">
                      <div class="level-item">
                        <p class="control">
                          <span class="tag is-light">Nombre</span>
                        <Field class="input" type="text" name="parameter.nombre" placeholder="Nombre" />
                      </p>
                    </div>
                  </div>
                </nav>
                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                      <span class="tag is-light">Tipo de valor</span>
                      <Field component="select" onChange={(e) => { setFieldValue("parameter.valorTipoId", parseInt(e.target.value)); }}
                        name="parameter.valorTipoId" id="parameter.valorTipoId" class="input" placeholder="TIPO DE VALOR">
                        <option>SELECCIONAR</option>
                        {valorTipos.map(item => (<option value={item.id}>{item.nombre}{item.id}</option>))}
                      </Field>
                      </p>
                  </div>
                </div>
              </nav>
              </fieldset>
              </div>

              

              <div class="column is-one-quarter">
                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Unidades</span>
                        <Field class="input" disabled={component.data && !editable} type="text" name="parameter.unidades" placeholder="Unidades" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Reactivo</span>
                        <Field component="select" onChange={(e) => { setFieldValue("parameter.reactivoId", parseInt(e.target.value)); }}
                          name="parameter.reactivoId" disabled={component.data && !editable} id="parameter.reactivoId" class="input" placeholder="REACTIVO">
                          <option>SELECCIONAR</option>
                          {reactivos.map(item => (<option value={item.id}>{item.nombre}{item.id}</option>))}
                        </Field>
                      </p>
                    </div>
                  </div>
                </nav>
              </div>
                
              </div>

                        
              <FieldArray
              name="valorReferencias"
              render={ arrayHelpers => (
                <div>
                  <nav class="level">
                    <div class="level-left">
                      <div class="level-item">
                        <p class="control">
                          Valores de referencia
                        </p>
                      </div>
                    </div>
                    <div class="level-right">
                      <div class="level-item">
                        <p class="control">
                          <button disabled={!component.data} class="button is-primary" type="submit">Guardar</button>
                        </p>
                      </div>
                    </div>
                  </nav>
                  {values.valorReferencias && values.valorReferencias.length > 0 ?
                  /*Valor numerico*/
                  values.parameter.valorTipoId === 1 ?
                  (values.valorReferencias.map((valorReferencia, index) => (
                    <div key={index}>
                      <nav class="level">
                        <div class="level-left">
                          <div class="level-item">
                            <p class="control">
                            <span class="tag is-light">Minimo</span>
                              <Field class="input" type="number" name={`valorReferencias.${index}.valor1`} />
                            </p>
                          </div>
                          <div class="level-item">
                            <p class="control">
                              <span class="tag is-light">Maximo</span>
                              <Field class="input" type="number" name={`valorReferencias.${index}.valor2`} />
                            </p>
                          </div>
                        </div>
                      </nav>
                    </div>)))
                  
                  : values.parameter.valorTipoId === 4 ?
                  /*Valor numerico por sexo*/
                  (values.valorReferencias.map((valorReferencia, index) => (
                  <div key={index}>
                  <div>Sexo</div>
                  <Field component="select" 
                  name="`valorReferencias.${index}.valor1`" class="form-control" placeholder="SEXO">
                    <option>SELECCIONAR</option>
                    <option>MASCULINO</option>
                    <option>FEMENINO</option>                    
                  </Field>
                  <div>Rango</div>
                  <Field name={`valorReferencias.${index}.valor1`} />
                  <Field name={`valorReferencias.${index}.valor2`} />
                  <button type="button" onClick={() => arrayHelpers.remove(index)} >-</button> {/*remove a friend from the list*/}
                  <button type="button" onClick={() => arrayHelpers.insert(index, "")}>+</button>{/*insert an empty string at a position*/}
                  </div>)))

                  :values.parameter.valorTipoId === 2 ?
                  /*Valor numerico por edad*/
                  (values.valorReferencias.map((valorReferencia, index) => (
                    <div key={index}>
                    <div>Range</div>
                    <Field name={`valorReferencias.${index}.valor1`} />
                    <Field name={`valorReferencias.${index}.valor2`} />
                    <div>Age</div>
                    <Field name={`valorReferencias.${index}.edad1`} />
                    <Field name={`valorReferencias.${index}.edad2`} />
                      <button type="button" onClick={() => arrayHelpers.remove(index)} >-</button> {/*remove a friend from the list*/}
                      <button type="button" onClick={() => arrayHelpers.insert(index, "")} >+</button> {/*insert an empty string at a position*/}
                    </div>))
                   )

                  : values.parameter.valorTipoId === 3 ?
                  /*Valor numerico por edad y sexo*/
                  (values.valorReferencias.map((valueType, index) => (
                    <div key={index}>
                    <div>Sexo</div>
                    <Field name={`valorReferencias.${index}.sexo`} />
                    <div>Rango</div>
                    <Field name={`valorReferencias.${index}.valor1`} />
                    <Field name={`valorReferencias.${index}.valor2`} />
                    <div>Edad</div>
                    <Field name={`valorReferencias.${index}.edad1`} />
                    <Field name={`valorReferencias.${index}.edad2`} />

                    <button type="button" onClick={() => arrayHelpers.remove(index)} >-</button> {/*remove a friend from the list*/}
                    <button type="button" onClick={() => arrayHelpers.insert(index, "")}>+</button>{/*insert an empty string at a position*/}
                    </div>)))


                  : values.parameter.valorTipoId === 5 ?
                  /*Opcion multiple*/
                  (values.valorReferencias.map((valueType, index) => (
                    <div key={index}>
                      <Field name={`valorReferencias.${index}.multiple`} />
                      <button type="button" onClick={() => arrayHelpers.remove(index)}>-</button> { /*remove a friend from the list*/ }
                      <button type="button" onClick={() => arrayHelpers.insert(index, "")}>+</button>  { /*insert an empty string at a position*/}
                    </div>)))

                  : <div></div>

                    : (<button disabled={!component.data} class="button is-primary" type="button" onClick={() => arrayHelpers.push("")}>Agregar</button>)}
              </div>
              )}/>
              
        </Form>
      )}/>
      
  

  </>
  )
}

export default NewParameter;





