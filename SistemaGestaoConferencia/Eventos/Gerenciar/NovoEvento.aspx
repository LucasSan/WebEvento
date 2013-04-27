<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.Master" AutoEventWireup="true"
    CodeBehind="NovoEvento.aspx.cs" Inherits="SistemaGestaoConferencia.Eventos.Gerenciar.NovoEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link href="../../Bootstrap/css/bootstrap.css" rel="Stylesheet" type="text/css" />
    <link href="../../Bootstrap/css/bootstrap-responsive.css" rel="Stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=true&amp;key=ABQIAAAAgrpvTScJdNYDjkgChkra5BTYREuAZDbzB9swikeKxoc-FhvaSBSa6O0oAWkDPSy9nxa2NGafhxpY7A"
        type="text/javascript"></script>
    <script src="../../Scripts/jquery.maskedinput.js" type="text/javascript"></script>
    <script src="../../Scripts/NovoEvento.js" type="text/javascript"></script>
    <script src="../../Scripts/googleMaps.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.price_format_1.7.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.datepicker.js" type="text/javascript"></script>    
    <script type="text/javascript" src="../../Bootstrap/js/bootstrap.js"></script>
    <script type="text/javascript" src="../../Bootstrap/js/bootstrap-carousel.js"></script>

    
    <script type="text/javascript">
        $(function () {
            $("#numEndereco").blur(function () {
                if ($("#bairro").val() != "") {
                    carregaMapa();
                }
            });

            $("#txtValorConvites").priceFormat({
                prefix: '', centsSeparator: ',', thousandsSeparator: '.'
            });

        });
    </script>

    <style type="text/css">
        .campoCarac { width: 60px; }
        .checkCarac { float: right; }
        #map_canvas{background-color: #f0f0f0;border: 1px dotted #f58020;margin: auto; width: 630px; height: 294px;margin: auto;}
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="BoxEstilo" style="width: 100%; margin-left:30px; margin-top: 60px;">
    <asp:Panel ID="pnlNovoEvento" runat="server">
        <div class="tabbable" style="margin-top:-20px;">
            <ul class="nav nav-tabs">
                <li class="active">
                    <div class="CancelaEndereco">
                        &nbsp;</div>
                    <a href="#tab1" class="Tab1" data-toggle="tab">Endereço</a> </li>
                <li>
                    <div class="CancelaCaracateristica">
                        &nbsp;</div>
                    <a href="#tab3" class="Tab3" data-toggle="tab">Características</a> </li>
                <li>
                    <div class="CancelaApresentacao">
                        &nbsp;</div>
                    <a href="#tab4" class="Tab4" data-toggle="tab">Convites</a> </li>                
                <li>
                    <div class="CancelaConfirmacao">
                        &nbsp;</div>
                    <a href="#tab5" class="Tab5" data-toggle="tab">Confirmação</a></li>
                <li>
                    <div class="CancelaConclusao">
                        &nbsp;</div>
                    <a href="#tab6" class="Tab6" data-toggle="tab">Conclusão</a> </li>
            </ul>
            <div id="tabs-1" class="formContainer" style="margin-top: 30px; margin-left: 30px;">
                <table width="97%" border="0">
                    <tr>
                        <td>
                            <label for="cep">
                                CEP: *</label>
                        </td>
                        <td width="62" align="center">
                            &nbsp;
                        </td>
                        <td>
                            <label for="estado">
                                Estado:</label>
                        </td>
                        <td width="62" align="center">
                            &nbsp;
                        </td>
                        <td>
                            <label for="cidade">
                                Cidade:</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input id="txtCep" type="text" class="validate[required]" />
                        </td>
                        <td align="center">
                            <img class="stepArrow" src="../../Imagem/step_arrow.jpg" alt="arrow" />
                        </td>
                        <td>
                            <select name="estado" disabled="disabled" id="estado">
                                <option></option>
                            </select>
                        </td>
                        <td align="center">
                            <img class="stepArrow" src="../../Imagem/step_arrow.jpg" alt="arrow" />
                        </td>
                        <td>
                            <select name="cidade" disabled="disabled" id="cidade">
                                <option></option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <table style="margin-top: 5px;">
                                <tr>
                                    <td width="25px">
                                        <img src="../../Imagem/dica_icone.jpg" />
                                    </td>
                                    <td>
                                        <span class="dica"><b>Dica:</b> Não sabe o CEP? <a href="http://www.buscacep.correios.com.br/"
                                            target="_blank">Clique aqui</a></span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" align="center">
                            <div class="divSplitLine">
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="97%" border="0">
                    <tr>
                        <td>
                            <label for="bairro">
                                Bairro principal:</label>
                        </td>
                        <td align="center" width="65px">
                            &nbsp;
                        </td>
                        <td width="160px">
                        </td>
                        <td align="center" width="70px">
                            &nbsp;
                        </td>
                        <td>
                            <label for="segundoBairro" id="labelSegundoBairro" style="display: none;">
                                Bairro alternativo:</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <select name="bairro" disabled="disabled" id="bairro">
                                <option></option>
                            </select>
                        </td>
                        <td align="center">
                            <img class="stepArrow" src="../../Imagem/step_arrow.jpg" alt="arrow" />
                        </td>
                        <td align="center">
                            <span id="btSegundoBairro">Deseja outro bairro?</span>
                        </td>
                        <td align="center">
                            <img id="arrowSegundoBairro" style="display: none;" class="stepArrow" src="../../Imagem/step_arrow.jpg"
                                alt="arrow" />
                        </td>
                        <td>
                            <select name="segundoBairro" disabled="disabled" id="segundoBairro" style="display: none;
                                margin-top: 0px;">
                                <option></option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" align="center">
                            <div class="divSplitLine">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="logradouro">
                                Tipo do Logradouro:</label>
                        </td>
                        <td align="center" width="83px">
                        </td>
                        <td colspan="3">
                            <label for="logradouroEndereco">
                                Logradouro:</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <select name="logradouro" disabled="disabled" id="logradouro">
                                <option></option>
                            </select>
                        </td>
                        <td align="center">
                            <img class="stepArrow" src="../../Imagem/step_arrow.jpg" alt="arrow" />
                        </td>
                        <td colspan="3">
                            <select name="logradouroEndereco" disabled="disabled" id="logradouroEndereco">
                                <option></option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" align="center">
                            <%--<img alt="split" class="splitLine" src="../tema/default/images/split_dotted_line.jpg" />--%>
                            <div class="divSplitLine">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="numEndereco">
                                Número: *</label>
                        </td>
                        <td width="48px" align="center">
                            &nbsp;
                        </td>
                        <td>
                            <label for="tipoComplemento">
                                Tipo do Complemento:</label>
                        </td>
                        <td width="48px">
                        </td>
                        <td>
                            <label for="compEndereco">
                                Complemento:</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input id="numEndereco" type="text" value="<%= Numero %>" class="validate[required,custom[number]] text-input" />
                        </td>
                        <td align="center">
                            <img class="stepArrow" src="../../Imagem/step_arrow.jpg" alt="arrow" />
                        </td>
                        <td>
                            <select id="tipoComplemento" name="tipoComplemento">
                                <option></option>
                            </select>
                        </td>
                        <td align="center">
                            <img class="stepArrow" src="../../Imagem/step_arrow.jpg" alt="arrow" />
                        </td>
                        <td>
                            <input id="compEndereco" type="text" value="<%= Complemento %>" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" align="center">
                            <%--<img alt="split" class="splitLine" src="../tema/default/images/split_dotted_line.jpg" />--%>
                            <div class="divSplitLine">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <div id="map_canvas">
                            </div>
                        </td>
                    </tr>

                    <tr>
                    <td>
                    <div class="btn btn-netimoveis btn-right btn-GeraEnderecoTopo vaiInformacao">
                        <div class="texto_botao_">Próximo</div>
                    </div>
                    </td>
                    </tr>
                </table>
            </div>


            











