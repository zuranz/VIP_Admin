using System;
using System.Collections.Generic;

namespace VIP_Admin;

public partial class StatusApplication
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Application1> Application1s { get; set; } = new List<Application1>();
}
