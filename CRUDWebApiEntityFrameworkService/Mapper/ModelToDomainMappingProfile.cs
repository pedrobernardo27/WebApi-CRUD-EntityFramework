using AutoMapper;
using CRUDWebApiEntityFrameworkRepository.Models;

namespace CRUDWebApiEntityFrameworkService.Mapper
{
    public class ModelToDomainMappingProfile : Profile
    {
        public ModelToDomainMappingProfile()
        {
            CreateMap<EmailRequest, Email>();
            CreateMap<PessoaRequest, Pessoa>();
            CreateMap<PessoaAtualizarRequest, Pessoa>();
            CreateMap<EnderecoRequest, Endereco>();
        }
    }

    public class DomainToModelMappingProfile : Profile
    {
        public DomainToModelMappingProfile()
        {
            CreateMap<Email, EmailRequest>();
            CreateMap<Pessoa, PessoaRequest>();
            CreateMap<Pessoa, PessoaAtualizarRequest>();
            CreateMap<Endereco, EnderecoRequest>();
        }
    }
}
