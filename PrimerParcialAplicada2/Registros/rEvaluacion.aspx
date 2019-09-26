<%@ Page Title="" Language="C#" MasterPageFile="~/MainLayout.Master" AutoEventWireup="true" CodeBehind="rEvaluacion.aspx.cs" Inherits="PrimerParcialAplicada2.Registros.rEvaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="container-fluid">
		<div class="card">
			<div class="card-title"> <h2>Registro de Categorias</h2></div>
			<div class="card-body">
				<div class="form-group col-md-3">
					<div class="input-group">
						<div class="input-group-prepend">
							<span class="input-group-text">ID</span>
						</div>
						<asp:textbox type="text" runat="server" class="form-control" ID="IdTextBox"></asp:textbox>
						<div class="input-group-append">
							<asp:linkbutton ID="BotonBuscar" class="btn btn-primary" runat="server" OnClick="BotonBuscar_Click"><i class="fa fa-search"></i></asp:linkbutton>							
						</div>
					</div>
					
				</div>
				<div class="form-group">
					<div class="input-group">
						<div class="input-group-prepend">
							<span class="input-group-text">Nombre Estudiante</span>
						</div>
						<asp:textbox type="text" runat="server" class="form-control" ID="TextBoxNombreEstudiante"></asp:textbox>
						<asp:requiredfieldvalidator runat="server" ControlToValidate="TextBoxNombreEstudiante" errormessage="RequiredFieldValidator"></asp:requiredfieldvalidator>
					</div>
				</div>
				<div class="row">
				<div class="form-group col-md-3">
					<asp:Label runat="server">Categoria</asp:Label>
					<asp:TextBox runat="server" class="form-control" ID="TextBoxNombreCategoria"></asp:TextBox>
					<asp:requiredfieldvalidator runat="server" ControlToValidate="TextBoxNombreCategoria" errormessage="RequiredFieldValidator"></asp:requiredfieldvalidator>
				</div>
				<div class="form-group col-md-3">
					<asp:Label runat="server">Valor</asp:Label>
					<asp:TextBox runat="server" class="form-control" ID="TextBoxValor"></asp:TextBox>
					<asp:requiredfieldvalidator runat="server" ControlToValidate="TextBoxValor" errormessage="RequiredFieldValidator"></asp:requiredfieldvalidator>
				</div>
				<div class="form-group col-md-3">
					<asp:Label runat="server">Logrado</asp:Label>
					<asp:TextBox runat="server" class="form-control" ID="TextBoxLogrado"></asp:TextBox>
					<asp:requiredfieldvalidator runat="server" ControlToValidate="TextBoxLogrado" errormessage="RequiredFieldValidator"></asp:requiredfieldvalidator>
				</div>
				<div class="form-group col-md-3">
					<asp:LinkButton runat="server" ID="BotonAgregarDetalle" OnClick="BotonAgregarDetalle_Click" CssClass="btn btn-info">Agregar</asp:LinkButton>
				</div>
					</div>
				<div class="row">					   
                <asp:ScriptManager ID="ScriptManger" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="table table-responsive col-md-12">
                                <asp:GridView ID="DetalleGridView"
                                    runat="server"
                                    CssClass="table table-condensed table-bordered table-responsive"
                                    CellPadding="4" ForeColor="#333333" GridLines="None"
                                    OnPageIndexChanging="DetalleGridView_PageIndexChanging"
                                    AllowPaging="true" PageSize="5">
                                    <AlternatingRowStyle BackColor="LightBlue" />
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False" HeaderText="Opciones">
                                            <ItemTemplate>
                                                <asp:Button ID="RemoverDetalle" runat="server" CausesValidation="false" CommandName="Select"
                                                    Text="Remover" class="btn btn-danger btn-sm" OnClick="RemoverDetalle_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#EFF3FB" />
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DetalleGridView" />
                    </Triggers>
                </asp:UpdatePanel>
				</div>
			</div>
			<div class="card-footer">
				<asp:linkbutton ID="BotonNuevo"  class="btn btn-primary" runat="server" OnClick="BotonNuevo_Click">Nuevo</asp:linkbutton>
				<asp:linkbutton ID="BotonGuardar"  class="btn btn-success" runat="server" OnClick="BotonGuardar_Click">Guardar</asp:linkbutton>
				<asp:linkbutton ID="BotonEliminar"  class="btn btn-danger" runat="server" OnClick="BotonEliminar_Click">Eliminar</asp:linkbutton>
			</div>
		</div>
	</div>
</asp:Content>
