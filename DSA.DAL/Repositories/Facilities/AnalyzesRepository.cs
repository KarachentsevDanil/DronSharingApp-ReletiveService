﻿using LinqKit;
using Microsoft.EntityFrameworkCore;
using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;
using System.Collections.Generic;
using System.Linq;

namespace RCS.DAL.Repositories
{
    public class AnalyzesRepository : Repository<Analyzes>, IAnalyzesRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public AnalyzesRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public CollectionResult<Analyzes> GetAnalyzesByParams(AnalyzesFilterParams parameters)
        {
            var appointments = GetAllAnalyzes();

            FillAnalyzesQueryParams(parameters);

            appointments = appointments.Where(parameters.Expression);

            var totalCount = appointments.Count();

            var result = appointments
                .OrderBy(x => x.Name)
                .Skip(parameters.Skip)
                .Take(parameters.Take)
                .AsNoTracking()
                .ToList();

            var appointmentsResult = new CollectionResult<Analyzes>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return appointmentsResult;
        }

        private IQueryable<Analyzes> GetAllAnalyzes()
        {
            return _dbContext.Analyzes
                .Include(t => t.Department)
                .ThenInclude(t => t.Facility)
                .AsQueryable();
        }

        private void FillAnalyzesQueryParams(AnalyzesFilterParams filterParams)
        {
            var predicate = PredicateBuilder.New<Analyzes>(t => t.Department.FacilityId == filterParams.FacilityId);

            if (!string.IsNullOrWhiteSpace(filterParams.Term))
            {
                predicate = predicate.And(t => t.Name.Contains(filterParams.Term));
            }

            filterParams.Expression = predicate;
        }

        public IEnumerable<Analyzes> GetAnalyzesByTerm(int facilityId, string term)
        {
            return GetAllAnalyzes()
                .Where(t => t.Department.FacilityId == facilityId && t.Name.Contains(term))
                .ToList();
        }
    }
}
