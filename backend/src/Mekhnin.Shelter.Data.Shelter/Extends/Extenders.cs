using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mekhnin.Shelter.Data.Shelter.Extends
{
	public static class Extenders
	{
		public static ReferenceCollectionBuilder<TEntity, TRelatedEntity> WithRequired<TEntity, TRelatedEntity>(
			this CollectionNavigationBuilder<TEntity, TRelatedEntity> source,
			Expression<Func<TRelatedEntity, TEntity>> navigationExpression
		) where TEntity : class where TRelatedEntity : class
			=> source.WithOne(navigationExpression).IsRequired();

		public static ReferenceNavigationBuilder<TEntity, TRelatedEntity> HasOptional<TEntity, TRelatedEntity>(
			this EntityTypeBuilder<TEntity> source,
			Expression<Func<TEntity, TRelatedEntity>> navigationExpression = null
		) where TEntity : class where TRelatedEntity : class
			=> source.HasOne(navigationExpression);

		public static ReferenceReferenceBuilder<TEntity, TRelatedEntity> WithRequired<TEntity, TRelatedEntity>(
			this ReferenceNavigationBuilder<TEntity, TRelatedEntity> source,
			Expression<Func<TRelatedEntity, TEntity>> navigationExpression
		) where TEntity : class where TRelatedEntity : class
			=> source.WithOne(navigationExpression).IsRequired();

		public static ReferenceCollectionBuilder<TEntity, TRelatedEntity> WillCascadeOnDelete<TEntity, TRelatedEntity>(
			this ReferenceCollectionBuilder<TEntity, TRelatedEntity> source,
			bool value
		) where TEntity : class where TRelatedEntity : class
			=> source.OnDelete(value ? DeleteBehavior.Cascade : DeleteBehavior.Restrict);

		public static PropertyBuilder<decimal?> HasPrecision(this PropertyBuilder<decimal?> builder, int precision, int scale)
			=> builder.HasColumnType($"decimal({precision},{scale})");

		public static PropertyBuilder<decimal> HasPrecision(this PropertyBuilder<decimal> builder, int precision, int scale)
			=> builder.HasColumnType($"decimal({precision},{scale})");

		public static string ToSnakeCase(this string input)
		{
			if (string.IsNullOrEmpty(input)) { return input; }

			var startUnderscores = Regex.Match(input, @"^_+");
			return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
		}
    }
}
