jQuery.noConflict();
(function ($) {
    $(function () {
        //Events with danger --Delete --
        //Parameters Swal Alert button delete/active
        var titleSwal = "¿Desea Eliminar el registro?";
        var textSwal = "Este paso eliminara el registro del sistema";
        var typeSwal = "warning";

        $(".tablecontainer").on("click", "a.swalDelete", function (e) {
            var urlAjaxSwal = $(this).data("url");

            swal({
                title: titleSwal,
                text: textSwal,
                icon: typeSwal,
                buttons: {
                    close: {
                        text: "Cerrar",
                        value: "Cancelar",
                        className: "btn-info"
                    },
                    delete: {
                        text: "Eliminar",
                        value: "Delete",
                        className: "btn-danger"
                    }
                }
            }).then((value) => {
                if (value === "Delete") {
                    $.ajax({
                        type: "DELETE",
                        url: urlAjaxSwal,
                        data: {},
                        success: function (data) {
                            if (data.status) {
                                swal("Ok", data.message, "success");
                                setInterval(location.reload(), 2000);
                            }
                            else {
                                swal("¡Error!", data.message, "error");
                            }
                        },
                    }); //Ajax
                }
            });
        });
    });
})(jQuery);