<!-- Inicio do Painel 3 -->
            <div class="tab-pane" id="tab3" style="margin-left: 30px;">
                <div id="listaCaracteristicas">
                    <table>                        
                        <tr>
                            <td>
                                <label for="carac_15">
                                    Vagas de Estacionamento</label>
                            </td>
                            <td>
                                <select id="carac_15" class="comboCarac input-mini">
                                    <option selected="selected" value="0">--</option>
                                    <option selected="selected" value="1">1</option>
                                    <option selected="selected" value="2">2</option>
                                    <option selected="selected" value="3">3</option>
                                    <option selected="selected" value="4">4</option>
                                    <option selected="selected" value="5">5</option>
                                </select>
                            </td>
                            <td>
                                <label for="carac_47">
                                    Descrição vagas</label>
                            </td>
                            <td>
                                <input type="text" id="carac_47" class="campoCarac input-mini" />
                            </td>
                        </tr>                        
                        <tr>
                            <td>
                                <label for="carac_18" title="carac_18">
                                    Almoço</label>
                            </td>
                            <td>
                                <input type="checkbox" id="carac_18" class="checkCarac" /><label for="carac_18">Sim</label>
                            </td>
                            <td>
                                <label for="carac_19" title="carac_19">
                                    Jantar</label>
                            </td>
                            <td>
                                <input type="checkbox" id="carac_19" class="checkCarac" /><label for="carac_19">Sim</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label for="carac_20" title="carac_20">
                                    CoffeBreak</label>
                            </td>
                            <td>
                                <input type="checkbox" id="carac_20" class="checkCarac" /><label for="carac_20">Sim</label>
                            </td>
                            <td>
                                <label for="carac_21" title="carac_21">
                                    Bebidas</label>
                            </td>
                            <td>
                                <input type="checkbox" id="carac_21" class="checkCarac" /><label for="carac_21">Sim</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label for="carac_20" title="carac_20">
                                    Buffet</label>
                            </td>
                            <td>
                                <input type="checkbox" id="Checkbox1" class="checkCarac" /><label for="carac_20">Sim</label>
                            </td>
                            <td>
                                <label for="carac_21" title="carac_21">
                                    Manobristas</label>
                            </td>
                            <td>
                                <input type="checkbox" id="Checkbox2" class="checkCarac" /><label for="carac_21">Sim</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label for="carac_20" title="carac_20">
                                    Segurança</label>
                            </td>
                            <td>
                                <input type="checkbox" id="Checkbox3" class="checkCarac" /><label for="carac_20">Sim</label>
                            </td>
                            <td>
                                <label for="carac_21" title="carac_21">
                                    Garçom</label>
                            </td>
                            <td>
                                <input type="checkbox" id="Checkbox4" class="checkCarac" /><label for="carac_21">Sim</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label for="carac_20" title="carac_20">
                                    Recepção</label>
                            </td>
                            <td>
                                <input type="checkbox" id="Checkbox5" class="checkCarac" /><label for="carac_20">Sim</label>
                            </td>                            
                        </tr>
                    </table>
                </div>
                <div class="divSplitLine">
                </div>
                <div class="btn btn-netimoveis btn-left voltaInformacao">
                    <div class="texto_botao_">
                        Anterior</div>
                </div>
                <div class="btn btn-netimoveis btn-right GeraTags vaiApresentacao">
                    <div class="texto_botao_">
                        Próximo</div>
                </div>
            </div>
            <!-- Fim do Painel 3 -->






            <!-- Inicio do Painel 4 -->
            <div class="tab-pane" id="tab4" style="margin-left: 30px;">
                <div id="listaInformacoes">
                    <table>                        
                        <tr>
                            <td style="width: 140px;">
                                <label>Data de Início</label>
                            </td>
                            <td>
                                <input type="text" id="txtDataInicio" style="width: 110px;" />
                            </td>
                            <td style="width: 140px;">
                                <label>Data de Término</label>
                            </td>
                            <td>
                                <input type="text" id="txtDataFinal" style="width: 110px;" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px;">
                                <label for="carac_1">
                                    Número de Convidados</label>
                            </td>
                            <td style="width: 140px;">
                                <select id="carac_1" class="comboCarac input-mini">
                                    <option selected="selected" value="0">--</option>
                                    <option selected="selected" value="1">1</option>
                                    <option selected="selected" value="2">2</option>
                                    <option selected="selected" value="3">3</option>
                                    <option selected="selected" value="4">4</option>
                                    <option selected="selected" value="5">5</option>
                                    <option selected="selected" value="6">6</option>
                                    <option selected="selected" value="7">7</option>
                                    <option selected="selected" value="8">8</option>
                                    <option selected="selected" value="9">9</option>
                                    <option selected="selected" value="10">10</option>
                                    <option selected="selected" value="11">11</option>
                                    <option selected="selected" value="12">12</option>
                                    <option selected="selected" value="13">13</option>
                                    <option selected="selected" value="14">14</option>
                                    <option selected="selected" value="15">15</option>
                                </select>
                            </td>
                        </tr>
                        
                        
                    </table>
                </div>
                <div class="divSplitLine">
                </div>
                <div class="btn btn-netimoveis btn-left voltaInformacao">
                    <div class="texto_botao_">
                        Anterior</div>
                </div>
                <div class="btn btn-netimoveis btn-right GeraTags vaiApresentacao">
                    <div class="texto_botao_">
                        Próximo</div>
                </div>
            </div>
            <!-- Fim do Painel 4 -->








        </div>
    </asp:Panel>
    </div>

    

</asp:Content>
