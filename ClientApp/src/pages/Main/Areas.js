import React, {useState, useContext } from "react";
import {useFormik} from "formik";
import API from "../../utils/API"
import ConfigNav from "../../components/ConfigNav";
import Table from "../../components/Table";
import ComponentContext from "../../utils/ComponentContext";
import AreasContext from "../../utils/AreasContext";


//
const Areas = (props) => {
    
  const areas = useContext(AreasContext);
  const component = useContext(ComponentContext);
  
  
  const formik = useFormik({
    initialValues: {
      search: "",
      clave:"",
      nombre:"",
    },

    onSubmit: values => {  
      API.getAreas(values) 
     .then(res => {
        areas.onClick(res.data);
      })
      .catch(err => console.log(err));
    }

  })

  return (
    <>
      <ConfigNav />
      <nav class="level">
        <div class="level-left">
          <p class="is-size-4 has-text-weight-bold" >Catalogo de Areas.</p>
        </div>
      </nav>

      <nav class="level">
        <div class="level-left">
          <div class="level-item">
            <div class="field has-addons">
              <p class="control">
                <input class="input" type="text" placeholder="Buscar un area" onChange={formik.handleChange} value={formik.values.nombre} id="nombre" name="nombre" />
              </p>
              <p class="control">
                <button class="button" onClick={formik.handleSubmit}>
                  BUSCAR
                </button>
              </p>
            </div>
          </div>
        </div>

        <div class="level-right">
          <p class="level-item"><a class="button is-success" onClick={() => { component.onClick("NewArea") }}>NUEVO</a></p>
        </div>
      </nav>

      <Table data={areas.data} columns={areas.columns} component={component} edit="NewArea"/>

    </>
  );
   
}

export default Areas;