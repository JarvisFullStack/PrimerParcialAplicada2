using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	[Serializable]
	public class Evaluacion
	{
		[Key]
		public int EvaluacionId { get; set; }
		public string NombreEstudiante { get; set; }
		public decimal Total { get; set; }
		public virtual List<EvaluacionDetalle> EvaluacionDetalle { get; set; }

		public Evaluacion(int evaluacionId, string estudiante, decimal total)
		{
			EvaluacionId = evaluacionId;			
			Total = total;
		}

		public Evaluacion()
		{
			this.EvaluacionDetalle = new List<EvaluacionDetalle>();
		}

		public void AgregarDetalle(int idEvaluacionDetalle, string categoria, decimal valor, decimal logrado)
		{
			this.EvaluacionDetalle.Add(new EvaluacionDetalle(idEvaluacionDetalle, categoria, valor, logrado));
		}
	}
}
