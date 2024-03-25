using System;
using System.Collections.Generic;

namespace Net_API.Entities;

public partial class UserView
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
}
