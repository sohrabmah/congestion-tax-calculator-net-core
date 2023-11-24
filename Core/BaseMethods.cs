using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using Domain.Context;
using FluentValidation;
using Domain.Entities;
using Core.Exceptions;

namespace Core
{
    public class BaseMethods<T> : IBaseMethods<T> where T : BaseEntity
    {
        private readonly MasterContext _context;

        private readonly IEnumerable<IValidator<T>> _validators;

        public BaseMethods(MasterContext context, IEnumerable<IValidator<T>> validators)
        {
            _context = context;

            _validators = validators;
        }

        private void ValidationHandler(T baseEntity)
        {
            var context = new ValidationContext<T>(baseEntity);

            var validationResults =
            _validators.Select(v =>
                v.Validate(context));

            var failures = validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Any())
                throw new Core.Exceptions.ValidationException(failures);
        }

        public int Create(T entity)
        {
            ValidationHandler(entity);

            _context.Set<T>().Add(entity);

            _context.SaveChanges();

            return entity.Id;
        }

        public int Delete(int id)
        {
            var entity = Read(id);

            _context.Remove<T>(entity);

            _context.SaveChanges();

            return entity.Id;
        }

        public void DeleteRange(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);

            _context.SaveChanges();
        }

        public T Read(int id)
        {
            var result = _context.Set<T>().Find(id);

            if (result != null)
                return result;

            throw new NotFoundExeption(nameof(T), id);
        }

        public IQueryable<T> ReadAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> ReadAll(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public int Update(T t)
        {
            ValidationHandler(t);

            var local = Read(t.Id);

            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(t).State = EntityState.Modified;

            _context.SaveChanges();

            return t.Id;
        }
    }
}
