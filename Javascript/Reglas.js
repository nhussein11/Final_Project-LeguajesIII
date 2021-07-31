"use strict";

$(document).ready(function () {
    console.log("Documento ready")
    $('#Button_CargarRegla').click(function () {
        var titulo_regla = $('#TextBox_TituloRegla').val();
        var cuerpo_regla = $('#TextArea_InfoRegla').val();

        //'<tr ><td> Titulo 4 </td><td >Noticia 4</td></tr >'
        $('#TablaNoticiasBody').prepend('<tr><td>' + titulo_regla + '</td><td >' + cuerpo_regla + '</td></tr >');
        $('#DivToggle').css('display', 'none');
        return false;
    });
});