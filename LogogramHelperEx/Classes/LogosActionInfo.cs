using System.Collections.Generic;
using System.Linq;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Utility;
using ECommons.DalamudServices;
using Lumina.Excel.GeneratedSheets;

namespace LogogramHelperEx;

public class LogosActionInfo
{
    public string Name { get; set; } = null!;
    public uint IconID { get; set; }
    public string Type { get; set; } = null!;
    public SeString Description { get; set; } = null!;
    public string Cast { get; set; } = null!;
    public string Recast { get; set; } = null!;
    public List<List<(uint, int)>> Recipes { get; set; } = null!;
    public List<uint> Roles { get; set; } = null!;

    public static List<LogosActionInfo> Load()
    {
        List<LogosActionInfo> ret = [new() { Name = "无" }];
        foreach (var magiaAction in Svc.Data.GetExcelSheet<EurekaMagiaAction>()!.Skip(1))
        {
            var action = magiaAction.Action.Value!;
            ret.Add(new()
            {
                Name = action.Name.ToDalamudString().TextValue.Replace("文理", string.Empty).Replace("的记忆", string.Empty).Replace("的加护", string.Empty),
                IconID = action.Icon,
                Type = action.ActionCategory.Value!.Name.ToDalamudString().TextValue,
                Description = Svc.Data.GetExcelSheet<ActionTransient>()!.GetRow(action.RowId)!.Description.ToDalamudString(),
                Cast = action.Cast100ms == 0 ? "即时" : $"{action.Cast100ms / 10.0f:F2}s",
                Recast = $"{action.Recast100ms / 10.0f:F2}s",
                Roles = AllRoles[(int)magiaAction.RowId - 1],
                Recipes = AllRecipes[(int)magiaAction.RowId - 1]
            });
        }
        return ret;
    }
    // IconId
    private static readonly List<List<uint>> AllRoles = [[62582], [62581], [62582, 62584, 62586, 62587], [62581], [62582], [62584, 62586, 62587], [62581], [62582], [62584, 62586, 62587], [62144], [62144], [62144], [62144], [62144], [62144], [62144], [62144], [62144], [62144], [62584, 62586, 62587], [62581, 62584, 62586], [62582, 62584, 62586, 62587], [62581, 62582], [62144], [62144], [62144], [62144], [62144], [62144], [62581], [62581, 62584, 62586, 62587], [62581, 62584, 62586, 62587], [62584, 62586, 62587], [62144], [62581, 62584, 62586, 62587], [62581, 62584, 62586, 62587], [62581, 62584, 62586, 62587], [62582, 62584, 62586, 62587], [62581, 62584, 62586, 62587], [62582, 62587], [62582, 62584, 62586, 62587], [62582, 62584, 62586, 62587], [62144], [62581], [62582], [62582], [62582], [62582, 62587], [62581, 62584], [62586], [62584, 62586, 62587], [62587], [62584], [62586], [62581], [62582]];

    // uint MagiciteItemId
    // int Quantity
    private static readonly List<List<List<(uint, int)>>> AllRecipes = [[[(24015, 1)]], [[(24016, 1)]], [[(24017, 1)]], [[(24018, 1)], [(24017, 1), (24022, 1)], [(24017, 1), (24035, 1)], [(24017, 1), (24037, 2)], [(24035, 3)]], [[(24019, 1)], [(24015, 1), (24036, 1)], [(24015, 1), (24033, 2)], [(24034, 3)]], [[(24020, 1)], [(24016, 1), (24028, 1)], [(24016, 3)]], [[(24029, 2)]], [[(24020, 1), (24034, 1)], [(24020, 1), (24035, 1)], [(24017, 1), (24033, 1), (24035, 1)]], [[(24020, 1), (24018, 1)], [(24016, 1), (24037, 1), (24020, 1)]], [[(24810, 1)], [(24025, 1), (24029, 1)], [(24029, 3)], [(24025, 3)]], [[(24021, 1)], [(24016, 1), (24018, 1)], [(24015, 1), (24016, 1), (24017, 1)]], [[(24022, 1)]], [[(24023, 1)], [(24036, 1), (24022, 1)]], [[(24038, 1), (24027, 1)], [(24038, 1), (24031, 2)], [(24015, 1), (24024, 1), (24038, 1)], [(24027, 3)]], [[(24020, 1), (24032, 1)], [(24032, 3)]], [[(24024, 1)]], [[(24024, 1), (24026, 1)], [(24024, 3)], [(24015, 1), (24024, 2)]], [[(24025, 2)], [(24030, 2), (24025, 1)]], [[(24025, 1)], [(24028, 2)]], [[(24026, 1)], [(24031, 1), (24019, 1)], [(24015, 1), (24024, 1), (24031, 1)]], [[(24018, 1), (24026, 1)], [(24032, 2)], [(24026, 3)]], [[(24027, 1)], [(24036, 1), (24019, 1)], [(24036, 3)], [(24031, 3)]], [[(24028, 1)]], [[(24029, 1)], [(24019, 1), (24023, 1)]], [[(24030, 1), (24029, 1)], [(24016, 1), (24030, 1), (24028, 1)]], [[(24030, 1)]], [[(24031, 1)]], [[(24032, 1)], [(24033, 1), (24020, 1)], [(24016, 2), (24033, 1)]], [[(24032, 1), (24023, 1)], [(24021, 1), (24026, 1)]], [[(24020, 1), (24025, 1)], [(24016, 1), (24037, 1), (24025, 1)]], [[(24036, 1), (24027, 1)], [(24033, 1), (24036, 1), (24028, 1)]], [[(24033, 1)]], [[(24034, 1)], [(24033, 1), (24019, 1)], [(24033, 3)], [(24038, 3)]], [[(24035, 1)], [(24022, 1), (24023, 1)], [(24022, 3)], [(24023, 3)]], [[(24032, 1), (24019, 1)], [(24034, 2)], [(24033, 2), (24019, 1)]], [[(24031, 1), (24034, 1)], [(24028, 1), (24034, 1)], [(24033, 2), (24028, 1)]], [[(24036, 1)]], [[(24037, 1)]], [[(24038, 1)]], [[(24020, 1), (24018, 1), (24019, 1)]], [[(24022, 1), (24018, 1), (24035, 1)]], [[(24018, 1), (24023, 1), (24035, 1)]], [[(24022, 1), (24019, 1), (24023, 1)]], [[(24031, 1), (24020, 1), (24026, 1)]], [[(24015, 1), (24019, 1), (24034, 1)]], [[(24015, 1), (24027, 2)]], [[(24019, 1), (24027, 2)]], [[(24813, 1)], [(24021, 1), (24019, 1), (24035, 1)]], [[(24812, 1)], [(24020, 1), (24032, 1), (24018, 1)]], [[(24811, 1)], [(24020, 1), (24021, 1), (24026, 1)]], [[(24810, 2)], [(24029, 1), (24027, 1), (24810, 1)]], [[(24015, 1), (24019, 1), (24813, 1)], [(24018, 1), (24035, 1), (24813, 1)]], [[(24020, 2), (24812, 1)], [(24030, 1), (24032, 1), (24812, 1)]], [[(24025, 1), (24026, 1), (24811, 1)], [(24028, 1), (24031, 1), (24811, 1)]], [[(24017, 1), (24037, 1), (24812, 1)], [(24022, 1), (24021, 1), (24812, 1)]], [[(24036, 1), (24038, 1), (24813, 1)]]];

}
