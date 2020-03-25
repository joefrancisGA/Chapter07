using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGMS.Facilities.Data.EF.TypeConfigurations
{
    static class FacilityTypeConfigurations
    {
        public static void ConfigureTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FacilityDetailConfiguration());
            modelBuilder.ApplyConfiguration(new FacilityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FacilityConfiguration());
        }
    }
}
