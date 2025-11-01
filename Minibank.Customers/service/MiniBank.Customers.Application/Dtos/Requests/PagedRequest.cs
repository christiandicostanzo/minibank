using MediatR;
using MiniBank.CustomersSrv.Application.Dtos;
using MiniBank.CustomersSrv.Application.Dtos.Responses;
using MiniBank.Pagination;
using MiniBank.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBank.Customers.Application.Dtos.Requests;

public class PagedRequest
{
    public int Offset { get; set; }
    public int Limit { get; set; }
}

public class CustomerFilterRequest : PagedRequest, IRequest<Result<PagedResult<CustomerDto>>>
{
    public string? FirstName { get; set; }

}