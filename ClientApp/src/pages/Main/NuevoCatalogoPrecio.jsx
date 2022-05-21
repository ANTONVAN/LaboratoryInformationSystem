import React, { useState, useEffect, useContext } from "react";
import { FieldArray, Form, Field, Formik } from "formik";
import API from "../../utils/API"

import ComponentContext from "../../utils/ComponentContext";
import ConfigNav2 from "../../components/ConfigNav2";


const NuevoCatalogoPrecio = () => {
  const [editable, setEditable] = useState(false)
  //Desestructurando el objeto de lista de precio a editar de la tabla de listas de precios
  const component = useContext(ComponentContext);
  
  if (component.data) {
    var id = component.data.id;
    var nombre = component.data.nombre;
    var clave = component.data.clave;
    //Lista de estudios incluidos en la lista de precios  
    var listaPrecios = component.data.listaPrecios;
    console.log(listaPrecios)
  }

  //Cargando datos de estudios para mostrar en la tabla -- lista de estudios completa
  const [estudios, setEstudios] = useState([""]);
  useEffect(() => {
    const fetchData = async () => {
      const estudios = await API.getEstudios({ clave: "", nombre: "" });
      setEstudios(estudios.data);
    };
    fetchData();

  }, []);

  //Objeto de valores iniciales a utilizar en formularios de Formik 
  const initialValues = {
    catPrecio: {
      id: id,
      search: "",
      clave: clave,
      nombre: nombre,
    },
    checked: listaPrecios,
    estudios: estudios
  }
  //Guardar o actualizar CatalogoPrecio o ListaPrecios en BD - Relacionar ListaPrecio con CatalogoPrecio
  function _onSubmit(values) {
    
  
    if (values.catPrecio.id) {

      API.updateCatPrecios(values.catPrecio).then(res => {

        if (values.checked) {

          values.checked.forEach(e => {
            e.catPrecioId = values.catPrecio.id
          })

          values.checked.forEach(value => {
            if (!value.id && value.activo) {
              API.addListaPrecio(value).then(res => { console.log(res); }).catch(err => console.log(err));
            } else {
              API.updateListaPrecio(value).then(res => { console.log(res); }).catch(err => console.log(err));
            }
          })
        }


      });

    }else {
      API.addCatPrecios(values.catPrecio)
      .then(res => { console.log(res); values.catPrecio.id = res.data.id }).catch(err => console.log(err));
     }

  }

  return (
    <>
      <ConfigNav2 />
      <Formik
        initialValues={initialValues}
        onSubmit={values => { _onSubmit(values); }}
      >
        {({ formik, values, setFieldValue }) => (

          <Form>
            <pre>{JSON.stringify(values.checked, null, 2)}</pre>
            <nav class="level">
              <div class="level-left">
                <p class="is-size-4 has-text-weight-bold" >Catalogo de Precios.</p>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <p>REGISTRO NUEVO</p>
              </div>

              <div class="level-right">
                <p class="level-item"><button class="button is-primary" type="submit" onClick={() => { setEditable(false) }}> Guardar </button></p>
                <p class="level-item">{component.data ? <button class="button is-primary" onClick={() => { setEditable(true) }}>MODIFY</button> : null}</p>
                <p class="level-item"><a class="button is-success" type="submit" onClick={() => { component.onClick("ListaPrecios") }}>CERRAR</a></p>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <p class="control">
                    <span class="tag is-light">Nombre</span>
                    <Field class="input" type="text" name="catPrecio.nombre" placeholder="Nombre" disabled={component.data && !editable} />
                  </p>
                </div>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <div class="level-item">
                  <p class="control">
                    <span class="tag is-light">Clave</span>
                    <Field class="input" type="text" name="catPrecio.clave" placeholder="Clave" disabled={component.data && !editable} />
                  </p>
                </div>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">

              </div>
              <div class="level-right">
                <p class="level-item"><button class="button is-primary" type="submit"> Guardar </button></p>
              </div>
            </nav>



            <FieldArray
              name="checked"
              render={arrayHelpers => (
                <table class="table">
                  <thead>
                    <tr>
                      <th>ID</th>
                      <th>Clave</th>
                      <th>Nombre</th>
                      <th>Area</th>
                      <th>Precio</th>
                      <th></th>
                    </tr>
                  </thead>
                  <tbody>
                    {estudios.map((estudio,index) => (
                      <tr key={estudio.id}>
                        <td>{estudio.id}</td>
                        <td>{estudio.clave}</td>
                        <td>{estudio.nombre}</td>
                        <td></td>
                        <td><Field name={`checked.${index}.precio`} type="number"/></td>
                        <td><Field
                          name={`checked.${index}.estudioId`}
                          type="checkbox"
                          value={`checked.${index}.estudioId`}
                          checked={values.checked && values.checked[index] && values.checked[index].activo ? values.checked[index].estudioId == estudio.id : false}
                          onChange={(event) => {
                            const value = event.target.checked ? estudio.id: estudio.id;
                            const value2 = event.target.checked ? true : false;
                            setFieldValue(`checked.${index}.estudioId`, value);
                            setFieldValue(`checked.${index}.activo`, value2);
                          }} /></td>
                        
                      </tr>
                     ))
                    }
                  </tbody>
                </table>
                
              )}
            />

          </Form>
        )}
      </Formik>
    </>
  )
}

export default NuevoCatalogoPrecio;
