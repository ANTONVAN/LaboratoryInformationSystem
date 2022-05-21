import React, { useState } from "react";

import Navbar from './components/Navbar';
import Menu from './components/Menu';
import NavbarContext from './utils/NavbarContext';
import ComponentContext from './utils/ComponentContext';

import Departments from './pages/Main/Departments';
import NewDepartment from './pages/Main/NewDepartment';
import DepartmentsContext from './utils/DepartmentsContext';

import Areas from './pages/Main/Areas';
import NewArea from './pages/Main/NewArea';
import AreasContext from './utils/AreasContext';

import Parameters from './pages/Main/Parameters';
import NewParameter from './pages/Main/NewParameter';
import ParametersContext from './utils/ParametersContext';

import Indicaciones from "./pages/Main/Indicaciones";
import NuevaIndicacion from "./pages/Main/NuevaIndicacion";
import IndicacionesContext from "./utils/IndicacionesContext";

import Metodos from './pages/Main/Metodos';
import NuevoMetodo from './pages/Main/NuevoMetodo';
import MetodosContext from './utils/MetodosContext';

import Maquiladores from './pages/Main/Maquiladores';
import NuevoMaquilador from './pages/Main/NuevoMaquilador';
import MaquiladoresContext from './utils/MaquiladoresContext';

import Etiquetas from './pages/Main/Etiquetas';
import NuevaEtiqueta from './pages/Main/NuevaEtiqueta';
import EtiquetasContext from './utils/EtiquetasContext';

import Estudios from './pages/Main/Estudios';
import NuevoEstudio from './pages/Main/NuevoEstudio';
import EstudiosContext from './utils/EstudiosContext';

import Companias from './pages/Main/Companias';
import NuevaCompania from './pages/Main/NuevaCompania';
import CompaniasContext from './utils/CompaniasContext';

import CatalogoPrecios from './pages/Main/CatalogoPrecios';
import NuevoCatalogoPrecio from './pages/Main/NuevoCatalogoPrecio';
import CatalogoPreciosContext from './utils/CatalogoPreciosContext';

import Paquetes from './pages/Main/Paquetes';
import NuevoPaquete from './pages/Main/NuevoPaquete';
import PaquetesContext from './utils/PaquetesContext';

import Medicos from './pages/Main/Medicos';
import NuevoMedico from './pages/Main/NuevoMedico';
import MedicosContext from './utils/MedicosContext';

import Sucursales from './pages/Main/Sucursales';
import NuevaSucursal from './pages/Main/NuevaSucursal';
import SucursalesContext from './utils/SucursalesContext';

import Reactivos from './pages/Main/Reactivos';
import NuevoReactivo from './pages/Main/NuevoReactivo';
import ReactivosContext from './utils/ReactivosContext';

import Pacientes from './pages/Recepcion/Pacientes';
import NuevoPaciente from './pages/Recepcion/NuevoPaciente';
import PacientesContext from './utils/PacientesContext';

import Solicitudes from './pages/Recepcion/Solicitudes';
import NuevaSolicitud from './pages/Recepcion/NuevaSolicitud';
import SolicitudesContext from './utils/SolicitudesContext';

import Content from './components/Content';


