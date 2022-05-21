import axios from "axios";

export default {  

//DEPARTAMENTOS
  addDepartment: function (data) {
    return axios.post("/api/Departamento/Create", data.departamento);
  },

  getDepartments: function (data) {
    var id = data.id;
    var clave = data.clave;
    var nombre = data.nombre;      
    return axios.get(`/api/Departamento/Search?prDepartamento=${nombre}`);
  },

  updateDepartment: function ( data ) { 
    return axios.put(`/api/Departamento/Update`,data.departamento);
  },


//AREAS
  addArea: function (data) {
    return axios.post("/api/Area/Create", data.area);
  },

  getAreas: function (data) {
    var id = data.id;
    var clave = data.clave;
    var nombre = data.nombre;
    return axios.get(`/api/Area/Search?prArea=${nombre}`);
  },

  updateArea: function ( data ) { 
    return axios.put(`/api/Area/Update`,data.area);
  },


//METODOS
  addMetodo: function (data) {
    return axios.post("/api/Metodo/Create", data.metodo);
  },

  getMetodos: function (data) {
    var clave = data.clave;
    var nombre = data.nombre;
    return axios.get(`/api/Metodo/Search?prMetodo=${nombre}`);
  },

  updateMetodo: function (data) {
    return axios.put(`/api/Metodo/Update`, data.metodo);
  },

//MAQUILADORES
  addMaquilador: function (data) {
    return axios.post("/api/Maquilador/Create", data.maquilador);
  },

  getMaquiladores: function (data) {
    var _id = data._id;
    var clave = data.clave;
    var nombre = data.nombre;
    return axios.get(`/api/Maquilador/Search?prMaquilador=${nombre}`);
  },

  updateMaquilador: function (data) {
      return axios.put(`/api/Maquilador/Update`, data.maquilador);
  },

//INDICACIONES
  addIndicacion: function (data) {
    return axios.post("/api/Indicaciones/Create", data.indicacion);
  },

  getIndicaciones: function (data) {
    var _id = data._id;
    var clave = data.clave;
    var nombre = data.nombre;
    return axios.get(`/api/Indicaciones/Search?prIndicacion=${nombre}`);
  },

  updateIndicacion: function (data) {
    return axios.put(`/api/Indicaciones/Update`, data.indicacion);
  },

//ETIQUETAS
  addEtiqueta: function (data) {
    return axios.post("/api/Etiqueta/Create", data.etiqueta);
  },

  getEtiquetas: function (data) {
    var _id = data._id;
    var clave = data.clave;
    var nombre = data.nombre;
    return axios.get(`/api/Etiqueta/Search?prEtiqueta=${nombre}`);
  },

  updateEtiqueta: function (data) {
    return axios.put(`/api/Etiqueta/Update`, data.etiqueta);
  },


//PARAMETROS
  addParameter: function ( data ) {
    return axios.post("/api/Parametro/Create", data.parameter);
  },

  getParameters: function (data) {
    var id = data.id;
    var clave = data.clave;
    var nombre = data.nombre;
    return axios.get(`/api/Parametro/Search?prParametro=${nombre}`);
  },

  getParametersByKey: function (data) {
    return axios.get(`/api/Parametro/SearchByKey?prParametro=${data}`);
  },

  updateParameter: function ( data ) { 
    console.log(data);
    return axios.put(`/api/Parametro/Update`,data.parameter);
   },



//ESTUDIOS
  addEstudio: function (data) {
        console.log(data)
        return axios.post("/api/Estudio/Create", data);
  },

  getEstudios: function (data) {
      var id = data.id;
      var clave = data.clave;
      var nombre = data.nombre;
      return axios.get(`/api/Estudio/Search?prEstudio=${nombre}`);
  },

  getEstudioByKey: function (data) {
    console.log(data)
    return axios.get(`/api/Estudio/SearchByKey?prEstudio=${data}`);
  },

  updateEstudio: function (data) {
      console.log(data);
      return axios.put(`/api/Estudio/Update`, data);
  },

  //PAQUETES
  addPaquete: function (data) {
    console.log(data)
    return axios.post("/api/Paquete/Create", data);
  },

  getPaquetes: function (data) {
    var id = data.id;
    var clave = data.clave;
    var nombre = data.nombre;
    return axios.get(`/api/Paquete/Search?prEstudio=${nombre}`);
  },

  updatePaquete: function (data) {
    console.log(data);
    return axios.put(`/api/Paquete/Update`, data);
  },


//VALOR TIPOS
  getValorTipos: function ( data ) {
      return axios.get(`/api/ValorTipo/Search`);
    },

//VALOR REFERENCIAS
  addValorReferencias: function (data) {
      console.log(data);
      return axios.post("/api/ValorReferencia/Create", data)
  },

  updateValorReferencias: function (data) {
    console.log(data);
    return axios.put("./api/ValorReferencia/Update", data);
  },

//COMPANIAS
  getCompanias: function (data) {
    var id = data.id;
    var clave = data.clave;
    var nombre = data.nombre;
    return axios.get(`/api/Compania/Search?prCompania=${nombre}`);
  },

  getCompaniaByKey: function (data) {
    return axios.get(`/api/Compania/SearchByKey?prCompania=${data}`);
  },

  addCompania: function (data) {
    console.log(data)
    return axios.post("/api/Compania/Create", data);
  },

  updateCompania: function (data) {
    console.log(data)
    return axios.put("/api/Compania/Update", data);
  },

//MEDICOS
  getMedicos: function (data) {
    var id = data.id;
    var clave = data.clave;
    var nombre = data.nombre;
    return axios.get(`/api/Medico/Search?prMedico=${nombre}`);
  },

  getMedicoByKey: function (data) {
    return axios.get(`/api/Medico/SearchByKey?prMedico=${data}`);
  },

  addMedico: function (data) {
    console.log(data)
    return axios.post("/api/Medico/Create", data);
  },

  updateMedico: function (data) {
    console.log(data)
    return axios.put("/api/Medico/Update", data);
  },


//SUCURSALES
  getSucursales: function (data) {
    var id = data.id;
    var clave = data.clave;
    var nombre = data.nombre;
    return axios.get(`/api/Sucursal/Search?prSucursal=${nombre}`);
  },

  addSucursal: function (data) {
    console.log(data)
    return axios.post("/api/Sucursal/Create", data);
  },

  updateSucursal: function (data) {
    console.log(data)
    return axios.put("/api/Sucursal/Update", data);
  },

//REACTIVOS
  getReactivos: function (data) {
    var id = data.id;
    var clave = data.clave;
    var nombre = data.nombre;
    return axios.get(`/api/Reactivo/Search?prReactivo=${nombre}`);
  },

  addReactivo: function (data) {
    console.log(data)
    return axios.post("/api/Reactivo/Create", data);
  },

  updateReactivo: function (data) {
    console.log(data)
    return axios.put("/api/Reactivo/Update", data);
  },

//CAT PRECIOS
  getCatPrecios: function (data) {
    var id = data.id;
    var clave = data.clave;
    var nombre = data.nombre;
    return axios.get(`/api/CatPrecio/Search?prCatPrecio=${nombre}`);
	},

  addCatPrecios: function (data) {
    console.log(data)
    return axios.post("/api/CatPrecio/Create", data);
  },

  updateCatPrecios: function (data) {
    console.log(data);
    return axios.put('/api/CatPrecio/Update', data);
  },


//LISTA PRECIO
  addListaPrecio: function (data) {
    console.log(data)
    return axios.post("/api/ListaPrecio/Create", data);
  },

  getListaPrecio: function (estudioId,catPrecioId) {
    return axios.get(`/api/ListaPrecio/Search?prEstudioId=${estudioId}&prCatPrecioId=${catPrecioId}`);
  },

  updateListaPrecio: function (data) {
    console.log(data);
    return axios.put('/api/ListaPrecio/Update', data);
  },


 //PACIENTES
  addPaciente: function (data) {
    console.log(data);
    return axios.post('/api/Paciente/Create', data)
  },


  getPaciente: function (data) {
    var id = data.id;
    var clave = data.clave;
    var nombre = data.nombre;
    return axios.get(`/api/Paciente/Search?prPaciente=${nombre}`);
  },

//SOLICIUDES
  addSolicitud: function (data) {
    console.log(data);
    return axios.post('/api/Solicitud/Create', data)
  },


  getSolicitud: function (data) {
    var id = data.id;
    return axios.get(`/api/Solicitud/Search?prSolicitud=${id}`);
  },









};
