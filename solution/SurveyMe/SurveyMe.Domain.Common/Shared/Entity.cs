using System;

namespace udragan.netCore.SurveyMe.Domain.Common.Shared
{
	/// <summary>
	/// Abstract base class for all entities in domain model.
	/// </summary>
	public abstract class Entity
	{
		#region Members

		private int? _requestedHashCode;

		#endregion

		#region Properties

		/// <summary>
		/// Gets the entity identifier.
		/// </summary>
		public long Id { get; protected set; }

		#endregion

		#region Methods

		/// <summary>
		/// Determines whether this entity instance is transient.
		/// </summary>
		/// <returns>
		///   <c>true</c> if this instance is transient; otherwise, <c>false</c>.
		/// </returns>
		public bool IsTransient()
		{
			return Id == default(long);
		}

		/// <summary>
		/// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
		/// <returns>
		///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is Entity))
			{
				return false;
			}

			if (Object.ReferenceEquals(this, obj))
			{
				return true;
			}

			if (GetType() != obj.GetType())
			{
				return false;
			}

			Entity item = (Entity)obj;

			if (item.IsTransient() || IsTransient())
			{
				return false;
			}

			return item.Id == Id;
		}

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode()
		{
			if (!IsTransient())
			{
				if (!_requestedHashCode.HasValue)
				{
					_requestedHashCode = Id.GetHashCode() ^ 31;
				}

				return _requestedHashCode.Value;
			}

			return base.GetHashCode();
		}

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>
		/// The result of the operator.
		/// </returns>
		public static bool operator ==(Entity left, Entity right)
		{
			if (Object.Equals(left, null))
			{
				return (Object.Equals(right, null)) ? true : false;
			}

			return left.Equals(right);
		}

		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>
		/// The result of the operator.
		/// </returns>
		public static bool operator !=(Entity left, Entity right)
		{
			return !(left == right);
		}

		#endregion
	}
}
