<template>
  <div class="row">
    <div class="col-lg-8 offset-lg-2">
      <div class="table-responsive">
        <table class="table table-bordered table-hover">
          <thead>
            <tr>
              <th>#</th>
              <th>Nombre</th>
              <th>Detalles</th>
              <th>Páginas</th>
              <th>Totales</th>
              <th>Creador</th>
              <th>Acciones</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(Libreria) in Librerias" :key="Libreria.id">
              <td>{{ Libreria.id}}</td>
              <td>{{ Libreria.nombre }}</td>
              <td>{{ Libreria.detalles }}</td>
              <td>{{ Libreria.paginas }}</td>
              <td>{{ Libreria.totales }}</td>
              <td>{{ Libreria.creador }}</td>
              <td>
                <router-link :to="{ path: 'edit/' + Libreria.id }" class="btn btn-warning">
                  <i class="fa-solid fa-edit"></i>
                </router-link>
                <button class="btn btn-danger" v-on:click="eliminar(Libreria.id, Libreria.nombre)">
                  <i class="fa-solid fa-trash"></i>
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>

  
</template>

<script>
import axios from 'axios';
import {confirmar} from '../funciones';


export default {
  data() {
    return {
      Librerias: []
    };
  },
  mounted() {
    this.getLibrerias();
  },
  methods: {
    getLibrerias() {
      axios.get('https://www.crudapi.somee.com/api/Libreria').then(response => {
        //console.log(response.data);
        this.Librerias = response.data.resultado;
      });
    },

    eliminar(id,nombre){

      confirmar(id,nombre);


    }
  }
}
</script>