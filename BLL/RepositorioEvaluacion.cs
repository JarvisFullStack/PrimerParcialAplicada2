using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class RepositorioEvaluacion : RepositorioBase<Evaluacion>
	{

		public override bool Guardar(Evaluacion entity)
		{
			bool ok = false;
			Contexto contexto = new Contexto();
			try
			{
				decimal total = 0;
				Contexto contextoDetalle = new Contexto();
				foreach(EvaluacionDetalle item in entity.EvaluacionDetalle)
				{
					total += item.Logrado;
					contextoDetalle.Entry(item).State = System.Data.Entity.EntityState.Added;
				}
				contextoDetalle.SaveChanges();
				contextoDetalle.Dispose();
				entity.Total = total;
				if (contexto.Set<Evaluacion>().Add(entity) != null)
				{
					contexto.SaveChanges();
					ok = true;
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				contexto.Dispose();
			}

			return ok;
		}

		public override bool Modificar(Evaluacion entity)
		{
			bool ok = false;
			Contexto contexto = new Contexto();
			decimal paraRestar = 0;
			decimal paraSumar = 0;
			decimal paraModificar = 0;
			try
			{
				//Buscando anteriores
				using (Contexto contextoAnterior = new Contexto())
				{
					Evaluacion evaluacionAnterior = this.Buscar(entity.EvaluacionId);			
					foreach(EvaluacionDetalle item in evaluacionAnterior.EvaluacionDetalle)
					{
						//Si la entidad actual no contiene el detalle anterior entonces esta eliminado..
						if(evaluacionAnterior.EvaluacionDetalle.Find(x=>x.Id_Evaluacion_Detalle == item.Id_Evaluacion_Detalle) == null)
						{
							paraRestar += item.Logrado;
							contextoAnterior.Entry(item).State = System.Data.Entity.EntityState.Deleted;
						} 
						
					}

					foreach(EvaluacionDetalle item in entity.EvaluacionDetalle)
					{
						if (item.Id_Evaluacion_Detalle == 0)
						{
							paraSumar += item.Logrado;
							contextoAnterior.Entry(item).State = System.Data.Entity.EntityState.Added;
						}
						else
						{
							decimal valor = item.Logrado - this.Buscar(entity.EvaluacionId).EvaluacionDetalle.Find(x=>x.Id_Evaluacion_Detalle == item.Id_Evaluacion_Detalle).Logrado;
							paraModificar += item.Logrado;
							contextoAnterior.Entry(item).State = System.Data.Entity.EntityState.Modified;
						}
					}

					contextoAnterior.SaveChanges();
					contextoAnterior.Dispose();


				}

				//modificando el total: restando, sumando, modificando
				entity.Total += paraSumar;
				entity.Total -= paraRestar;
				entity.Total += paraModificar;
				contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
				if (contexto.SaveChanges() > 0)
				{
					ok = true;
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				contexto.Dispose();
			}

			return ok;
		}

		public override Evaluacion Buscar(int id)
		{
			Evaluacion entity;
			Contexto contexto = new Contexto();
			try
			{
				entity = contexto.Set<Evaluacion>().Find(id);
				if(entity != null)
				{
					entity.EvaluacionDetalle.Count();
					entity.EvaluacionDetalle.ToList();
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				contexto.Dispose();
			}

			return entity;
		}

		public override List<Evaluacion> GetList(Expression<Func<Evaluacion, bool>> expression)
		{
			List<Evaluacion> list = new List<Evaluacion>();
			Contexto contexto = new Contexto();
			try
			{
				list = contexto.Set<Evaluacion>().Where(expression).ToList();
				foreach(var item in list)
				{
					item.EvaluacionDetalle.Count();
					item.EvaluacionDetalle.ToList();
					
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				contexto = new Contexto();
			}
			return list;
		}

		public override bool Eliminar(int id)
		{
			bool ok = false;
			Contexto contexto = new Contexto();
			try
			{
				Evaluacion entity = _context.Set<Evaluacion>().Find(id);
								
				if(entity!=null)
				{
					Contexto contextoAnterior = new Contexto();
					foreach(var item in entity.EvaluacionDetalle)
					{						
						contextoAnterior.Entry(item).State = System.Data.Entity.EntityState.Deleted;
						
					}					
					contextoAnterior.SaveChanges();
					contextoAnterior.Dispose();
					contexto.Set<Evaluacion>().Remove(entity);
				}
				
				if (contexto.SaveChanges() > 0)
				{
					ok = true;
				}
				
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				this._context.Dispose();
			}

			return ok;
		}
	}
}
