﻿using AutoMapper;
using Dominio.Entidade;
using WebApi.Modelos;

namespace WebApi.AutoMapper
{
	public class AutoMapper : Profile
	{
		public AutoMapper( ) 
		{
			CreateMap<ModelViewFrutas,Fruta>();
			CreateMap<ModelCadastroFruta, Fruta>();
		}
	}
}
