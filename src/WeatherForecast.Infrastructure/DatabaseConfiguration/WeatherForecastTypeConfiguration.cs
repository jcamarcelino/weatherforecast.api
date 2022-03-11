using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Infrastructure.DatabaseConfiguration
{
    public class WeatherForecastTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.WeatherForecast> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(t => t.Date)
                    .IsRequired()
                    .HasDefaultValueSql("GetDate()");

            builder.Property(t => t.Local)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Rain)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(t => t.Humidity)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(t => t.Wind)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(t => t.TemperatureC)
                .IsRequired();

            builder.Property(t => t.TemperatureF)
                .IsRequired();

            builder.Property(t => t.Summary)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
