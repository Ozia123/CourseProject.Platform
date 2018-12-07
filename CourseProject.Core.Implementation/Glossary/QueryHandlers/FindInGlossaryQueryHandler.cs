using AutoMapper;
using CourseProject.Core.Contracts.Glossary.Models;
using CourseProject.Core.Contracts.Glossary.Queries;
using CourseProject.Domain.EF;
using CourseProject.Domain.Entities;
using CourseProject.Infrastructure.Common.Queries;
using CourseProject.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Core.Implementation.Glossary.QueryHandlers
{
    public class FindInGlossaryQueryHandler 
        : IAsyncQueryHandler<FindInGlossaryQuery, GlossaryFindResultModel>
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;

        public FindInGlossaryQueryHandler(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GlossaryFindResultModel> HandleAsync(FindInGlossaryQuery query)
        {
            var searchKeys = GetSearchKeys(query);

            var foundItems = await context.Patterns
                .Where(pattern => searchKeys.Any(searchKey => pattern.Match.Contains(searchKey)))
                .Select(pattern => pattern.GlossaryItem)
                .GroupBy(glossaryItem => glossaryItem.GlossaryItemId)
                .OrderByDescending(groupped => groupped.Count())
                .Select(groupped => groupped.First())
                .ToListAsync();

            return GetFindResult(query, foundItems);
        }

        private string[] GetSearchKeys(FindInGlossaryQuery query)
        {
            return query.SearchString.Split(null as string[], StringSplitOptions.RemoveEmptyEntries);
        }

        private GlossaryFindResultModel GetFindResult(FindInGlossaryQuery query, List<GlossaryItem> items)
        {
            if (items.Count == 0)
            {
                throw new NotFoundException($"No result found for query {query.SearchString}");
            }

            return new GlossaryFindResultModel
            {
                SearchString = query.SearchString,
                Items = items.Select(item => mapper.Map<GlossaryItemModel>(item)).ToList()
            };
        }
    }
}
