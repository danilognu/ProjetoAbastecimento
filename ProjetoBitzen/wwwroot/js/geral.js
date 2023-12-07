



$(document).ready(function () {
    $("#CPF").mask('000.000.000-00', { reverse: true });
    $("#DATA").mask('00/00/0000', { reverse: true });
    $("#CNH").mask('00000000000', { reverse: true });
    $("#ANO").mask('0000');
    $("#DECIMAL").mask('00.00');    
});