﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Queries.Invoice
{
    public class InvoiceGetListQuery : IRequest<IEnumerable<Repository.Entities.Invoice>>
    {
    }
}