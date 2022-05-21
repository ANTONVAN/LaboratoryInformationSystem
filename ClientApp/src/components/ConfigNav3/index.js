import React, { useContext, useState } from 'react';
import ComponentContext from "../../utils/ComponentContext";

function ConfigNav() {

  const component = useContext(ComponentContext);


  return (
    <>
      <nav class="breadcrumb" aria-label="breadcrumbs">
        <ul>
          <li><a href="#" onClick={() => { component.onClick("Medicos") }}><strong>Medicos</strong></a></li>
        </ul>
      </nav>
    </>
  );
} export default ConfigNav;
