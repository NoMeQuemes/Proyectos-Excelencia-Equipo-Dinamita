import Swal from "sweetalert2";
import axios from "axios";

export function show_alerta(mensaje, icono, foco = '') {
    if (foco !== '') {
        document.getElementById(foco).focus();
    }
    Swal.fire({
        title: mensaje,
        icon: icono,
        customClass: { confirmButton: 'btn btn-primary', popup: 'animated zoomIn' },
    });
}

export function confirmar(id, nombre) {
    var url = 'https://www.crudapi.somee.com/api/Libreria/' + id;
    const SwalwithBootstrapButtons = Swal.mixin({
        customClass: { confirmButton: 'btn btn-success me-3', cancelButton: 'btn btn-danger' },
        buttonsStyling: false
    });
    SwalwithBootstrapButtons.fire({
        title: '¿Seguro de eliminar el producto ' + nombre + '?',
        text: 'Se perderá la información del producto',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: '<i class="fa-solid fa-check"></i> Si, eliminar',
        cancelButtonText: '<i class="fa-solid fa-ban"></i> Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            eliminarProducto(id);
        } else {
            show_alerta('Operación cancelada', 'info');
        }
    });
}

export function eliminarProducto(id) {
    axios.delete(`https://www.crudapi.somee.com/api/Libreria/${id}`)
        .then(response => {
            if (response.status === 204) {
                show_alerta('Libro eliminado', 'success');
               
                setTimeout(function () {
                    location.reload()
                }, 1500 );
                
            
              
            
            } else {
                show_alerta('Error al eliminar el libro3', 'error');
            }
         
        })
        .catch(error => {
            show_alerta('Error al eliminar el libro2', 'error');
            console.error('Error al eliminar el libro1:', error);
        });
}

//                        AGREGAR PRODUCTO
export function agregarProducto(nombre, detalles, paginas,totales,creador) {
    axios.post(`https://www.crudapi.somee.com/api/Libreria`, {
        nombre: nombre,
        detalles: detalles,
        paginas: paginas,
        totales: totales,
        creador:creador
    })
    .then(response => {
        if (response.status === 201) {
            show_alerta('Producto agregado correctamente', 'success');
        } else {
            show_alerta('Error al agregar el producto', 'error');
        }
    })
    .catch(error => {
        show_alerta('Error al agregar el libro', 'error');
        console.error('Error al agregar el producto:', error);
    });
}

export function actualizarProducto(Id, Nombre, Detalles, Paginas, Totales, Creador) {
    return new Promise((resolve, reject) => {
        axios.put(`https://www.crudapi.somee.com/api/Libreria/${Id}`, {
            Nombre: Nombre,
            Detalles: Detalles,
            Paginas: Paginas,
            Totales: Totales,
            Creador: Creador
        })
        .then(response => {
            if (response.status === 204) {
                resolve(); // Resuelve la promesa si la actualización es exitosa
            } else {
                reject('Error al actualizar el producto'); // Rechaza la promesa si hay un error
            }
        })
        .catch(error => {
            reject(error); // Rechaza la promesa si hay un error en la solicitud
        });
    });
}


export function enviarSolicitud(metodo,parametros,url,mensaje){

    axios({method:metodo,url:url,data:parametros}).then(function(respuesta){

      var status = respuesta.data[0]['status'];
      
      if (status==='success'){

        show_alerta(mensaje,status);
        window.setTimeout(function(){
            window.location.href="/";

            
        }, 1000);
      }
      else{
        var listado='';
        var errores=respuesta.data[1]['errors'];
        object.keys(errores).forEach(
            key =>listado =errores[key][0]+'.'
           
        );
        show_alerta(listado,error);
      }
      
    }).catch(function(error){
show_alerta('Error en la solicitud','error');
  })
}