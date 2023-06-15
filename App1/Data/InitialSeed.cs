using App1.Models;
using System.Collections.Generic;

namespace App1.Data;
public static class InitialSeed
{
    public static IEnumerable<Employee> Seed(string locale, int count)
    {
        var faker = new EmployeeFaker(locale);
        return faker.Generate(count);
    }
}
