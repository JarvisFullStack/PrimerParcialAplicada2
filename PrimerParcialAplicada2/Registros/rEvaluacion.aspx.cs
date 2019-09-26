using BLL;
using Entidades;
using PrimerParcialAplicada2.Soporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcialAplicada2.Registros
{
	public partial class rEvaluacion : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack) {
				Evaluacion itemevaluacion = new Evaluacion();
				int id = Utilidades.ToInt(Request.QueryString["id"]);				
				LlenarViewState(itemevaluacion, itemevaluacion.EvaluacionDetalle);
				if(id > 0)
				{
					Evaluacion evaluacion = new RepositorioEvaluacion().Buscar(id);
					if(evaluacion != null)
					{
						LlenarViewState(evaluacion, evaluacion.EvaluacionDetalle);
						LlenarGrid();
						Utilidades.ShowToastr(this, "Registro encontrado", "Busqueda Exitosa!", "success");
					} else
					{
						Utilidades.ShowToastr(this, "Registro no encontrado", "Busqueda Fallida", "warning");
						LimpiarViewState();
					}
				}
			}

			/*else
			{
				Evaluacion evaluacion = new Evaluacion();
				LlenarViewState(evaluacion, evaluacion.EvaluacionDetalle);
			}*/
		}

		private void LlenarGrid()
		{
			this.DetalleGridView.DataSource = (List<EvaluacionDetalle>)ViewState["Detalle"];
			this.DetalleGridView.DataBind();
		}

		private void LlenarViewState(Evaluacion evaluacion, List<EvaluacionDetalle> detalle)
		{
			ViewState["Evaluacion"] = evaluacion;
			ViewState["Detalle"] = detalle;
		}

		protected void BotonNuevo_Click(object sender, EventArgs e)
		{
			Limpiar();
		}

		private void Limpiar()
		{
			this.IdTextBox.Text = string.Empty;
			this.TextBoxNombreEstudiante.Text = string.Empty;
			this.TextBoxNombreCategoria.Text = string.Empty;
			this.TextBoxValor.Text = "0";
			this.TextBoxLogrado.Text = "0";
			LimpiarViewState();
		}

		private void LimpiarViewState()
		{
			ViewState["Evaluacion"] = new Evaluacion();
			ViewState["Detalle"] = new List<EvaluacionDetalle>();
			this.DetalleGridView.DataSource = new List<EvaluacionDetalle>();
			this.DetalleGridView.DataBind();
		}

		protected void BotonGuardar_Click(object sender, EventArgs e)
		{
			Evaluacion evaluacion = LlenaClase();
			RepositorioEvaluacion repositorio = new RepositorioEvaluacion();
			bool paso = true;
			if(evaluacion.EvaluacionId == 0)
			{

				paso = repositorio.Guardar(evaluacion);				
			} else
			{
				paso = repositorio.Modificar(evaluacion);
			}

			if(paso)
			{
				Utilidades.ShowToastr(this, "Transaccion Exitosa", "Exito", "success");				
				this.Limpiar();
				this.LimpiarViewState();
			} else
			{

				Utilidades.ShowToastr(this, "Transaccion Erronea", "Error", "error");			
			}

		}

		private Evaluacion LlenaClase()
		{

			Evaluacion evaluacion =(Evaluacion) ViewState["Evaluacion"];
			evaluacion.EvaluacionId = Utilidades.ToInt(this.IdTextBox.Text);
			evaluacion.NombreEstudiante = this.TextBoxNombreEstudiante.Text;
			evaluacion.EvaluacionDetalle = (List<EvaluacionDetalle>)ViewState["Detalle"];
			LlenarViewState(evaluacion, evaluacion.EvaluacionDetalle);
			return evaluacion;
		}


		protected void BotonEliminar_Click(object sender, EventArgs e)
		{
			int id = Utilidades.ToInt(this.IdTextBox.Text);
			if(id>0)
			{
				RepositorioEvaluacion repositorio = new RepositorioEvaluacion();
				Evaluacion evaluacion = repositorio.Buscar(id);
				if(evaluacion != null)
				{
					bool paso = repositorio.Eliminar(evaluacion.EvaluacionId);
					if(paso)
					{
						Utilidades.ShowToastr(this, "Registro Eliminado Correctamente", "Transaccion Exitosa", "info");
						LimpiarViewState();
						Limpiar();
					} else
					{
						Utilidades.ShowToastr(this, "Error", "Error", "danger");

					}
				
				}
				{
					Utilidades.ShowToastr(this, "Registro no Existente", "Error", "warning");
				} 
			}
		}

	

		protected void RemoverDetalle_Click(object sender, EventArgs e)
		{

		}

		protected void DetalleGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{

		}

		protected void BotonAgregarDetalle_Click(object sender, EventArgs e)
		{
			List <EvaluacionDetalle> detalle = (List<EvaluacionDetalle>)ViewState["Detalle"];
			if(ValidarNumericos())
			{
				EvaluacionDetalle nuevoItem  = GetItemDetalle();
				detalle.Add(nuevoItem);
				ViewState["Detalle"] = detalle;
				LlenarGrid();
				Utilidades.ShowToastr(this, "Agregado Correctamente", "Correcto");
			} else
			{
				Utilidades.ShowToastr(this, "Ay Epelate", "error", "warning");
			}
			

		}

		private bool ValidarNumericos()
		{
			bool paso = true;
			try
			{
				Convert.ToDecimal(this.TextBoxLogrado.Text);
			}catch(Exception)
			{
				paso = false;
			}

			if (Utilidades.ToDecimal(this.TextBoxValor.Text) == 0)
			{
				paso = false;
			}

			return paso;

		}

		private EvaluacionDetalle GetItemDetalle()
		{
			EvaluacionDetalle item = new EvaluacionDetalle();
			item.Categoria = TextBoxNombreCategoria.Text;
			item.Valor = Utilidades.ToDecimal(this.TextBoxValor.Text);
			item.Logrado = Utilidades.ToDecimal(this.TextBoxLogrado.Text);
			return item;
		}

		protected void BotonBuscar_Click(object sender, EventArgs e)
		{
			int id = Utilidades.ToInt(this.IdTextBox.Text);
		}
	}
}