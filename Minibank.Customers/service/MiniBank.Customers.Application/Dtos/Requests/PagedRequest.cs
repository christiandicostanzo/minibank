using MediatR;
using MiniBank.CustomersSrv.Application.Dtos;
using MiniBank.CustomersSrv.Application.Dtos.Responses;
using MiniBank.Pagination;
using MiniBank.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MiniBank.Customers.Application.Dtos.Requests;

public class PagedRequest
{
    public int? Offset { get; set; }
    public int? Limit { get; set; }
}

public class CustomerFilterRequest : PagedRequest, IRequest<Result<PagedResult<CustomerDto>>>
{
    //[JsonPropertyName("first_name")]
    public string? first_name { get; set; }

    //[JsonPropertyName("document_id")]
    public int? document_id { get; set; }
    //[JsonPropertyName("document_type")]
    public int? document_type { get; set; }
}