using System;
using System.Collections.Generic;

namespace RoleDatas.DBModels;

public partial class NvFiledinhkem
{
    public string Maloaithietbi { get; set; } = null!;

    public string Madt { get; set; } = null!;

    public string? Duongdan { get; set; }

    public string? Tenfile { get; set; }

    public virtual DmLoaithietbi MaloaithietbiNavigation { get; set; } = null!;
}
