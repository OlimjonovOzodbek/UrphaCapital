﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrphaCapital.Application.ViewModels;

namespace UrphaCapital.Application.UseCases.Results.Commands
{
    public class DeleteResultCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
    }
}
