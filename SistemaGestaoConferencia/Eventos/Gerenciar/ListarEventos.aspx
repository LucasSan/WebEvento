<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.Master" AutoEventWireup="true" CodeBehind="ListarEventos.aspx.cs" Inherits="SistemaGestaoConferencia.Eventos.Gerenciar.ListarEventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:ListView ID="lv_evento" runat="server" DataSourceID="ds_evento">
                <LayoutTemplate>
                    <table runat="server" id="table1" class="table table-bordered" width="100%">
                        <tr runat="server" id="itemPlaceholder">
                        </tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <%# HeaderTabela(Eval("NomeCidade").ToString(), Eval("NomeBairro").ToString()) %>
                    <tr style="cursor: pointer;" onclick='abreImovel(<%# Eval("Imovel_Id") %>)' <%# FormataEvento(Eval("Contrato").ToString(), Eval("Status_Id").ToString(), Eval("GrupoImovel_Id").ToString()) %>>
                        <td>
                            <%# Eval("Imovel_Id")%>
                        </td>
                        <td>
                            <span class='<%# corLabel(Eval("Contrato").ToString(), Eval("Status_Id").ToString(), Eval("GrupoImovel_Id").ToString()) %>'>
                                <%# Eval("TransacaoSigla")%></span>
                        </td>
                        <td>
                            <%# Eval("AreaRealPrivativa")%>
                        </td>
                        <td>
                            <%# Endereco(Eval("Descricao").ToString(), Eval("Logradouro").ToString(), Eval("Numero").ToString(), Eval("Complemento").ToString(), Eval("Credenciada_Id").ToString(), Eval("Status_Id").ToString())%>
                        </td>
                        <td>
                            <%# Eval("TipoSigla1")%>
                        </td>
                        <td>
                            <span class='<%# corLabel(Eval("Contrato").ToString(), Eval("Status_Id").ToString(), Eval("GrupoImovel_Id").ToString()) %>'>
                                <%# formataMoeda(Eval("ValorImovel").ToString())%></span>
                        </td>
                        <td>
                            <%# possuiFoto(Eval("NomeArquivo").ToString()) %>
                            <img src="../NovoTema/icon/grafico.png" style="cursor: pointer;" onclick='modalRelatorio(<%# Eval("Imovel_Id")%>)'
                                data-original-title='relatório do imóvel' rel='tooltip' />
                        </td>
                        <script type="text/javascript">
                            if ('<%# Eval("Lat1").ToString() %>' != '') {
                                vetorLat[i] = '<%# Eval("Lat1").ToString() %>';
                                vetorLon[i] = '<%# Eval("Lon1").ToString() %>';
                                vetorCod[i] = '<span style="font-size:13px; font-weight:bold;">Imóvel: <%# Eval("Imovel_Id").ToString() %></span><br><span class="label label-important label_laranja"><%# formataMoeda(Eval("ValorImovel").ToString())%></span><div style="height:5px;" ></div><span class="label"><%# Eval("TipoDsc1")%></span>  <span class="label">para <%# transacaoTexto(Eval("TransacaoSigla").ToString())%></span><br><span style="color:#555; font-size:10px;line-height:11px;"><%# endereco(Eval("Descricao").ToString(), Eval("Logradouro").ToString(), Eval("Numero").ToString(), Eval("Complemento").ToString(), Eval("Credenciada_Id").ToString(), Eval("Status_Id").ToString())%>, <%# Eval("NomeBairro").ToString() %> <%# Eval("NomeCidade").ToString() %></span><br><a href="javascript:abreImovel(<%# Eval("Imovel_Id") %>)">ver imóvel<\a>';
                                vetorLink[i] = '<b>Cód: <%# Eval("Imovel_Id").ToString() %></b><br /><span class="label label-important label_laranja"><%# formataMoeda(Eval("ValorImovel").ToString())%></span>';
                                i++;
                            }
                        </script>
                    </tr>
                    <tr class="tabelaIcones">
                        <td colspan="7">
                            <!-- Flavinho mouse hover na linha de baixo -->
                            <div style="float: left; width: 291px;">
                                <%# prazo(Eval("DataExpira").ToString())%>
                            </div>
                            <div style="float: left; width: 75px; text-align: right;">
                                <div class="btn-group open">
                                    <button class="btn btn-mini dropdown-toggle" data-toggle="dropdown">
                                        <i class="icon-edit"></i>alterar <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu" style="text-align: left;">
                                        <li><a href="javascript://alterastatus" onclick='EditarStatus(<%# Eval("Imovel_Id")%>, <%# Eval("Status_Id")%>)'>
                                            Alterar Status</a></li>
                                        <li><a href="javascript://alteravalor" onclick='AlterarValor(<%# Eval("Imovel_Id")%>, <%# Eval("Status_Id")%>, "<%# formataMoeda(Eval("ValorImovel").ToString())%>")'>
                                            Alterar Valor</a></li>
                                        <%--<li class="divider"></li>
                              <li><a href="#">Separated link</a></li>--%>
                                    </ul>
                                </div>
                            </div>
                            <div style="float: left; width: 255px; text-align: right;">
                                <%--<button class="btn btn-mini" type="button"><i class="icon-edit"></i> status</button>--%>
                                <button class="btn btn-mini BTNEditar" id='edi_<%# Eval("Imovel_Id")%>' type="button">
                                    <i class="icon-pencil"></i>editar</button>
                                <button class="btn btn-mini btCadastrarFotos" id='imo_<%# Eval("Imovel_Id")%>' type="button">
                                    <i class="icon-picture"></i>fotos</button>
                                <button class="btn btn-mini btCadastrarFotosFachada" id='imoFach_<%# Eval("Imovel_Id")%>'
                                    type="button">
                                    <i class="icon-home"></i>fachada</button>
                                <button class="btn btn-mini" type="button" onclick='EditarMapa(<%# Eval("Imovel_Id")%>)'>
                                    <i class="icon-map-marker"></i>mapa</button>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="ds_evento" runat="server" OnSelected="dsEvento_Selected">
            </asp:SqlDataSource>

</asp:Content>