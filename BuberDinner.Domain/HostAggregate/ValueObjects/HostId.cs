﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
    private HostId(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static HostId Create(UserId userId)
    {
        return new HostId($"Host_{userId.Value}");
    }

    public static HostId Create(string hostId)
    {
        return new HostId(hostId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}