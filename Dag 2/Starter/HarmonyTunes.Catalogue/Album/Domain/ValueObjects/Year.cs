using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Album.Domain.ValueObjects;

public class Year : ValueObject
{
    public int Value { get; init; }

    public Year(int year)
    {
        if (year < 1900) throw new ArgumentOutOfRangeException(nameof(year));
        Value = year;
    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}

public class Age
{
    public int Value { get; }

    public Age(int age)
    {
        if (age < 0) throw new ArgumentOutOfRangeException(nameof(age));
        Value = age;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        
        return Value == ((Age)obj).Value;
    }
}

public class UserId{}
public class Name{}
public class Address{}

public interface INameValidator{}
public interface INameQueryService{}

public class InvalidNameException : Exception
{
    public InvalidNameException(string message) : base(message)
    {
    }
}

public class NameAlreadyExistsException : Exception
{
    public NameAlreadyExistsException(string message) : base(message)
    {
    }
}

public class User {
    public UserId Id { get; }
    public Name Name { get; }
    public Age Age { get; }
    public Address Address { get; }

    public User(UserId id, Name name, Age age, Address address)
    {
        Id = id;
        Name = name;
        Age = age;
        Address = address;
    }

    public void ChangeName(Name name, INameValidator nameValidator, INameQueryService nameQueryService)
    {
        if (!nameValidator.IsValid(name))
        {
            throw new InvalidNameException("Invalid name");
        }

        if (nameQueryService.Exists(name))
        {
            throw new NameAlreadyExistsException("Name already exists");
        }

        ...
    }
}