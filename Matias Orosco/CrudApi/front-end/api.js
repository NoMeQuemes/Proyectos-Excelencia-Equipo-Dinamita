document.addEventListener("DOMContentLoaded", init);



async function init() {
    await search();
}

async function search() {
    var url = 'https://localhost:7103/api/Libreria';
    var response = await fetch(url, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });

    var resultado = await response.json();
    var html = '';
    for (var customer of resultado) {
        var row = `
            <tr>
                <td>${customer.nombre}</td>
                <td>${customer.detealles}</td>
                <td>${customer.paginas}</td>
                <td>${customer.totales}</td>
                <td>${customer.creador}</td>
                <td>${customer.fecha}</td>
            </tr>
        `;
        html += row;
    }
    document.querySelector('#customers > tbody').innerHTML = html; // Utiliza innerHTML para asignar todo el HTML a la tabla
}

