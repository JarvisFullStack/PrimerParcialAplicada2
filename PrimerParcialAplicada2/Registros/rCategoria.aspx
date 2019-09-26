<%@ Page Title="" Language="C#" MasterPageFile="~/MainLayout.Master" AutoEventWireup="true" CodeBehind="rCategoria.aspx.cs" Inherits="PrimerParcialAplicada2.Registros.rCategoria" %>
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
						<asp:textbox type="text" runat="server" class="form-control" ID="IdTextBox" runat="server"></asp:textbox>
						<div class="input-group-append">
							<asp:linkbutton ID="BotonBuscar" runat="server"><i class="fa fa-search"></i></asp:linkbutton>
							
						</div>
					</div>
					<div class="input-group col-md-3 offset-3">
						<div class="input-group-prepend">
							<span class="input-group-text">ID</span>
						</div>
						<asp:textbox type="date" runat="server" class="form-control" ID="fechaPicker" runat="server"></asp:textbox>
						<asp:requiredfieldvalidator runat="server" errormessage="RequiredFieldValidator"></asp:requiredfieldvalidator>
					</div>
				</div>
				<div class="form-group">
					<div class="input-group">
						<div class="input-group-prepend">
							<span class="input-group-text">Nombre</span>
						</div>
						<asp:textbox type="text" runat="server" class="form-control" ID="TextBoxNombre" runat="server"></asp:textbox>
					</div>
				</div>
			</div>
			<div class="card-footer">
				<asp:linkbutton ID="BotonNuevo"  class="btn btn-primary" runat="server">Nuevo</asp:linkbutton>
				<asp:linkbutton ID="BotonGuardar"  class="btn btn-success" runat="server">Guardar</asp:linkbutton>
				<asp:linkbutton ID="BotonEliminar"  class="btn btn-danger" runat="server">Eliminar</asp:linkbutton>
			</div>
		</div>
	</div>
</asp:Content>
