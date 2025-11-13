using MiniBank.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBank.AccountsAndTransactions.Application.Dtos;

public record AuditableEntityDto
(
Guid EntityId,
DateTime CreatedDate,
DateTime UpdatedDate
);


