using Application.Services;
using AutoMapper;
using Common.Responses;
using Common.Responses.Wrappers;
using MediatR;

namespace Application.Features.Accounts.Queries
{
    public class GetAccountByIdQuery : IRequest<IBankResponse<AccountResponse>>
    {
        public int AccountId { get; set; }
    }

    public class GetAccountByIdQueryHnadler : IRequestHandler<GetAccountByIdQuery, IBankResponse<AccountResponse>>
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly IMapper _mapper;

        public GetAccountByIdQueryHnadler(IBankAccountService bankAccountService, IMapper mapper)
        {
            _bankAccountService = bankAccountService;
            _mapper = mapper;
        }

        public async Task<IBankResponse<AccountResponse>> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _bankAccountService.GetBankAccountByIdAsync(request.AccountId);
            if (account is not null)
            {
                var mappedAccount = _mapper.Map<AccountResponse>(account);

                return await BankResponse<AccountResponse>.SuccessAsync(mappedAccount);
            }
            return await BankResponse<AccountResponse>.FailAsync("Account does not exists.");
        }
    }
}
