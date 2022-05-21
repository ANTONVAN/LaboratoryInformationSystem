import React, { useContext, useState } from 'react';
import ComponentContext from "../../utils/ComponentContext";

function ConfigNav() {

  const component = useContext(ComponentContext);


  return (
    <>
      <nav class="breadcrumb" aria-label="breadcrumbs">
        <ul>
          <li><a href="#" onClick={() => { component.onClick("Departments") }}><strong>Catalogo de procedencias</strong></a></li>
          <li><a href="#" onClick={() => { component.onClick("Companias") }}><strong>Catalogo de compañías</strong></a></li>
          <li><a href="#" onClick={() => { component.onClick("ListaPrecios") }}><strong>Lista de precios</strong></a></li>
        </ul>
      </nav>
    </>
  );
} export default ConfigNav;
