using AutoMapper;
using MiniBank.AccountsAndTransactions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBank.AccountsAndTransactions.Application.Dtos.AutoMapperProfiles;

public class DepositAccountProfile : Profile
{
    public DepositAccountProfile()
    {
        CreateMap<DepositAccount, DepositAccountDto>()
            .ConstructUsing(src => new DepositAccountDto(
                src.EntityId,
                src.CreatedDate,
                src.UpdatedDate,
                src.Number,
                src.AccountNumber,
                src.AccountType.ToString(),
                src.CustomerId,
                src.Status.ToString(),
                src.ClosedDate,
                src.Balance,
                src.Currency,
                src.BranchId,
                src.LastActivityDate
            ));
    }
}


