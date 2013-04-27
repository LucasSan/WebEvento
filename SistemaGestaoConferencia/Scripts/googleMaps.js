function carregaMapa() {

    var map = new GMap2(document.getElementById("map_canvas"), { size: new GSize(600, 294) });
    var client = new GClientGeocoder();

    //SE FOR INCLUSÃO
    dscTipoLogradouro = $("#logradouro option:selected").text();
    dscLogradouro = $("#logradouroEndereco option:selected").text();
    dscCidade = $("#cidade option:selected").text();
    numero = $("#numEndereco").val();

    //alert(dscTipoLogradouro + dscLogradouro + dscCidade + numero);

    var address = dscTipoLogradouro + " " + dscLogradouro + ", " + numero + " - " + dscCidade + " - Brasil";
    client.getLatLng(address, function (point) {

        map.removeMapType(G_HYBRID_MAP);
        map.setCenter(point, 15);

        var mapControl = new GMapTypeControl();
        map.addControl(mapControl);
        map.addControl(new GLargeMapControl());

        var baseIcon = new GIcon(G_DEFAULT_ICON);
        baseIcon.image = "../tema/default/images/pin_principal.png";

        var markerFixo = new GMarker(point, { icon: baseIcon, draggable: false, bouncy: true });
        map.addOverlay(markerFixo);

        var center = map.getCenter();
        latitudeEnderecoOriginal = center.lat();
        longitudeEnderecoOriginal = center.lng();
    });

    address = dscTipoLogradouro + " " + dscLogradouro + ", " + (parseFloat(numero) + 100).toString() + " - " + dscCidade + " - Brasil";
    client.getLatLng(address, function (point) {

        var baseIcon = new GIcon(G_DEFAULT_ICON);
        baseIcon.image = "../tema/default/images/pin_fake.png";

        var marker = new GMarker(point, { icon: baseIcon, draggable: true, bouncy: true });
        map.addOverlay(marker);

        latLong = marker.getPoint();
        latitudeEnderecoFake = latLong.y;
        longitudeEnderecoFake = latLong.x;

        //alert(latLong + "-" + latitudeEnderecoFake + "-" + longitudeEnderecoFake);

        GEvent.addListener(marker, "dragend", function () {
            latLong = marker.getPoint();
            latitudeEnderecoFake = latLong.y;
            longitudeEnderecoFake = latLong.x;


        });
    });
}