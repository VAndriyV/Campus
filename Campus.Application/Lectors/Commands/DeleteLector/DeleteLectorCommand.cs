using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Application.Lectors.Commands.DeleteLector
{
    public class DeleteLectorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
