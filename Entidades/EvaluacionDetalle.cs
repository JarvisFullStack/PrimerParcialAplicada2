using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	[Serializable]
	public class EvaluacionDetalle
	{
		[Key]
		public int Id_Evaluacion_Detalle { get; set; }
		public string Categoria { get; set; }
		public decimal Valor { get; set; }
		public decimal Logrado { get; set; }

		public EvaluacionDetalle(int id_Evaluacion_Detalle, string categoria, decimal valor, decimal logrado)
		{
			Id_Evaluacion_Detalle = id_Evaluacion_Detalle;
			Categoria = categoria;
			Valor = valor;
			Logrado = logrado;
		}

		

		public EvaluacionDetalle()
		{
		}
	}
}
