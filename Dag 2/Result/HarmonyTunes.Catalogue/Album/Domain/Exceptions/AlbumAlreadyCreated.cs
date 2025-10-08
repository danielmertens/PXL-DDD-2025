﻿using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.Exceptions;

public class AlbumAlreadyCreated : DomainRuleViolation
{
    public AlbumAlreadyCreated()
        : base("Can't call create on an album that's already created.")
    {

    }
}
