﻿using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Song.Domain.ValueObjects;

public class SongDescription : SingleValueObject<string>
{
    public SongDescription(string value) : base(value)
    {
    }
}