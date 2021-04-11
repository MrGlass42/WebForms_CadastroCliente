<%@ Page Title="Cadastro Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForms._Default" EnableEventValidation="false" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .row {
            margin-top: 5%;
        }

        textarea {
            resize: none;
        }
    </style>

    <!-- Conteúdo Interno da Página  -->
    <div class="container" style="margin-bottom: 20%;">
        <div class="row">
            <div class="col-md-12">
                <h3>Clientes</h3>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <button style="float: right" id="btn_modal_cadastro" class="btn btn-info"><i class="fas fa-plus"></i> Adicionar</button>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:Table ID="TabelaClientes" runat="server" CssClass="table">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>Nome</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Telefone</asp:TableHeaderCell>
                            <asp:TableHeaderCell>E-mail</asp:TableHeaderCell>
                            <asp:TableHeaderCell>CPF</asp:TableHeaderCell>
                            <asp:TableHeaderCell></asp:TableHeaderCell>
                            <asp:TableHeaderCell></asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Cadastro Cliente  -->
    <div id="modal_erro" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title"><i class="fas fa-exclamation-triangle"></i> Erro Detectado !</h4>
                </div>
                <div class="modal-body">
                    <span id="span_erro" runat="server"></span>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Entendido !</button>
                </div>
            </div>

        </div>
    </div>

    <!-- Modal Cadastro Cliente  -->
    <div id="modal_cadastro_cliente" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Dados Cliente</h4>
                </div>
                <div class="modal-body">
                    <h3>Dados Pessoais</h3>
                    <input type="hidden" runat="server" id="CampoId" value="0" class="form-control" />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Nome Completo:</label>
                                <input type="text" runat="server" id="CampoNome" class="form-control" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>E-mail:</label>
                                <input type="text" runat="server" id="CampoEmail" class="form-control"/>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Telefone:</label>
                                <input type="text" runat="server" id="CampoTelefone" class="form-control" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>RG:</label>
                                <input type="text" runat="server" id="CampoRG" class="form-control" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>CPF:</label>
                                <input type="text" runat="server" id="CampoCPF" class="form-control" />
                            </div>
                        </div>
                    </div>

                    <h3>Dados Endereço</h3>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>CEP:</label>
                                <asp:TextBox autopostback="true" runat="server" CssClass="form-control" ID="CampoCEP" OnTextChanged="CampoCEP_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Rua:</label>
                                <input type="text" runat="server" id="CampoRua" class="form-control" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Bairro:</label>
                                <input type="text" runat="server" id="CampoBairro" class="form-control" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Número:</label>
                                <input type="text" runat="server" id="CampoNumero" class="form-control" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Cidade:</label>
                                <input type="text" runat="server" id="CampoCidade" class="form-control" />
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Estado:</label>
                                <select runat="server" id="CampoEstado" runat="server" class="form-control">
                                    <option value="">Selecione o Estado</option>
                                    <option value="AC">Acre</option>
                                    <option value="AL">Alagoas</option>
                                    <option value="AP">Amapá</option>
                                    <option value="AM">Amazonas</option>
                                    <option value="BA">Bahia</option>
                                    <option value="CE">Ceará</option>
                                    <option value="DF">Distrito Federal</option>
                                    <option value="ES">Espírito Santo</option>
                                    <option value="GO">Goiás</option>
                                    <option value="MA">Maranhão</option>
                                    <option value="MT">Mato Grosso</option>
                                    <option value="MS">Mato Grosso do Sul</option>
                                    <option value="MG">Minas Gerais</option>
                                    <option value="PA">Pará</option>
                                    <option value="PB">Paraíba</option>
                                    <option value="PR">Paraná</option>
                                    <option value="PE">Pernambuco</option>
                                    <option value="PI">Piauí</option>
                                    <option value="RJ">Rio de Janeiro</option>
                                    <option value="RN">Rio Grande do Norte</option>
                                    <option value="RS">Rio Grande do Sul</option>
                                    <option value="RO">Rondônia</option>
                                    <option value="RR">Roraima</option>
                                    <option value="SC">Santa Catarina</option>
                                    <option value="SP">São Paulo</option>
                                    <option value="SE">Sergipe</option>
                                    <option value="TO">Tocantins</option>
                                    <option value="EX">Estrangeiro</option>
                                </select>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <label>Complemento:</label>
                            <textarea id="CampoComplemento" runat="server" class="form-control" rows="5"></textarea>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" id="btnSalvarCliente" runat="server" class="btn btn-success" onserverclick="btnSalvarCliente_Click"><i class="fas fa-save"></i> Salvar</button>
                </div>
            </div>

        </div>
    </div>



    <script src="Scripts/Default.js" type="text/javascript"></script>

</asp:Content>
