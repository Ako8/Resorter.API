namespace Resorter.Application.Entities;

public class Insurance
{
    public bool IsFranchise { get; set; }
    public decimal FranchiseAmount { get; set; }
    public bool IsDeposit { get; set; }
    public decimal DepositAmount { get; set; }
}
