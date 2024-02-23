using Challenge.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
