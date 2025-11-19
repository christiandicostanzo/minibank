namespace MiniBank.AccountsAndTransactions.Application.Dtos;

public record AuditableEntityDto
(
Guid EntityId,
DateTime CreatedDate,
DateTime UpdatedDate
);


