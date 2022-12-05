using AutoMapper;
using TransactionReportsStorage.App.Models.DisplayDto;
using TransactionReportsStorage.App.Models.DTO;
using TransactionReportsStorage.App.Paging;
using TransactionReportsStorage.Core.Entities;

namespace TransactionReportsStorage.App.Mapping
{
    public class Mapper
    {
        private readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Record, RecordDisplayDto>()
               .ForMember(r => r.UserName, opt => opt.MapFrom(s => s.User.Name))
               .ForMember(r => r.CellName, opt => opt.MapFrom(s => s.Cell.Name));
        }).CreateMapper();

        public PagedList<RecordDisplayDto> Map(PagedList<Record> source)
        {
            var dtos = this._mapper.Map<PagedList<RecordDisplayDto>>(source);
            dtos.MapList(source);
            return dtos;
        }
    }
}
