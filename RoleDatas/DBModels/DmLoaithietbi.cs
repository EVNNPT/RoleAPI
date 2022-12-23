using System;
using System.Collections.Generic;

namespace RoleDatas.DBModels;

public partial class DmLoaithietbi
{
    public string Maloaithietbi { get; set; } = null!;

    public string? Tenloaithietbi { get; set; }

    public string? Ghichu { get; set; }

    public decimal? Stt { get; set; }

    public virtual ICollection<NvFiledinhkem> NvFiledinhkems { get; } = new List<NvFiledinhkem>();
}
