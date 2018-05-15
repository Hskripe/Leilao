
using Leilao.Entidades;
using Leilao.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leilao.Negocio
{
	public class Pessoa
	{
		public List<PESSOA> Listar()
		{
			using (var ctx = new LEILAOEntities())
			{
				return ctx.PESSOA.ToList();
			}
		}

		public PESSOA BuscaID(int ID)
		{
			PESSOA pes = new PESSOA();

			if (ID > 0)
			{
				using (var ctx = new LEILAOEntities())
				{
					pes = ctx.PESSOA.FirstOrDefault(x => x.ID == ID);
				}
			}

			if (pes == null)
				pes = new PESSOA();

			return pes;
		}

		public bool Salvar(PESSOA pessoa)
		{
			int salvo = 0;
			try
			{
				using (var ctx = new LEILAOEntities())
				{
					ctx.PESSOA.Add(pessoa);
					salvo = ctx.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return salvo > 0;
		}

		public bool Editar(PESSOA pessoa)
		{
			int salvo = 0;
			try
			{
				if (pessoa.ID > 0)
				{

					using (var ctx = new LEILAOEntities())
					{
						if (ctx.PESSOA.Any(x => x.ID == pessoa.ID))
						{
							ctx.PESSOA.Add(pessoa);
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
						if (ctx.PESSOA.Any(x => x.ID == ID))
						{
							ctx.PESSOA.Remove(BuscaID(ID));
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
