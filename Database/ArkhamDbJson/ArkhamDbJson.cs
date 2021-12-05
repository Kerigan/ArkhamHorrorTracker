using ArkhamHorrorTracker.Database.ArkhamDbJson.Schema.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkhamHorrorTracker.Database.ArkhamDbJson
{
    public class ArkhamDbJson
    {
        public List<CycleDto> GetArkhamDb()
        {
            FileProcessor fileProcessor = new();
            List<CycleDto> result = fileProcessor.ProcessCycleJsonFromPath("./arkhamdb-json-data/cycles.json");

            if (result == null
                || !result.Any())
                return null;

            List<PackDto> packs = fileProcessor.ProcessPackJsonFromPath("./arkhamdb-json-data/packs.json");

            foreach (CycleDto cycle in result)
            {
                cycle.Packs = packs.Where(p => p.CycleCode == cycle.Code).ToList();

                if (cycle.Packs == null
                    || !cycle.Packs.Any())
                    break;

                foreach (PackDto pack in cycle.Packs)
                {
                    var path = String.Format("./arkhamdb-json-data/pack/{0}/{1}.json", pack.CycleCode, pack.Code);
                    if (fileProcessor.CheckForFile(path))
                        pack.Cards = fileProcessor.ProcessCardJsonFromPath(path);
                }
            }

            return result;
        }
    }
}
