using System;
using EGMS.BusinessAssociates.Command;
using EGMS.BusinessAssociates.Data.EF;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using Serilog;
using Xunit;

namespace BusinessAssociates.Tests
{
    public class AssociatesTest
    {
        //[Fact]
        //public void CreateAssociate()
        //{
        //    private readonly ILogger<AssociateRepositoryEF> _Logger;
        //    AssociatesContext context = new AssociatesContext();

        //    //AssociateRepositoryEF repository = new AssociateRepositoryEF(context, _Logger,  );
        //    //AssociatesApplicationService appService = new AssociatesApplicationService(repository, );
        //}

        //[Fact]
        //public void Throw_when_too_many_decimal_places()
        //{
        //    Assert.Throws<ArgumentOutOfRangeException>(() =>
        //        Money.FromDecimal(100.123m, "EUR", CurrencyLookup)
        //    );
        //}

    }
}
