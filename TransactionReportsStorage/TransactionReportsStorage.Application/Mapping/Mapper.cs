using AutoMapper;
using TransactionReportsStorage.Application.Models.DTO;
using TransactionReportsStorage.Application.Paging;
using TransactionReportsStorage.Core.Entities;

namespace TransactionReportsStorage.Application.Mapping
{
    public class Mapper
    {
        private readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Record, RecordDto>();

            cfg.CreateMap<User, UserDto>();

            cfg.CreateMap<Cell, CellDto>();

        }).CreateMapper();

        public PagedList<RecordDto> Map(PagedList<Record> source)
        {
            var dtos = this._mapper.Map<PagedList<RecordDto>>(source);
            dtos.MapList(source);
            return dtos;
        }
    }
}
