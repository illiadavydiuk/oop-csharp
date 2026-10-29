namespace lab13;

using System.Linq.Expressions;

public static class SqlBuilder
{
    public static SqlSelectBuilder<T> Select<T>(
        SqlDialect dialect = SqlDialect.PostgreSql)
    {
        return new SqlSelectBuilder<T>(dialect);
    }
}

public class SqlSelectBuilder<T>
{
    private readonly SqlDialect _dialect;
    private string? _orderBy;
    private bool _descending;
    private int? _take;

    public SqlSelectBuilder(SqlDialect dialect)
    {
        _dialect = dialect;
    }

    public SqlSelectBuilder<T> OrderBy(
        Expression<Func<T, object>> expression)
    {
        _orderBy = GetPropertyName(expression);
        _descending = false;

        return this;
    }

    public SqlSelectBuilder<T> OrderByDescending(
        Expression<Func<T, object>> expression)
    {
        _orderBy = GetPropertyName(expression);
        _descending = true;

        return this;
    }

    public SqlSelectBuilder<T> Take(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        _take = count;
        return this;
    }

    public string CommandText
    {
        get
        {
            string table = QuoteIdentifier(typeof(T).Name);
            string sql = "SELECT ";

            if (_dialect == SqlDialect.MsSql && _take.HasValue)
                sql += "TOP (@take) ";

            sql += $"* FROM {table}";

            if (_orderBy != null)
            {
                sql += $" ORDER BY {QuoteIdentifier(_orderBy)}";

                if (_descending)
                    sql += " DESC";
                else
                    sql += " ASC";
            }

            if (_dialect == SqlDialect.PostgreSql && _take.HasValue)
                sql += " LIMIT @take";

            return sql;
        }
    }

    public IReadOnlyDictionary<string, object?> CommandParameters
    {
        get
        {
            var parameters = new Dictionary<string, object?>();

            if (_take.HasValue)
                parameters["@take"] = _take.Value;

            return parameters;
        }
    }

    private string QuoteIdentifier(string name)
    {
        return _dialect == SqlDialect.PostgreSql
            ? $"\"{name}\""
            : $"[{name}]";
    }

    private static string GetPropertyName(
        Expression<Func<T, object>> expression)
    {
        Expression body = expression.Body; //беремо після стрілки

        if (body is UnaryExpression unary)
            body = unary.Operand;

        if (body is not MemberExpression member ||
            member.Member is not System.Reflection.PropertyInfo) // перевірка на те чи передано властивість
        {
            throw new ArgumentException(
                "Expression must select a property.");
        }

        return member.Member.Name;
    }
}