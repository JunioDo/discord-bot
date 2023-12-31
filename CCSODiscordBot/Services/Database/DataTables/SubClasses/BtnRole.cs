﻿using System;
using Discord;

namespace CCSODiscordBot.Services.Database.DataTables.SubClasses
{
    public class BtnRole
    {
        public BtnRole()
        {
            Name = "";
            Description = "";
            Role = 0;
            RequireVerification = false;
            Emote = null;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public ulong Role { get; set; }
        public bool RequireVerification { get; set; }
        public IEmote? Emote { get; set; }
    }
}

