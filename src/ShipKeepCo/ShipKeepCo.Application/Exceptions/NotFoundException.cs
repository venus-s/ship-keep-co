using System;

namespace ShipKeepCo.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, int id)
            : base($"Unable to locate {name} with an id of {id}.")
        { }
    }
}
