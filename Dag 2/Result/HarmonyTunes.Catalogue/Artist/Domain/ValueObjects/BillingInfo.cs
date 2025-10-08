namespace HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;

public record BillingInfo(string BankAccount, string Bank, string RatePerListen)
{
}