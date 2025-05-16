﻿using System;
using System.Collections.Generic;

namespace VIP_Admin;

public partial class Club
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int IdBoss { get; set; }

    public byte[]? Image { get; set; }

    public int IdType { get; set; }

    public virtual ICollection<Application1> Application1s { get; set; } = new List<Application1>();

    public virtual User IdBossNavigation { get; set; } = null!;

    public virtual TypeOfClub IdTypeNavigation { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
