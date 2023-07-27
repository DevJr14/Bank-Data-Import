using Application.Services;
using AutoMapper;
using Common.Responses;
using Common.Responses.Wrappers;
using MediatR;

namespace Application.Features.Accounts.Queries
{
    public class GetAllAccountsQuery : IRequest<IBankResponse<List<AccountResponse>>>
    {
    }

    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, IBankResponse<List<AccountResponse>>>
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly IMapper _mapper;

        public GetAllAccountsQueryHandler(IBankAccountService bankAccountService, IMapper mapper)
        {
            _bankAccountService = bankAccountService;
            _mapper = mapper;
        }

        public async Task<IBankResponse<List<AccountResponse>>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _bankAccountService.GetAllAccountsAsync();
            if (accounts is not null && accounts.Count > 0)
            {
                var mappedAccounts = _mapper.Map<List<AccountResponse>>(accounts);
                return await BankResponse<List<AccountResponse>>.SuccessAsync(mappedAccounts);
            }
            return await BankResponse<List<AccountResponse>>.FailAsync("No Bank Accounts were found.");
        }
    }
}
