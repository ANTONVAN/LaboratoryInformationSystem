import React, { useState, useEffect, useContext } from "react";
import { useFormik, FieldArray, Form, Field, Formik } from "formik";
import API from "../../utils/API"

import ComponentContext from "../../utils/ComponentContext";
import ConfigNav4 from "../../components/ConfigNav4";

const NuevaSucursal = () => {
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
    var ciudad = component.data.ciudad;
    var estado = component.data.estado;
    var correo = component.data.correo;
    var celular = component.data.celular;
    var activo = component.data.activo;
    var numeroExterior = component.data.numeroExterior;
    var calle = component.data.calle;
    var colonia = component.data.colonia;
    var min = component.data.min;
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
    sucursal: {

      search: "",
      id : id,                      
      nombre: nombre,
      clave: clave,
      CP: CP,
      telefono: telefono,
      ciudad: ciudad,
      estado: estado,
      correo: correo,
      celular: celular,
      activo: activo,
      numeroExterior: numeroExterior,
      calle: calle,
      colonia: colonia,
      min: min,
      activo: activo,

    }
  }
  //Guardar o actualizar estudio en BD - Relacionar estudio con parametro
  function _onSubmit(values) {

    if (values.sucursal.id) {
      console.log(values)
      API.updateSucursal(values.sucursal).then(res => { }).catch(err => console.log(err));
    } else {
      API.addSucursal(values.sucursal).then(res => {
        console.log(res);
        setEditable(false);
        values.sucursal.id = res.data.id
        var data = values.sucursal;
        component.onClick("NuevaSucursal", { data });
      }).catch(err => console.log(err));
    }
  }

  return (
    <>
      <ConfigNav4 />
      <Formik
        initialValues={initialValues}
        onSubmit={values => { _onSubmit(values) }}
        render={({ values, setFieldValue }) => (

          <Form>

            <nav class="level">
              <div class="level-left">
                <p class="is-size-4 has-text-weight-bold" >Catalogo de Sucursales.</p>
              </div>
            </nav>

            <nav class="level">
              <div class="level-left">
                <p>REGISTRO NUEVO</p>
              </div>

              <div class="level-right">
                <p class="level-item"><button class="button is-primary" onClick={() => { setEditable(false) }} type="submit"> Guardar </button></p>
                <p class="level-item">{component.data ? <button class="button is-primary" onClick={() => { setEditable(true) }}>MODIFY</button> : null}</p>
                <p class="level-item"><a class="button is-success" type="submit" onClick={() => { component.onClick("Sucursales") }}>CERRAR</a></p>
              </div>
            </nav>

            <div class="columns">

              <div class="column is-one-quarter">
                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Nombre</span>
                        <Field disabled={component.data && !editable} class="input" type="text" name="sucursal.nombre" placeholder="Nombre" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Clave</span>
                        <Field class="input" disabled={component.data && !editable} type="text" name="sucursal.clave" placeholder="Clave" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Valor mínimo</span>
                        <Field class="input" disabled={component.data && !editable} type="number" name="sucursal.min" placeholder="Min" />
                      </p>
                    </div>
                  </div>
                </nav>


                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Valor máximo</span>
                        <Field class="input" disabled={component.data && !editable} type="number" name="sucursal.max" placeholder="Max" />
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
                        <span class="tag is-light">Calle</span>
                        <Field class="input" disabled={component.data && !editable} type="text" name="sucursal.calle" placeholder="Calle" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Numero Exterior</span>
                        <Field class="input" disabled={component.data && !editable} type="text" name="sucursal.numeroExterior" placeholder="Numero Exterior" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Colonia</span>
                        <Field class="input" disabled={component.data && !editable} type="text" name="sucursal.colonia" placeholder="Colonia" />
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
                        <Field class="input" disabled={component.data && !editable} type="text" name="sucursal.ciudad" placeholder="Ciudad" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Estado</span>
                        <Field class="input" disabled={component.data && !editable} type="text" name="sucursal.estado" placeholder="Estado" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">CP</span>
                        <Field class="input" disabled={component.data && !editable} type="number" name="sucursal.CP" placeholder="CP" />
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
                        <Field class="input" disabled={component.data && !editable} type="number" name="sucursal.telefono" placeholder="Telefono" />
                      </p>
                    </div>
                  </div>
                </nav>

                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Celular</span>
                        <Field class="input" disabled={component.data && !editable} type="number" name="sucursal.celular" placeholder="Celular" />
                      </p>
                    </div>
                  </div>
                </nav>


                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <p class="control">
                        <span class="tag is-light">Correo electrónico</span>
                        <Field class="input" disabled={component.data && !editable} type="email" name="sucursal.correo" placeholder="Correo" />
                      </p>
                    </div>
                  </div>
                </nav>




                {/*                <nav class="level">
                  <div class="level-left">
                    <div class="level-item">
                      <div class="select">
                        <Field component="select" onChange={(e) => { setFieldValue('sucursal.catPrecioId', parseInt(e.target.value)); }}
                          name="sucursal.catPrecioId" id="sucursal.catPrecioId" class="form-control">
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

export default NuevaSucursal;
