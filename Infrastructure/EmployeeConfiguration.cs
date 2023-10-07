using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Task031023.Domain;

namespace Task031023.Infrastructure
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(firstName => firstName.FirstName);
            builder.Property(lastName => lastName.LastName);
            builder.Property(surnName => surnName.SurnName);
            builder.Property(data => data.DateOfBirth);
            builder.Property(gender => gender.Gender).HasConversion(gender => gender.ToString(), gender => (Gender)Enum.Parse(typeof(Gender), gender));
            builder.HasIndex(e => new
            {
                e.Gender,
                e.LastName
            });
            builder.Ignore(age => age.Age);
        }
    }
}
