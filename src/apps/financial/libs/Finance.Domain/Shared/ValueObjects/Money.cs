﻿
using Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Shared.ValueObjects
{
  public class Money : ValueObject
  {
    public decimal Value { get; set; }
    public string Currency { get; private set; }

    public Money()
    {

    }

    public Money(decimal amount, string currency)
    {
      ArgumentNullException.ThrowIfNull(amount);
      ArgumentNullException.ThrowIfNull(currency);

      Value = amount;
      Currency = currency;
    }


    public static bool operator <(Money obj1, Money obj2)
    {
      ThrowIfCurrencyIsNotMatch(obj1, obj2);

      return obj1.Value < obj2.Value;
    }

    public static bool operator <=(Money obj1, Money obj2)
    {
      ThrowIfCurrencyIsNotMatch(obj1, obj2);

      return obj1.Value <= obj2.Value;
    }



    public static bool operator >=(Money obj1, Money obj2)
    {
      ThrowIfCurrencyIsNotMatch(obj1, obj2);

      return obj1.Value >= obj2.Value;
    }

    public static bool operator >(Money obj1, Money obj2)
    {
      ThrowIfCurrencyIsNotMatch(obj1, obj2);

      return obj1.Value > obj2.Value;
    }

    public static Money operator +(Money obj1, Money obj2)
    {
      ThrowIfCurrencyIsNotMatch(obj1, obj2);

      return new Money(obj1.Value + obj2.Value, obj1.Currency);
    }


    public static Money operator -(Money obj1, Money obj2)
    {
      ThrowIfCurrencyIsNotMatch(obj1, obj2);

      return new Money(obj1.Value - obj2.Value, obj1.Currency);
    }

    private static void ThrowIfCurrencyIsNotMatch(Money obj1, Money obj2)
    {
      if (obj1.Currency != obj2.Currency) throw new Exception("Currency Is Not Match");
    }

    public static Money Zero(string currency)
    {
      return new Money(0, currency);
    }

    public override string ToString() => $"{Value}{Currency}";


    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
      yield return Currency.Trim();
    }
  }
}
