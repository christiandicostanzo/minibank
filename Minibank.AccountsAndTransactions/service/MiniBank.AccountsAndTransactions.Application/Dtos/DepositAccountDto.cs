using Consul;
using MiniBank.AccountsAndTransactions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MiniBank.AccountsAndTransactions.Application.Dtos;

public record DepositAccountDto
{

    public DepositAccountDto
    (
        Guid entityId,
        DateTime createdDate,
        DateTime updatedDate,
        int number,
        string accountNumber,
        string accountType,
        Guid customerId,
        string status,
        DateTime? closedDate,
        decimal balance,
        string currency,
        Guid branchId,
        DateTime lastActivityDate
    )
    {
        EntityId = entityId;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        Number = number;
        AccountNumber = accountNumber;
        AccountType = accountType;
        CustomerId = customerId;
        Status = status;
        ClosedDate = closedDate;
        Balance = balance;
        Currency = currency;
        BranchId = branchId;
        LastActivityDate = lastActivityDate;
    }


    [JsonPropertyName("entity_id")]
    public Guid EntityId { get; init; }

    [JsonPropertyName("created_date")]
    public DateTime CreatedDate { get; init; }

    [JsonPropertyName("updated_date")]
    public DateTime UpdatedDate { get; init; }

    [JsonPropertyName("number")]
    public int Number { get; init; }

    [JsonPropertyName("account_number")]
    public string AccountNumber { get; init; }

    [JsonPropertyName("account_type")]
    public string AccountType { get; init; }

    [JsonPropertyName("customer_id")]
    public Guid CustomerId { get; init; }

    [JsonPropertyName("status")]
    public string Status { get; init; }

    [JsonPropertyName("closed_date")]
    public DateTime? ClosedDate { get; init; }

    [JsonPropertyName("balance")]
    public decimal Balance { get; init; }

    [JsonPropertyName("currency")]
    public string Currency { get; init; }

    [JsonPropertyName("branch_id")]
    public Guid BranchId { get; init; }

    [JsonPropertyName("last_activity_date")]
    public DateTime LastActivityDate { get; init; }

}