function App(props) {


  const [component, setComponent]=useState({
    name:"",
    data:"",
    onClick:(name,data)=>{  
      setComponent({...component,name,data});
    }
  });

  const [navbar, setNavbar]=useState({
    name:"",
    onClick:(name)=>{
      setNavbar({...navbar,name});
    }
  });

  const [departments,setDepartments]=useState({
    data: [],
      columns: [
      {title: "ID", field: "id"},
      {title: "Clave", field: "clave"},
      {title: "Nombre", field: "nombre"},
      ],
    onClick:(data)=>{
      setDepartments({...departments,data});  
    }
  });


  const [etiquetas, setEtiquetas] = useState({
      data: [],
      columns: [
          { title: "ID", field: "id" },
          { title: "Clave", field: "clave" },
          { title: "Nombre", field: "nombre" },
      ],
      onClick: (data) => {
          setEtiquetas({ ...etiquetas, data });
      }
  });


  const [indiaciones, setIndicaciones] = useState({
      data: [],
      columns: [
          { title: "ID", field: "id" },
          { title: "Clave", field: "clave" },
          { title: "Nombre", field: "nombre" },
      ],
      onClick: (data) => {
          setIndicaciones({ ...indiaciones, data });
      }
  });


  const [metodos, setMetodos] = useState({
      data: [],
      columns: [
          { title: "ID", field: "id" },
          { title: "Clave", field: "clave" },
          { title: "Nombre", field: "nombre" },
      ],
      onClick: (data) => {
          setMetodos({ ...metodos, data });
      }
  });


  const [maquiladores, setMaquiladores] = useState({
      data: [],
      columns: [
          { title: "ID", field: "id" },
          { title: "Clave", field: "clave" },
          { title: "Nombre", field: "nombre" },
      ],
      onClick: (data) => {
          setMaquiladores({ ...maquiladores, data });
      }
  });



  const [areas, setAreas] = useState({
      data: [],
      columns: [
          { title: "ID", field: "id" },
          { title: "Clave", field: "clave" },
          { title: "Nombre", field: "nombre" },
          { title: "Departamento", field: "departamento.nombre" },
      ],
      onClick: (data) => {
          setAreas({ ...areas, data });
      }
  });

  const [parameters, setParameters]=useState({
    data: [],
    columns: [
        {title: "ID", field: "id"},
        {title: "Clave", field: "clave"},
        {title: "Nombre", field: "nombre"},
        {title: "Unidades", field: "unidades"},
        {title: "Tipo", field: "valorTipo.nombre"},
      ],
    onClick:(data)=>{
      setParameters({...parameters,data});  
    }
  });


  const [estudios, setEstudios] = useState({
      data: [],
      columns: [
          { title: "ID", field: "id" },
          { title: "Clave", field: "clave" },
          { title: "Nombre", field: "nombre" },
          { title: "Area", field: "area.nombre" },
          { title: "Metodo", field: "metodo.nombre" },
          { title: "Maquilador", field: "maquilador.nombre" }
      ],
      onClick: (data) => {
          setEstudios({ ...estudios, data });
      }
  });


  const [companias, setCompanias] = useState({
    data: [],
    columns: [
      { title: "ID", field: "id" },
      { title: "Clave", field: "clave" },
      { title: "Nombre", field: "nombre" },
      { title: "RFC", field: "rfc" },
      { title: "CP", field: "cp" },
      { title: "Telefono", field: "telefono" },
      { title: "RazonSocial", field: "razonSocial" },
      { title: "Email", field: "email" },
      { title: "Status", field: "status" },
      { title: "Catalogo Precio", field: "catPrecioId" }
    ],
    onClick: (data) => {
      setCompanias({ ...companias, data });
    }
  });

  const [catalogoPrecios, setCatalogoPrecios] = useState({
    data: [],
    columns: [
      { title: "ID", field: "id" },
      { title: "Clave", field: "clave" },
      { title: "Nombre", field: "nombre" }
    ],
    onClick: (data) => {
      console.log(data)
      setCatalogoPrecios({ ...catalogoPrecios, data });
    }
  });

  const [paquetes, setPaquetes] = useState({
    data: [],
    columns: [
      { title: "ID", field: "id" },
      { title: "Clave", field: "clave" },
      { title: "Nombre", field: "nombre" }
    ],
    onClick: (data) => {
      console.log(data)
      setPaquetes({ ...paquetes, data });
    }
  });

  const [reactivos, setReactivos] = useState({
    data: [],
    columns: [
      { title: "ID", field: "id" },
      { title: "Clave", field: "clave" },
      { title: "Nombre", field: "nombre" },
      { title: "Activo", field: "activo" }
    ],
    onClick: (data) => {
      console.log(data)
      setReactivos({ ...reactivos, data });
    }
  });

  const [pacientes, setPacientes] = useState({
    data: [],
    columns: [
      { title: "ID", field: "id" },
      { title: "Nombre", field: "nombre" },
      { title: "Apellidos", field: "apellidos" },
      { title: "Sexo", field: "sexo" },
      { title: "Direccion", field: "direccion" },
      { title: "Edad", field: "edad" },
      { title: "FechaNacimiento", field: "fechaNacimiento" },
      { title: "Celular", field: "celular" },
      { title: "Telefono", field: "telefono" },
      { title: "CP", field: "cp" }

    ],
    onClick: (data) => {
      console.log(data)
      setPacientes({ ...pacientes, data });
    }
  });

  const [solicitudes, setSolicitudes] = useState({
    data: [],
    columns: [
      { title: "ID", field: "id" },
      { title: "Compania", field: "compania" },
      { title: "Importe", field: "importe" },
      { title: "Descuento", field: "descuento" },
      { title: "Total", field: "total" },
      { title: "Saldo", field: "saldo" }

    ],
    onClick: (data) => {
      console.log(data)
      setSolicitudes({ ...solicitudes, data });
    }
  });

  const [medicos, setMedicos] = useState({
    data: [],
    columns: [
      { title: "ID", field: "id" },
      { title: "Clave", field: "clave" },
      { title: "Nombre", field: "nombre" },
      { title: "Apellidos", field: "apellidos" },
      { title: "Especialidad", field: "especialidad" },
      { title: "CP", field: "cp" },
      { title: "Ciudad", field: "ciudad" },
      { title: "Estado", field: "estado" },
      { title: "Correo", field: "correo" },
      { title: "Telefono", field: "telefono" },
      { title: "Celular", field: "celular" },
      { title: "Ciudad", field: "ciudad" },
      { title: "Activo", field: "activo" },

    ],
    onClick: (data) => {
      console.log(data)
      setMedicos({ ...medicos, data });
    }
  });


  const [sucursales, setSucursales] = useState({
    data: [],
    columns: [
      { title: "ID", field: "id" },
      { title: "Clave", field: "clave" },
      { title: "Nombre", field: "nombre" },
      { title: "CP", field: "cp" },
      { title: "Estado", field: "estado" },
      { title: "Ciudad", field: "ciudad" },
      { title: "NumeroExterior", field: "numeroexterior" },
      { title: "Calle", field: "calle" },
      { title: "Colonia", field: "colonia" },
      { title: "Correo", field: "correo" },
      { title: "Min", field: "min" },
      { title: "Max", field: "max" },
      { title: "Activo", field: "activo" },

    ],
    onClick: (data) => {
      console.log(data)
      setSucursales({ ...sucursales, data });
    }
  });
  
const renderComponent=()=>{
   switch(component.name){
    case "Estudios":
      return <Departments />
      break;
    case "Departments":
      return <Departments />
      break;
    case "NewDepartment":
      return <NewDepartment />
      break;
    case "Areas":
      return <Areas />
      break;
    case "NewArea":
      return <NewArea />
      break; 
    case "Parameters":
      return <Parameters />
      break;
    case "NewParameter":
      return <NewParameter />
      break;
    case "Indicaciones":
        return <Indicaciones />
        break;
    case "NuevaIndicacion":
        return <NuevaIndicacion />
        break;
    case "Etiquetas":
        return <Etiquetas />
        break;
    case "NuevaEtiqueta":
        return <NuevaEtiqueta />
        break;
    case "Metodos":
        return <Metodos />
        break;
    case "NuevoMetodo":
        return <NuevoMetodo />
        break;
    case "Maquiladores":
        return <Maquiladores />
        break;
    case "NuevoMaquilador":
        return <NuevoMaquilador />
           break;
    case "catEstudios":
        return <Estudios />
        break;
    case "NuevoEstudio":
        return <NuevoEstudio />
       break;
    case "Companias":
      return <Companias />
      break;
    case "NuevaCompania":
      return <NuevaCompania />
       break;
    case "ListaPrecios":
      return <CatalogoPrecios />
       break;
    case "NuevoCatalogoPrecio":
      return <NuevoCatalogoPrecio />
       break;
     case "Pacientes":
       return <Pacientes />
       break;
     case "NuevoPaciente":
       return <NuevoPaciente />
       break;
     case "Paquetes":
       return <Paquetes />
       break;
     case "NuevoPaquete":
       return <NuevoPaquete />
       break;
     case "Admision":
       return <Medicos/>
       break;
     case "Medicos":
       return <Medicos />
       break;
     case "NuevoMedico":
       return <NuevoMedico />
       break;
     case "Sistema":
       return <Sucursales />
       break;
     case "Sucursales":
       return <Sucursales />
       break;
     case "NuevaSucursal":
       return <NuevaSucursal />
       break;
     case "Reactivos":
       return <Reactivos />
       break;
     case "NuevoReactivo":
       return <NuevoReactivo />
       break;
     case "Solicitudes":
       return <Solicitudes />
       break;
     case "NuevaSolicitud":
       return <NuevaSolicitud />
       break;

    default:
       return <Content />
    break;
   }
}

  return (
    <>
    <SolicitudesContext.Provider value={solicitudes}>
    <PacientesContext.Provider value={pacientes}>
    <ReactivosContext.Provider value={reactivos}>
    <SucursalesContext.Provider value={sucursales}>
    <CompaniasContext.Provider value={companias}>
    <AreasContext.Provider value={areas}>
    <DepartmentsContext.Provider value={departments}>
    <ParametersContext.Provider value={parameters}>
    <EtiquetasContext.Provider value={etiquetas}>                     
    <MaquiladoresContext.Provider value={maquiladores}>
    <IndicacionesContext.Provider value={indiaciones}>
    <MetodosContext.Provider value={metodos}>
    <EstudiosContext.Provider value={estudios}>
    <MedicosContext.Provider value={medicos}>
    <PaquetesContext.Provider value={paquetes}>
    <CatalogoPreciosContext.Provider value={catalogoPrecios}>
    <NavbarContext.Provider value={navbar}>
    <ComponentContext.Provider value={component}>
    
        <div class="container">
          <Navbar />
          <div class="columns"> 
              <div class="column">
                  <Menu />
              </div>
              <div class="column is-four-fifths">
                  {renderComponent()}
              </div>
          </div>
        </div>
              
          
    </ComponentContext.Provider>
    </NavbarContext.Provider>
    </CatalogoPreciosContext.Provider>
    </PaquetesContext.Provider>
    </MedicosContext.Provider>
    </EstudiosContext.Provider>
    </MetodosContext.Provider>
    </IndicacionesContext.Provider>
    </MaquiladoresContext.Provider>
    </EtiquetasContext.Provider>
    </ParametersContext.Provider>
    </DepartmentsContext.Provider>
    </AreasContext.Provider>
    </CompaniasContext.Provider>
    </SucursalesContext.Provider>
    </ReactivosContext.Provider>
    </PacientesContext.Provider>
    </SolicitudesContext.Provider>

    </>
  );
}

export default App;



