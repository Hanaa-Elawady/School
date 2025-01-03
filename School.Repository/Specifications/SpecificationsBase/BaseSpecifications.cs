﻿using System.Linq.Expressions;

namespace School.Repository.Specifications.SpecificationsBase
{
    public class BaseSpecifications<T> : ISpecifications<T>
	{
		public BaseSpecifications(Expression<Func<T, bool>> _criteria)
		{
			Criteria = _criteria;
		}

		public Expression<Func<T, bool>> Criteria { get; }

		public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

		public Expression<Func<T, object>> OrderBy { get; private set; }

		public Expression<Func<T, object>> OrderByDescending { get; private set; }

		public int Take { get; private set; }

		public int Skip { get; private set; }

		public bool IsPaginated { get; private set; }
		protected void AddInclude(Expression<Func<T, object>> includeExpression)
			=> Includes.Add(includeExpression);

		protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
			=> OrderBy = orderByExpression;
		protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
			=> OrderBy = orderByDescendingExpression;

		protected void ApplyPagination(int skip, int take)
		{
			Take = take;
			Skip = skip;
			IsPaginated = true;
		}
	}
}
