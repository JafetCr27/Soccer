//valida si es nulo o vacio
var isNullOrEmpty = (value, nombre) => {
    if (value === "" || value === null || value === "0") {
        $.toast({
            heading: "Error",
            text: "Por favor ingrese " + nombre,
            showHideTransition: "slide",
            position: "top-right",
            icon: "error",
            stack: false
        });
        return true;
    }
    return false;
}

//devuelve si existe un objeto dentro de un array
var findObjectByKey = (numarray, key, array) => {
    for (var i = 0; i < array.length; i++) {
        if (array[i][key] === value) {
            return true;
        }
    }
    return false;
}


// obtiene le objeto de un array
var findandGetObjectByKey = (numarray, key, array) => {
    for (var i = 0; i < array.length; i++) {
        if (array[i][key] === value) {
            return array[i];
        }
    }
}

//Muestra Progress bar
var ShowLoading = () => {
    waitingDialog.show("Por favor espere...",
        {
            headerText: "Cargando...",
            headerSize: 3,
            headerClass: "",
            dialogSize: "m",
            progressType: "success",
            contentElement: "p",
            contentClass: "content"
        });
}
//oculta progress bar
var HideLoading = () => {
    waitingDialog.hide();
}
// devuelve numero con separador de decimales
var formatNumber = (number) => {
    number = (number).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,'); // 12,345.67
    return number;
}
var CrearDataTable = (tabla) => {
    $("#" + tabla).DataTable({
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        }
    });
}

var CrearDataTableConfigurable = (tabla, configuracion) => {
    $("#" + tabla).DataTable({
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        }, configuracion
    });
}

// var rowsSelected = []; Se debe declarar este array en la vista principal

var Marcar = (rowId,rowsSelected) => {
    if (rowsSelected.length === 0) {
        rowsSelected.push(rowId.toString());
    } else {
        for (var i = 0; i < rowsSelected.length; i++) {
            console.log(rowsSelected[i].toString());
            console.log(rowId.toString());
            if (rowsSelected[i].toString() === rowId.toString()) {
                rowsSelected.splice(i, 1);
                break;
            } else {
                console.log(rowId.toString());
                rowsSelected.push(rowId.toString());
                break;
            }
        }
    }
}
// Marcar todos las lineas en un DataTable
var MarcarTodos = (idTodos,rowsSelected) => {

    $('#' + idTodos).click(() => {
        for (var i = 0; i < data.length; i++) {
            var index = $.inArray(data[i][1].toString(), rowsSelected);
            if (index === -1) {
                rowsSelected.push(data[i][1].toString());
            } else if (index !== -1) {
                rowsSelected.splice(index, 1);
            }
        }
        console.log(rowsSelected);
        var cells = table.cells().nodes();
        $(cells).find(':checkbox').prop('checked', $(this).is(':checked'));
    });
}

var Confirmar = (mensaje, pantalla) => {
    swal({
        title: 'Resultado!',
        text: mensaje,
        confirmButtonText: 'Ok!',
        allowOutsideClick: false,
        allowEscapeKey: false,
        type: 'success'
    }).then((result) => {
        ShowLoading();
        window.location.href = "/" + pantalla;
    });
}

var MostrarMensajeError = (estado) => {
    swal({
        type: 'error',
        html:
            '<p class="text-danger"><strong>' + estado + '</strong></p>',
        showCloseButton: true,
        showCancelButton: false,
        confirmButtonColor: '#449d44',
        focusConfirm: false,
        confirmButtonText:
            '<i class="glyphicon glyphicon-thumbs-up"></i> Ok!',
        allowOutsideClick: false

    });
}

var ValidarCampoCero = (value, linea) => {
    try {
        if (value === "" || value === null || parseFloat(value) < 0) {
            $("#" + linea).val(parseFloat(0.00));
            return 0;
        }
        return value;
    } catch (error) {
        console.log(error);
        $("#" + linea).val(parseFloat(0.00));
        return 0;
    }
}

var validateDate = (startDate, endDate) => {
    var firstDate = new Date(startDate);
    var secondDate = new Date(endDate);
    var dateNow = new Date();
    var dateTimeNow = new Date(dateNow.getFullYear(), dateNow.getMonth(), dateNow.getDate(), 0, 0, 0, 0);
    var date = new Date(firstDate.getFullYear(), firstDate.getMonth(), firstDate.getDate(), 0, 0, 0, 0);
    var date1 = new Date(secondDate.getFullYear(), secondDate.getMonth(), secondDate.getDate(), 0, 0, 0, 0);
    // console.log(date);
    // console.log(dateTimeNow);
    // console.log(date1);
   
    if (secondDate < firstDate) {
        $.toast({
            heading: "Error",
            text: "La fecha final debe ser menor a la fecha inicial",
            showHideTransition: "slide",
            position: "top-right",
            icon: "error",
            stack: false
        });
        return false;
    }
    return true;
}

var errorAjax = (jqXhr, exception) => {
    var msg = "";
    if (jqXhr.status === 0) {
        msg = 'Not connect.\n Verify Network.';
    } else if (jqXhr.status === 404) {
        msg = 'Requested page not found. [404]';
    } else if (jqXhr.status === 500) {
        msg = 'Internal Server Error [500].';
    } else if (exception === 'parsererror') {
        msg = 'Requested JSON parse failed.';
    } else if (exception === 'timeout') {
        msg = 'Time out error.';
    } else if (exception === 'abort') {
        msg = 'Ajax request aborted.';
    } else {
        msg = 'Uncaught Error.\n' + jqXhr.responseText;
    }
    $.toast({
        heading: "Error",
        text: msg,
        showHideTransition: "slide",
        position: "top-right",
        icon: "error",
        stack: false
    });
}