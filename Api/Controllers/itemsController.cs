using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Core.Entities;
using Core.interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class itemsController : BaseApiController
    {
        private readonly IGenericRepository<ProductItem> _itemsRepo;
        private readonly IMapper _mapper;
        public itemsController(IGenericRepository<ProductItem> itemsRepo, IMapper mapper)
        {
            _mapper = mapper;
            _itemsRepo = itemsRepo;

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductItem>>> GetItems()
        {
            var specification = new ItemsWithSubCategorySpcification();
            return Ok(await _itemsRepo.ListAsync(specification));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductItemDto>> GetItem(int id)
        {
            var specification = new ItemsWithSubCategorySpcification(id);
            var item = await _itemsRepo.GetEntityWithSpecification(specification);
            return Ok(_mapper.Map<ProductItem , ProductItemDto>(item));
        }

    }
}