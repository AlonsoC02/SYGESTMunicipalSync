function verModal(titulo, texto) {
    return Swal.fire({
        title: titulo,
        text: texto,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'No',
        confirmButtonText: 'Si',
        timer: 8000,
        closeOnConfirm: true
    })
}
//function Imprimir(table,titulo,col1,col2,col3,col4,col5) {
//    //<table><thead></thead><tbody></tbody></table>
//    var head = document.getElementById("head").outerHTML;
//    table = table.replace(head, "");
//    var columnas = "";
//    if (col1 != "") columnas += col1+" ";
//    if (col2 != "") columnas += col2 + " ";
//    if (col3 != "") columnas += col3 + " ";
//    if (col4 != "") columnas += col4 + " ";
//    if (col5 != "") columnas += col5 + " ";
//    var tabla = "<h1>Reporte de " + titulo + " </h1>"
//        + "<h3>"+columnas+"</h3>"
//        + table.outerHTML;
//        //+ "<h3>Especialidad Id          Especialidad</h3>"
//        //+ table.outerHTML;
//        //+ document.getElementById(table).outerHTML;
//        //+ document.getElementById("TbEspecial").outerHTML;
//    var pagina = window.document.body;
//    var ventana = window.open("");
//    ventana.document.write(tabla);
//    ventana.print();
//    ventana.close();
//    window.document.body.pagina;
//}

function pintarPantallaConsulta(url, campos, tbody) {
    var contenido = "";
    var nombreCampo;
    var objetoActual;
    contenido += "<tr style='background-color:#111110;color:white;'>";
    for (j = 0; j < campos.length; j++) {
        var cabecera = campos[j];
        cabecera = cabecera.charAt(0).toUpperCase() + cabecera.slice(1);
        contenido += "<td>" + cabecera + "</td>";
    }
    contenido += "</tr>";

    $.get(url, function (data) {
        for (var i = 0; i < data.length; i += 1) {
            contenido += "<tr>";
            for (j = 0; j < campos.length; j++) {
                nombreCampo = campos[j];
                objetoActual = data[i];
                contenido += "<td style='text-align:left;'>"
                    + objetoActual[nombreCampo] + "</td>";
            }
            contenido += "</tr>";
        }
        tbody.innerHTML = contenido;
    })
}
function pintarPantallaCRUD(url, campos, propiedadId, nombreController,
    tbody) {
    var contenido = "";
    var nombreCampo;
    var objetoActual;
    $.get(url, function (data) {
        for (var i = 0; i < data.length; i += 1) {
            contenido += "<tr>";
            for (j = 0; j < campos.length; j++) {
                nombreCampo = campos[j];
                objetoActual = data[i];
                contenido += "<td>" + objetoActual[nombreCampo] + "</td>";
            }
            contenido += `<td>
                        <i class="fa fa-trash btn btn-danger" aria-hidden="true"
                                  onclick = "nombreController(${data[i].propiedadId})" >
                                  </i >
                        <a class="fa fa-info-circle btn btn-primary" aria-hidden="true"
                           asp-controller="nombreController" asp-action="Details"
                                      asp-route-id="${data[i].propiedadId})"></a>
            
                        <a href="${nombreController}/Edit" asp-route-id="${objetoActual[propiedadId]}">                 
                          <i class="fa fa-pencil btn btn-info" aria-hidden="true"></i>
                        </a>
                    </td>`
            contenido += "</tr>";
        }
        tbody.innerHTML = contenido;
        $('#tbDatos').DataTable();
    })
}
function correcto(title = "Listo!") {
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: title,
        showConfirmButton: true,
        timer: 3500
    })
}
function error(title = "Error!") {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: title,
        timer: 3500
    })
}