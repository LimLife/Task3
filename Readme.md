
До оптимизации:3000ms
Изменено с:
var result = Context.Employees.AsNoTracking()
    .Where(e => e.Gender == Gender.Male)
    .AsEnumerable()
    .Where(e => e.LastName.StartsWith("F"))
    .ToList();
Изменено на:
  var result = await Context.Employees.AsNoTracking()
                 .Where(e => e.Gender == Gender.Male && e.LastName.StartsWith("F"))
                 .ToListAsync();
Добавленны индексы для Gender
После оптимизации: 1081 ms 

Добавлены индексы для LastName
После оптимизации: 900-976 ms
