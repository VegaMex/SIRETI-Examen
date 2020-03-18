$(document).ready(function () {
    let table = $('#contenido_grvListaUsuarios');
    let row = $(table).find("tbody tr:first").clone();
    $(table).find("tbody tr:first").remove();
    let head = $("<thead/>").append(row);
    $(table).children('tbody').before(head);
    $('#contenido_grvListaUsuarios').DataTable();
});