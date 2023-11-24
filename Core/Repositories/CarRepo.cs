using Domain.Context;
using Domain.Entities;
using FluentValidation;
using System.Collections.Generic;

namespace Core.Repositories
{
    public class CarRepo : BaseMethods<Car>, ICarRepo
    {
        private readonly MasterContext _context;

        private readonly IEnumerable<IValidator<Car>> _validators;

        public CarRepo(MasterContext context, IEnumerable<IValidator<Car>> validators) : base(context, validators)
        {
            _context = context;
            _validators = validators;
        }
    }

    public interface ICarRepo : IBaseMethods<Car>
    {

    }
}
