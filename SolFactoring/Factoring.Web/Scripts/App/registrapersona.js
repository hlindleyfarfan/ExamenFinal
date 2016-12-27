var modulopersona = (function () {
    function configuraCombosEnCascadaUbigeo($seccion) {
        if ($seccion.length <= 0) return; // si la seccion no existe no esta vacia
        // configurar
        $seccion.cascadingDropdown({
            selectBoxes: [
                {
                    selector: 'select.departamento',
                    source: function (request, response) {
                        $.getJSON('/Ubigeo/Departamentos', function (dptosLista) {
                            var dpto = $seccion.find('input[type=hidden].departamento').val(); // para preseleccionar el dpto
                            //map convierte la lista de dptos en un arreglo o lista de objetos para el combo
                            var dptos = $.map(dptosLista, function (item, index) {
                                return {
                                    label: item,  //item.descricion,
                                    value: item,  //item.codigo,
                                    selected: item === dpto // item.codigo === dpto
                                }
                            });
                            response(dptos);
                        });
                    }
                },
                {
                    selector: 'select.provincia',
                    requires: ['select.departamento'],
                    source: function (request, response) {
                        $.getJSON('/Ubigeo/Provincias', request,
                            function (provLista) {
                                var prov = $seccion.find('input[type=hidden].provincia').val(); // para preseleccionar el dpto
                                var provs = $.map(provLista, function (item, index) {
                                    return {
                                        label: item,  //item.descricion,
                                        value: item,  //item.codigo,
                                        selected: item === prov // item.codigo === dpto
                                    }
                                });
                                response(provs);
                            });
                    }
                },
                {
                    selector: 'select.distrito',
                    requires: ['select.departamento', 'select.provincia'],
                    source: function (request, response) {
                        $.getJSON('/Ubigeo/Distritos', request,
                            function (distLista) {
                                var dist = $seccion.find('input[type=hidden].distrito').val(); // para preseleccionar el dpto
                                var dists = $.map(distLista, function (item, index) {
                                    return {
                                        label: item,  //item.descricion,
                                        value: item,  //item.codigo,
                                        selected: item === dist // item.codigo === dpto
                                    }
                                });
                                response(dists);
                            });
                    },
                    onChange: function (event, value, requiredValues) {
                        if (value) {
                            $seccion.find('input[type=hidden].departamento').val(requiredValues['departamento']);
                            $seccion.find('input[type=hidden].provincia').val(requiredValues['provincia']);
                            $seccion.find('input[type=hidden].distrito').val(value);

                        }
                    }
                }
            ]
        });
    }

    // publicamos los metodos del modulo

    return {
        vincularControles: function () {
            configuraCombosEnCascadaUbigeo($("#persona-ubigeo"));
        }
    }
})();

// configuramos la iife

$(function () {
    modulopersona.vincularControles();
});