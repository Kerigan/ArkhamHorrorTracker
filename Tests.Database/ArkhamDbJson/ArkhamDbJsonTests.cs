using ArkhamHorrorTracker.Database.ArkhamDbJson.Schema.Dto;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Tests.Database.ArkhamDbJson.ArkhamDbJsonTests
{
    public class GetArkhamDb
    {
        [Fact]
        public void GetArkhamDb_should_return_list_CycleDto()
        {
            ArkhamHorrorTracker.Database.ArkhamDbJson.ArkhamDbJson test = new ArkhamHorrorTracker.Database.ArkhamDbJson.ArkhamDbJson();
            var result = test.GetArkhamDb();

            result
                .Should()
                .NotBeNull();

            result
                .Should()
                .BeOfType<List<CycleDto>>();

            result
                .Should()
                .HaveCount(13);
        }
    }
}
