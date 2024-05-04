<template>
    <div class="row mt-3">
        <div class="col-md-6 offset-md-3">
            <div class="card-header bg-dark text-center">Editar Libro</div>
            <div class="card-body">
                <form @submit.prevent="actualizarLibro">

                    <div class="input-group mb-3">
                        <span class="input-group-text"><i class="fa-solid fa-gift"></i></span>
                        <input type="text" v-model="id" class="form-control" maxlength="50" placeholder="id" required>
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text"><i class="fa-solid fa-gift"></i></span>
                        <input type="text" v-model="nombre" class="form-control" maxlength="50" placeholder="Nombre" required>
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text"><i class="fa-solid fa-gift"></i></span>
                        <input type="text" v-model="detalles" class="form-control" maxlength="50" placeholder=" Detalles" required>
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text"><i class="fa-solid fa-gift"></i></span>
                        <input type="text" v-model="paginas" class="form-control" maxlength="50" placeholder="Páginas" required>
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text"><i class="fa-solid fa-gift"></i></span>
                        <input type="text" v-model="totales" class="form-control" maxlength="50" placeholder="Totales" required>
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text"><i class="fa-solid fa-gift"></i></span>
                        <input type="text" v-model="creador" class="form-control" maxlength="50" placeholder="Creador" required>
                    </div>
                    <div class="d-grid col-6 mx-auto">
                        <button class="btn btn-success"><i class="fa solid fa-floppy-disk"></i>Guardar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
import { show_alerta } from '../funciones';
import axios from 'axios';

export default {
    data() {
        return {
            id: 0,
            nombre: '',
            detalles: '',
            paginas: '',
            totales: '',
            creador: ''
        };
    },
    mounted() {
        this.id = this.$route.params.id; // Obtener el ID del libro de los parámetros de la ruta
        this.cargarDatos(); // Cargar los datos del libro al cargar el componente
    },
    methods: {
        cargarDatos() {
            axios.get(`https://www.crudapi.somee.com/api/Libreria/Id:int?Id=${this.id}`)
            
                .then(response => {
                    this.nombre = response.data.resultado.nombre;
                    this.detalles = response.data.resultado.detalles;
                    this.paginas = response.data.resultado.paginas;
                    this.totales = response.data.resultado.totales;
                    this.creador = response.data.resultado.creador;
                })
                .catch(error => {
                    console.error('Error al cargar los datos del libro:', error);
                });
            
        },

        actualizarLibro() {
            axios.put(`https://www.crudapi.somee.com/api/Libreria/${this.id}`, {
                id: this.id,
                nombre: this.nombre,
                detalles: this.detalles,
                paginas: this.paginas,
                totales: this.totales,
                creador: this.creador
            })
            .then(() => {
            
                show_alerta('Libro actualizado correctamente', 'success');
            })
            .catch(error => {
                // Muestra una alerta de error si hay algún problema con la actualización
                show_alerta('Error al actualizar el libro', 'error');
                console.error('Error al actualizar el libro:', error);
            });
        }
    }
};
</script>
