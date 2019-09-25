using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
	{
		internal Contexto _context;

		public RepositorioBase()
		{
			_context = new Contexto();
		}

		public virtual bool Eliminar(int id)
		{
			bool ok = false;
			try
			{
				T entity = _context.Set<T>().Find(id);
				_context.Set<T>().Remove(entity);

				if (_context.SaveChanges() > 0)
				{
					ok = true;
				}
				_context.Dispose();
			}
			catch (Exception)
			{
				throw;
			}

			return ok;
		}

		public void Dispose()
		{
			_context.Dispose();
		}

		public virtual T Buscar(int id)
		{
			T entity;
			try
			{
				entity = _context.Set<T>().Find(id);
			}
			catch (Exception)
			{
				throw;
			}

			return entity;
		}

		public virtual List<T> GetList(Expression<Func<T, bool>> expression)
		{
			List<T> list = new List<T>();
			try
			{
				list = _context.Set<T>().Where(expression).ToList();
			}
			catch (Exception)
			{
				throw;
			}
			return list;
		}



		public virtual bool Modificar(T entity)
		{
			bool ok = false;
			try
			{
				_context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
				if (_context.SaveChanges() > 0)
				{
					ok = true;
				}
			}
			catch (Exception)
			{
				throw;
			}

			return ok;
		}

		public virtual bool Guardar(T entity)
		{
			bool ok = false;
			try
			{
				if (_context.Set<T>().Add(entity) != null)
				{
					_context.SaveChanges();
					ok = true;
				}
			}
			catch (Exception)
			{
				throw;
			}

			return ok;
		}

		
	}
}
