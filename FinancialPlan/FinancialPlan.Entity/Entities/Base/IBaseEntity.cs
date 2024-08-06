namespace FinancialPlan.Entity.Entities.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        bool IsDeleted { get; set; }

        DateTime InsertedAt { get; set; }

        DateTime UpdatedAt { get; set; }
    }
}
