using ArkhamHorrorTracker.Database.ArkhamDbJson;
using ArkhamHorrorTracker.Database.ArkhamDbJson.Schema.Dto;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
