
using Leilao.Data;
using Leilao.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leilao.Negocio
{
	public class Lance
	{
		public List<LANCES> Listar()
		{
			using (var ctx = new LEILAOEntities())
			{
				return ctx.LANCES.ToList();
			}
		}

		public LANCES BuscaID(int ID)
		{
			LANCES pes = new LANCES();

			if (ID > 0)
			{
				using (var ctx = new LEILAOEntities())
				{
					pes = ctx.LANCES.FirstOrDefault(x => x.ID == ID);
				}
			}

			if (pes == null)
				pes = new LANCES();

			return pes;
		}

		public bool Salvar(LANCES LANCES)
		{
			int salvo = 0;
			try
			{
				using (var ctx = new LEILAOEntities())
				{
					ctx.LANCES.Add(LANCES);
					salvo = ctx.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return salvo > 0;
		}

		public bool Editar(LANCES LANCES)
		{
			int salvo = 0;
			try
			{
				if (LANCES.ID > 0)
				{

					using (var ctx = new LEILAOEntities())
					{
						if (ctx.LANCES.Any(x => x.ID == LANCES.ID))
						{
							ctx.LANCES.Add(LANCES);
							salvo = ctx.SaveChanges();
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return salvo > 0;
		}

		public bool Remover(int ID)
		{
			int removido = 0;
			try
			{
				if (ID > 0)
				{
					using (var ctx = new LEILAOEntities())
					{
						if (ctx.LANCES.Any(x => x.ID == ID))
						{
							ctx.LANCES.Remove(BuscaID(ID));
							removido = ctx.SaveChanges();
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return removido > 0;
		}
	}
}
