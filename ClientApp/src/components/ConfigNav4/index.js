import React, { useContext, useState } from 'react';
import ComponentContext from "../../utils/ComponentContext";

function ConfigNav4() {

  const component = useContext(ComponentContext);


  return (
    <>
      <nav class="breadcrumb" aria-label="breadcrumbs">
        <ul>
          <li><a href="#" onClick={() => { component.onClick("Sucursales") }}><strong>Usuarios</strong></a></li>
          <li><a href="#" onClick={() => { component.onClick("Sucursales") }}><strong>Roles</strong></a></li>
          <li><a href="#" onClick={() => { component.onClick("Sucursales") }}><strong>Sucursales</strong></a></li>
        </ul>
      </nav>
    </>
  );
} export default ConfigNav4;
