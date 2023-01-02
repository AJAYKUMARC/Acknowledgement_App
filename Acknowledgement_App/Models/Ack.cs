using System;
using System.Collections.Generic;

namespace Acknowledgement_App.Models;

public partial class Ack
{
    public int Id { get; set; }

    public string ApplicationFor { get; set; } = null!;

    public string HallticketNo { get; set; } = null!;

    public DateTime AppliedOn { get; set; }

    public DateTime? DateOfIssue { get; set; }

    public int NoOfCertificates { get; set; }

    public string ChallanNo { get; set; } = null!;

    public decimal Amount { get; set; }

    public string? Remark { get; set; }
}
