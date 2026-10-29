using lab13;

var query = SqlBuilder
    .Select<User>(SqlDialect.PostgreSql)
    .OrderByDescending(u => u.RegistrationDate)
    .Take(10);

Console.WriteLine(query.CommandText);

foreach (var parameter in query.CommandParameters)
{
    Console.WriteLine($"{parameter.Key} = {parameter.Value}");
}

var query1 = SqlBuilder
    .Select<User>(SqlDialect.MsSql)
    .OrderByDescending(u => u.RegistrationDate)
    .Take(10);

Console.WriteLine("\n" + query1.CommandText);

foreach (var parameter in query1.CommandParameters)
{
    Console.WriteLine($"{parameter.Key} = {parameter.Value}");
}    

var query2 = SqlBuilder
    .Select<User>(SqlDialect.PostgreSql)
    .OrderBy(u => u.Name)
    .Take(5);

Console.WriteLine("\n" + query2.CommandText);

foreach (var parameter in query2.CommandParameters)
{
    Console.WriteLine($"{parameter.Key} = {parameter.Value}");
}