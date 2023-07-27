using Application.Services;
using AutoMapper;
using Common.Responses;
using Common.Responses.Wrappers;
using MediatR;

namespace Application.Features.Transactions.Queries
{
    public class GetTransactionsOnAccountQuery : IRequest<IBankResponse<List<TransactionResponse>>>
    {
        public string AccountNumber { get; set; }
    }

    public class GetTransactionsOnAccountQueryHandler : IRequestHandler<GetTransactionsOnAccountQuery, IBankResponse<List<TransactionResponse>>>
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public GetTransactionsOnAccountQueryHandler(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        public async Task<IBankResponse<List<TransactionResponse>>> Handle(GetTransactionsOnAccountQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionService.GetTransactionsByAccountNumberAsync(request.AccountNumber);
            if (transactions is not null && transactions.Count > 0)
            {
                var mappedTransaction = _mapper.Map<List<TransactionResponse>>(transactions);
                return await BankResponse<List<TransactionResponse>>.SuccessAsync(mappedTransaction);
            }
            return await BankResponse<List<TransactionResponse>>.FailAsync("Account has no transactions.");
        }
    }
}
