using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceMVC.Infrastructure.Configurations
{
    internal class ConferenceEntityTypeConfiguration : 
        IEntityTypeConfiguration<ConferenceMVC.Domain.Entities.Conference>
    {
        public void Configure(EntityTypeBuilder<ConferenceMVC.Domain.Entities.Conference>) { }

    }
}
