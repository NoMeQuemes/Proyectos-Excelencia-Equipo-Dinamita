<template>
 <div class= "row mt-3">
     <div class="col-md-6 offset-md-3">
        <div class="card-header bg-dark text-center" Crear libreria></div>
            <div class="card-body">
                <form @submit.prevent="agregarProducto">
                <div class="input-group mb-3">
                    <span class="input-group-text"><i class="fa-solid fa-gift"></i></span>
                    <input type="text" id="nombre" class="form-control"
                    maxlength="50" placeholder="Nombre" required>
                </div>
                <div class="input-group mb-3">
                    <span class="input-group-text"><i class="fa-solid fa-gift"></i></span>
                    <input type="text" id="detalles" class="form-control"
                    maxlength="50" placeholder="detalles" required>
                </div>
                <div class="input-group mb-3">
                    <span class="input-group-text"><i class="fa-solid fa-gift"></i></span>
                    <input type="text" id="paginas" class="form-control"
                    maxlength="50" placeholder="paginas" required>
                </div>
                <div class="input-group mb-3">
                    <span class="input-group-text"><i class="fa-solid fa-gift"></i></span>
                    <input type="text" id="totales" class="form-control"
                    maxlength="50" placeholder="totales" required>
                </div>
                <div class="input-group mb-3">
                    <span class="input-group-text"><i class="fa-solid fa-gift"></i></span>
                    <input type="text" id="creador" class="form-control"
                    maxlength="50" placeholder="creador" required>
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
import { agregarProducto } from '../funciones';

export default {
    methods: {
        agregarProducto() {
            const nombre = document.getElementById('nombre').value;
            const detalles = document.getElementById('detalles').value;
            const paginas = document.getElementById('paginas').value;
            const totales = document.getElementById('totales').value;
            const creador = document.getElementById('creador').value;

            // Llama a la función agregarProducto con los datos del formulario
            agregarProducto(nombre, detalles, paginas, totales, creador);
        }
    }
}
</script>