﻿namespace HarmonyTunes.Ports.Catalogue.Adapters.Database.Shared;

public class AggregateEntity
{
    public string AggregateId { get; set; } = string.Empty;

    public int CurrentVersion { get; set; }

    public byte[] TimeStamp { get; set; } = Array.Empty<byte>();
}
