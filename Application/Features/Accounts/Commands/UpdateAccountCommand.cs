using Application.Services;
using Common;
using Common.Responses.Wrappers;
using MediatR;

namespace Application.Features.Accounts.Commands
{
    public class UpdateAccountCommand : IRequest<IBankResponse<bool>>
    {
        public int AccountId { get; set; }
        public AccountType AccountType { get; set; }
    }

    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, IBankResponse<bool>>
    {
        private readonly IBankAccountService _bankAccountService;

        public UpdateAccountCommandHandler(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        public async Task<IBankResponse<bool>> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var accountInDb = await _bankAccountService.GetBankAccountByIdAsync(request.AccountId);
            if (accountInDb is not null)
            {
                accountInDb.AccountType = request.AccountType;
                var updatedAccount = await _bankAccountService.UpdateAccountAsync(accountInDb);

                if (updatedAccount.AccountType == request.AccountType)
                {
                    return await BankResponse<bool>.SuccessAsync("Account Type changed successfully.");
                }
                return await BankResponse<bool>.FailAsync("Failed to change Account Type.");
            }
            return await BankResponse<bool>.FailAsync("Bank Account not found.");
        }
    }
}
