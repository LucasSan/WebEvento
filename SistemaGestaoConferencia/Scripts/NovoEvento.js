$(function () {
    $("#txtCep").mask("99999-999");

    $("#valorPreco").priceFormat({
        prefix: '', centsSeparator: ',', thousandsSeparator: '.'
    });

    $("#tab3").hide();
    $("#tab4").hide();

    $(".vaiInformacao").click(function () {
        //Verificar Campos
        //CEP
        if ($("#cep").val() == "") {
            alert("Favor informar o Cep");
            $("#cep").focus();
            return false;
        }

        //Numero
        if ($("#numEndereco").val() == "") {
            alert("Favor informar o número");
            $("#numEndereco").focus();
            return false;
        }

        $("#tabs-1").hide();
        $(".Tab3").click();
        //        scrollTop();
    });

    $(".Tab1").click(function () {
        $("#tabs-1").show();
        $("#tab3").hide();
        $("#tab4").hide();
    });

    $(".Tab3").click(function () {
        $("#tabs-1").hide();
        $("#tab4").hide();
        $("#tab3").show();
    });

    $(".Tab4").click(function () {
        $("#tab4").show();
        $("#tab3").hide();
        $("#tabs-1").hide();
    });

    

    //CONSULTA ENDEREÇO PELO CEP
    $("#txtCep").blur(function () {
        $("#estado").empty().attr("disabled", "disabled");
        $("#cidade").empty().attr("disabled", "disabled");
        $("#bairro").empty().attr("disabled", "disabled");
        $("#segundoBairro").empty().attr("disabled", "disabled");
        $("#logradouro").empty().attr("disabled", "disabled");
        $("#logradouroEndereco").empty().attr("disabled", "disabled");

        cep = $(this).val();
        cep = cep.replace("-", "");
        ConsultaCEP(cep, 1);
    });

    function ConsultaCEP(cep, tipo) {
        idCepEndereco = "";
        $.get("../Xml/Endereco.aspx?rand=" + Math.random(2), { cep: cep }, function (data) {
            $(data).find("REGISTRO").each(function () {
                DscCepTipoLogradouro = $(this).find("TIPO").text();
                DscCepLogradouro = $(this).find("LOGRADOURO").text();
                DscCepBairro = $(this).find("BAIRRO").text();
                DscCepEstado = $(this).find("ESTADO").text();
                DscCepCidade = $(this).find("CIDADE").text();
                idCepTipoLogradouro = $(this).find("LOGRADOURO_ID").text();
                idCepEndereco = $(this).find("ID").text();
                idCepBairro = $(this).find("BAIRRO_ID").text();
                idCepEstado = $(this).find("ESTADO_ID").text();
                idCepCidade = $(this).find("CIDADE_ID").text();
                flagCepCapital = $(this).find("CAPITAL").text();
            });

            if (idCepEndereco == 0) {
                alert("CEP não encontrado");
                return false;
            }

            ConsultaEstado(idCepEstado);
            ConsultaCidade(idCepEstado, idCepCidade);
            ConsultaBairro(idCepCidade, idCepBairro);
            ConsultaTipoLogradouro(idCepTipoLogradouro);
            ConsultaLogradouro(idCepBairro, idCepEndereco);
        },
                "xml"
            );
        return true;
    }

    function ConsultaEstado(idCepEstado) {
        $.get("../Xml/Estado.aspx?rand=" + Math.random(2), function (data) {
            htmlComboEstado = "";
            $(data).find("REGISTRO").each(function () {
                idEstado = $(this).find("ESTADO_ID").text();
                dscSiglaEstado = $(this).find("SIGLAESTADO").text();
                dscEstado = $(this).find("NOMEESTADO").text();

                htmlComboEstado = htmlComboEstado + "<option value='" + idEstado + "'>" + dscEstado + "</option>";
            });
            $("#estado").html(htmlComboEstado);
            if (idCepEstado != "") {
                $("#estado").val(idCepEstado);
            }
        },
                "xml"
            );
        return true;
    }

    function ConsultaCidade(idEstado, idCepCidade) {
        $.get("../Xml/Cidade.aspx?rand=" + Math.random(2), { estado: idEstado, Cidade: idCepCidade }, function (data) {
            htmlComboCidade = "";
            $(data).find("REGISTRO").each(function () {
                idCidade = $(this).find("CIDADE_ID").text();
                idEstado = $(this).find("ESTADO_ID").text();
                dscCidade = $(this).find("NOMECIDADE").text();
                cepCidade = $(this).find("CEPCIDADE").text();

                htmlComboCidade = htmlComboCidade + "<option value='" + idCidade + "'>" + dscCidade + "</option>";
            });
            $("#cidade").html(htmlComboCidade);
            if (idCepCidade != "") {
                $("#cidade").val(idCepCidade);
            }
        },
                "xml"
            );
        return true;
    }

    function ConsultaBairro(idCidade, idCepBairro) {
        $.get("../Xml/Bairro.aspx?rand=" + Math.random(2), { cidade: idCidade }, function (data) {
            htmlComboBairro = "";
            $(data).find("REGISTRO").each(function () {
                idBairro = $(this).find("BAIRRO_ID").text();
                idRegiao = $(this).find("REGIAO_ID").text();
                idCidade = $(this).find("CIDADE_ID").text();
                dscBairro = $(this).find("NOMEBAIRRO").text();

                htmlComboBairro = htmlComboBairro + "<option value='" + idBairro + "'>" + dscBairro + "</option>";
            });
            $("#bairro").html(htmlComboBairro).removeAttr("disabled");
            $("#segundoBairro").html("<option value='0'>-- Selecione --</option>").append(htmlComboBairro).removeAttr("disabled");
            if (idCepBairro != "") {
                $("#bairro").val(idCepBairro);
            }
        },
                "xml"
            );
        return true;
    }

    function ConsultaTipoLogradouro(idCepTipoLogradouro) {
        $.get('../Xml/Logradouro.aspx?rand=' + Math.random(2), function (data) {
            htmlComboLogradouro = '';
            $(data).find('REGISTRO').each(function () {
                idTipoLogradouro = $(this).find('LOGRADOURO_ID').text();
                dscTipoLogradouro = $(this).find('DESCRICAO ').text();

                htmlComboLogradouro = htmlComboLogradouro + '<option value="' + idTipoLogradouro + '">' + dscTipoLogradouro + '</option>';
            });
            $('#logradouro').html(htmlComboLogradouro).val(idCepTipoLogradouro);

            if (flagCepCapital == 'False') {
                $('#logradouro').removeAttr('disabled');
            }
            if (idCepTipoLogradouro != '') {
                $('#logradouro').val(idCepTipoLogradouro);
            }
        },
                'xml'
            );
        return true;
    }

    function ConsultaLogradouro(idBairro, idCepEndereco) {
        $.get('../Xml/LogradouroBairro.aspx?rand=' + Math.random(2), { bairro: idBairro, cep: idCepEndereco }, function (data) {
            htmlComboLogradouroBairro = '';
            $(data).find('REGISTRO').each(function () {
                dscLogradouro = $(this).find('LOGRADOURO').text();
                idLogradouro = $(this).find('ENDERECO_ID').text();
                idTipoLogradouro = $(this).find('LOGRADOURO_ID').text();

                htmlComboLogradouroBairro = htmlComboLogradouroBairro + '<option value="' + idLogradouro + '">' + dscLogradouro + '</option>';
            });
            $('#logradouroEndereco').html(htmlComboLogradouroBairro).val(idCepEndereco);

            if (flagCepCapital == 'False') {
                $('#logradouroEndereco').removeAttr('disabled');
            }
            if (idCepEndereco != '') {
                $('#logradouroEndereco').val(idCepEndereco);
            }
        },
                'xml'
            );
        return true;
    }

    // Auto Complete de Data
    $("#txtDataInicio").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true,
        minDate: +5,
        dayNames: [
                'Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado', 'Domingo'
                ],
        dayNamesMin: [
                'D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'
                ],
        dayNamesShort: [
                'Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'
                ],
        monthNames: [
                'Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro',
                'Outubro', 'Novembro', 'Dezembro'
                ],
        monthNamesShort: [
                'Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set',
                'Out', 'Nov', 'Dez'
                ],
        nextText: 'Próximo',
        prevText: 'Anterior'
    });

});