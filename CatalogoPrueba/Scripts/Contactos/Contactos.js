$(".btnContactos").click(function (eve) {
    $("#modal-content").load("/Contacto/ListaContactosByID/" + $(this).data("id"));
});





