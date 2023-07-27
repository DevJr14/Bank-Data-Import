using AutoMapper;
using Common.Responses;
using Domain;

namespace Application
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Transaction, TransactionResponse>();
            CreateMap<Account, AccountResponse>();
        }
    }
}
