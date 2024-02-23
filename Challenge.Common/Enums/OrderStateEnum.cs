using Challenge.Common.Attributes;

namespace Challenge.Common.Enums
{
    public enum OrderStateEnum
    {
        [StringValue("01")]
        PENDING,

        [StringValue("02")]
        COMPLETE,

        [StringValue("03")]
        INVOICED,
    }
}
