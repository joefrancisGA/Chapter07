using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EGMS.BusinessAssociates.Data.EF.TypeConfigurations
{
    class AssociateTypeConfigurations
    {
        public static void ConfigureTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AssociateConfiguration());
            modelBuilder.ApplyConfiguration(new OperatingContextConfiguration());
        }
    }
}
