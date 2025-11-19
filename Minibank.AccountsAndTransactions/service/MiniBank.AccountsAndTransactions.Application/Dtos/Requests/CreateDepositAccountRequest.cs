namespace MiniBank.AccountsAndTransactions.Application.Dtos.Requests;

public record CreateDepositAccountRequest
(
int number,
string account_number,
int account_type,
Guid customer_id,
string currency,
Guid branch_id
)
{

    //[JsonPropertyName("number")]
    //public int Number
    //{
    //    get => number;
    //}

    //[JsonPropertyName("account_number")]
    //public string AccountNumber
    //{
    //    get => accountNumber;
    //}

    //[JsonPropertyName("account_type")]
    //public int AccountType
    //{
    //    get => accountType;
    //}

    //[JsonPropertyName("customer_id")]
    //public Guid CustomerId
    //{
    //    get => customerId;
    //}

    //[JsonPropertyName("currency")]
    //public string Currency
    //{
    //    get => currency;
    //}

    //[JsonPropertyName("branch_id")]
    //public Guid BranchId
    //{
    //    get => branchId;
    //}

}

