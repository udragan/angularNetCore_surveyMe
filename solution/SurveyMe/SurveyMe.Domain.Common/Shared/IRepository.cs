using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace udragan.netCore.SurveyMe.Domain.Common.Shared
{
	/// <summary>
	/// Generic repository interface.
	/// </summary>
	/// <typeparam name="TEntity">The entity type.</typeparam>
	public interface IRepository<TEntity>
		where TEntity : Entity
	{
		/// <summary>
		/// Gets all entities.
		/// </summary>
		/// <returns>
		/// A collection of all available entities in the repository.
		/// </returns>
		IEnumerable<TEntity> GetAll();

		/// <summary>
		/// Gets the entity by its identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>
		/// The entity with provided identifier.
		/// </returns>
		TEntity Get(long id);

		/// <summary>
		/// Finds all entities that satisfy the specified predicate.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>
		/// A collection of entities that satisfy the predicate.
		/// </returns>
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

		/// <summary>
		/// Adds the specified entity to the repository.
		/// </summary>
		/// <param name="entity">The entity to create.</param>
		/// <returns>
		/// The entity that is created.
		/// </returns>
		TEntity Add(TEntity entity);

		/// <summary>
		/// Removes the entity from repository.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Remove(TEntity entity);
	}
}
