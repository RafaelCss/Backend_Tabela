﻿using AutoMapper;
using Dominio.Entidade;
using Dominio.Interfaces.IServico;
using Dominio.Servico;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Modelos;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FrutaController : ControllerBase
	{
		private readonly IServicoFruta _servicoFruta;
		private readonly IMapper _mapper;

		public FrutaController(IServicoFruta servicoFruta,IMapper mapper) 
		{
			_servicoFruta= servicoFruta;
			_mapper= mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetFrutas([FromQuery] ModelViewFrutas query)
		{
			var busca = await _servicoFruta.BuscarTodos();
			var mapper = _mapper.Map<List<ModelViewFrutas>>(busca);
			return Ok(mapper);
		}

		[HttpPost]
		public async Task<IActionResult> InsertFrutas([FromBody] ModelCadastroFruta query)
		{
			if(!ModelState.IsValid) return BadRequest();
			var mapperFruta = _mapper.Map<Fruta>(query);
			 await _servicoFruta.Cadastar(mapperFruta);

			return Ok("Cadastrado");
		}
	}
}
