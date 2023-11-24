using Domain.Context;
using Domain.Entities;
using FluentValidation;
using System.Collections.Generic;

namespace Core.Repositories
{
    public class MotorbikeRepo : BaseMethods<Motorbike>, IMotorbikeRepo
    {
        private readonly MasterContext _context;

        private readonly IEnumerable<IValidator<Motorbike>> _validators;

        public MotorbikeRepo(MasterContext context, IEnumerable<IValidator<Motorbike>> validators) : base(context, validators)
        {
            _context = context;
            _validators = validators;
        }
    }

    public interface IMotorbikeRepo : IBaseMethods<Motorbike>
    {

    }
}
