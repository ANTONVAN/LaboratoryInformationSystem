import React, {useContext} from "react";

import {useFormik} from "formik";
import API from "../../utils/API"
import ComponentContext from "../../utils/ComponentContext";
import DepartmentsContext from "../../utils/DepartmentsContext";
import ConfigNav from "../../components/ConfigNav";
import Table from "../../components/Table";

const Departments = (props) => {
  
  const component = useContext(ComponentContext);
  const departments = useContext(DepartmentsContext);

  const formik = useFormik({
      initialValues: {
      search: "",
      clave:"",
      nombre:"",
    },
    onSubmit: values => {
      console.log(values);
      API.getDepartments(values) 
          .then(res => {
           console.log(res.data);
          departments.onClick(res.data)  
       })
      .catch(err => console.log(err));
    }
  })

  return (
    <>
      <ConfigNav />
      <nav class="level">
        <div class="level-left">
          <p class="is-size-4 has-text-weight-bold" >Catalogo de Departamentos.</p>
        </div>
      </nav>
      <nav class="level">
        <div class="level-left">
          <div class="level-item">
            <div class="field has-addons">
              <p class="control">
                <input class="input" type="text" placeholder="Buscar un departamento" onChange={formik.handleChange} value={formik.values.nombre} id="nombre" name="nombre" />
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
          <p class="level-item"><a class="button is-success" onClick={() => {component.onClick("NewDepartment")}}>NUEVO</a></p>
        </div>
      </nav>

      <Table class="level" data={departments.data} columns={departments.columns} component={component} edit="NewDepartment"/>
    </>
  );
}


export default Departments;