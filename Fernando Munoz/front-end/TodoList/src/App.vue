<template>
  <div class="container">

    <div class="cajaTodo">
      <!-- --- CABEZERA E ICONO -->
      <div class="cabezera">
        <img class="icono" src="C:\Users\munoz\Desktop\practica\public/comprobado.png">
        <h1>Todo List</h1>
      </div>

      <!-- CUERPO - FORMULARIO -->
      <div class="cuerpo">
        <div class="formulario">
          <div class="input-group">
            <input class="form-control" type="text" v-model="this.titulo">
            <button @click="agregarTarea()" class="btn btn-success">Añadir</button>
          </div>
        </div>
      </div>

      <!-- CUERPO - TABLA -->
      <div class="tabla">
        <h2>Tareas pendientes</h2>
        <ul>
          <li v-for="tarea in listaTareas" :key="tarea.id">
            <button @click="editarTarea(tarea)" type="button" class="btn btn-primary" data-bs-toggle="modal"
              data-bs-target="#staticBackdrop">
              Editar
            </button>
            <p>{{ tarea.titulo }}</p>
            <button class="btn btn-danger" @click="eliminarTarea(tarea.id)">Delete</button>
          </li>
        </ul>
      </div>
    </div>
  </div>

  <!-- Modal -->
  <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1"
    aria-labelledby="staticBackdropLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="staticBackdropLabel">Editar Modal</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form>
            <div class="mb-3">
              <label for="recipient-name" class="col-form-label">Tarea:</label>
              <input type="hidden" v-model="mostrarEditar.id">
              <input type="text" class="form-control" id="recipient-name" v-model="tituloTemporal">
            </div>

          </form>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
          <button @click="guardarTareaEditada()" type="button" class="btn btn-success">Guardar</button>
        </div>
      </div>
    </div>
  </div>

</template>

<script>
import { ref, reactive, computed } from 'vue';
import axios from 'axios';

export default {
  data() {
    return {
      // reactividad de la DataTable
      // edición
      mostrarEditar: [],
      tituloTemporal: '',
      // arreglo que usa el bucle para mostrar las tareas
      listaTareas: reactive([]),
      // datos para hacer el post de la tarea
      titulo: '',
      detalle: 'pruebaVue3',
      usuarioCreador: 1,
      fechaCreacion: '2024-04-29T20:16:30.851Z',
      fechaActualizacion: '2024-04-29T20:16:30.851Z',
      fechaEliminacion: '2024-04-29T20:16:30.851Z'

    }
  },

  methods: {

    // FUNCIÓN PARA LA REACTIVIDAD DE LOS DATOS
    recargarTabla() {
      axios.get('/Tareas/ListarTareas')
        .then(response => {
          this.listaTareas = response.data.resultado
          console.log(response.data.resultado)
        })
        .catch(error => {
          console.error("Hubo un error en la solicitud: ", error);
        })

    },

    // FUNCIÓN PARA AGREGAR UNA NUEVA TAREA
    agregarTarea() {
      let tarea;
      tarea = {
        titulo: this.titulo,
        detalle: this.detalle,
        usuarioCreador: this.usuarioCreador,
        fechaCreacion: this.fechaCreacion,
        fechaActualizacion: this.fechaActualizacion,
        fechaEliminacion: this.fechaEliminacion
      }
      console.log("Arreglo: ", tarea)

      axios.post('/Tareas/CrearTarea', tarea)
        .then(response => {
          console.log("Tarea creada con exito")
          window.location.reload()
        })
        .catch(error => {
          console.error("Hubo un error en la solicitud: ", error);
        })
    },

    // FUNCIÓN PARA EDITAR UNA TAREA
    editarTarea(tarea) {
      this.mostrarEditar = tarea;
      this.tituloTemporal = tarea.titulo

    },

    guardarTareaEditada() {
      this.mostrarEditar.titulo = this.tituloTemporal;
      const tareaEditada = JSON.stringify(this.mostrarEditar);

      axios.put(`/Tareas/ActualizarTarea/${this.mostrarEditar.id}`, tareaEditada, {
        headers: {
          'Content-Type': 'application/json'
        }
      })
        .then(response => {
          console.log("Tarea editada con exito")
          window.location.reload()
        })
        .catch(error => {
          console.error("Hubo un error en la solicitud: ", error);
        })


    },

    // FUNCIÓN PARA ELIMINAR UNA TAREA
    eliminarTarea(id) {
      axios.delete(`/Tareas/EliminarTarea/${id}`)
        .then(response => {
          console.log("Tarea eliminada con exito")
          window.location.reload()

        })
        .catch(error => {
          console.error("Hubo un error en la solicitud: ", error);
        })
    }

  },
  mounted() {
    this.recargarTabla()


    // axios.get('/Tareas/ListarTareas')
    //   .then(response => {
    //     this.listaTareas = response.data.resultado
    //     console.log(response.data.resultado)
    //   })
    //   .catch(error => {
    //     console.error("Hubo un error en la solicitud: ", error);
    //   })

  }
}

</script>

<style scoped>
/* CAJA QUE CONTIENE TODO */
.cajaTodo {
  margin: 50px auto;
  background-color: aliceblue;
  width: 400px;
  border-radius: 30px;
  padding: 10px;
  -webkit-box-shadow: 11px 18px 39px -3px rgba(0, 0, 0, 0.75);
  -moz-box-shadow: 11px 18px 39px -3px rgba(0, 0, 0, 0.75);
  box-shadow: 11px 18px 39px -3px rgba(0, 0, 0, 0.75);
}

/* CABEZERA */
.cabezera {
  display: flex;
  align-items: center;
}

.cabezera>img {
  width: 40px;
  height: 40px;
  margin-right: 10px;
}

/* FORMULARIO - AÑADIR */
.formulario {
  margin-top: 25px;
}

/* TABLA DE DATOS */

.tabla {
  margin-top: 35px;
}

ul {
  list-style: none;
  padding: 0;
  margin: 0;
}

li {
  background-color: rgb(228, 234, 238);
  display: flex;
  border-radius: 20px;
  padding: 8px;
  margin: 15px 0;
  align-items: center;
  justify-content: space-between;
}

p {
  margin: 0;
}

i {
  background-color: white;
}
</style>