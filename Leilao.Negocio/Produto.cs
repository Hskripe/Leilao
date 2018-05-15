using Leilao.Entidades;
using Leilao.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leilao.Negocio
{
	public class Produto
	{

		public List<PRODUTO> Listar()
		{
			using (var ctx = new LEILAOEntities())
			{
				return ctx.PRODUTO.ToList();
			}
		}

		public PRODUTO BuscaID(int ID)
		{
			PRODUTO pes = new PRODUTO();

			if (ID > 0)
			{
				using (var ctx = new LEILAOEntities())
				{
					pes = ctx.PRODUTO.FirstOrDefault(x => x.ID == ID);
				}
			}

			if (pes == null)
				pes = new PRODUTO();

			return pes;
		}

		public bool Salvar(PRODUTO PRODUTO)
		{
			int salvo = 0;
			try
			{
				using (var ctx = new LEILAOEntities())
				{
					ctx.PRODUTO.Add(PRODUTO);
					salvo = ctx.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return salvo > 0;
		}

		public bool Editar(PRODUTO PRODUTO)
		{
			int salvo = 0;
			try
			{
				if (PRODUTO.ID > 0)
				{

					using (var ctx = new LEILAOEntities())
					{
						if (ctx.PRODUTO.Any(x => x.ID == PRODUTO.ID))
						{
							ctx.PRODUTO.Add(PRODUTO);
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
						if (ctx.PRODUTO.Any(x => x.ID == ID))
						{
							ctx.PRODUTO.Remove(BuscaID(ID));
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
