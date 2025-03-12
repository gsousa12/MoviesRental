using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Directors.Commands.CreateDirector
{
    public record CreateDirectorResponse (string Id, string Fullname, DateTime CreatedAt, DateTime UpdatedAt)
    {
    }
}
