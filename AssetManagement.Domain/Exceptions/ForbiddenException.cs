﻿using System.Net;
using AssetManagement.Domain.Exceptions.Base;

namespace AssetManagement.Domain.Exceptions;
public class ForbiddenException : BaseException
{
    private const int _statusCode = (int)HttpStatusCode.Forbidden;
    private const string? _title = "Forbidden.";
    private const string? _type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3";

    public ForbiddenException()
    {
        StatusCode = _statusCode;
        Title = _title;
        Type = _type;
    }

    public ForbiddenException(string? message) : base(message)
    {
        StatusCode = _statusCode;
        Title = _title;
        Type = _type;
    }
}