import React, { useContext, useState } from 'react';
import ComponentContext from "../../utils/ComponentContext";

function ConfigNav() {
  
  const component = useContext(ComponentContext);
  

  return (
    <>
      <nav class="breadcrumb" aria-label="breadcrumbs">
        <ul>
          <li><a href="#" onClick={() => { component.onClick("Departments") }}><strong>Departamentos</strong></a></li>
          <li><a href="#" onClick={() => { component.onClick("Areas") }}><strong>Areas</strong></a></li>
          <li><a href="#" onClick={() => { component.onClick("Parameters") }}><strong>Parametros</strong></a></li>
          <li><a href="#" onClick={() => { component.onClick("Indicaciones") }}><strong>Indicaciones</strong></a></li>
          <li><a href="#" onClick={() => { component.onClick("Etiquetas") }}><strong>Etiquetas</strong></a></li>
          <li><a href="#" onClick={() => { component.onClick("Maquiladores") }}><strong>Maquiladores</strong></a></li>
          <li><a href="#" onClick={() => { component.onClick("Metodos") }}><strong>Metodos</strong></a></li>
          <li><a href="#" onClick={() => { component.onClick("catEstudios") }}><strong>Estudios</strong></a></li>
          <li><a href="#" onClick={() => { component.onClick("Paquetes") }}><strong>Paquetes</strong></a></li>
          <li><a href="#" onClick={() => { component.onClick("Reactivos") }}><strong>Reactivos</strong></a></li>
        </ul>
      </nav>
    </>
  );
} export default ConfigNav;
