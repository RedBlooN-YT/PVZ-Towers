global using BTD_Mod_Helper.Extensions;
using MelonLoader;
using BTD_Mod_Helper;
using PVZTowers;
using BTD_Mod_Helper.Api.ModOptions;
using PVZTowers.Peashooter.Upgrades;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using PVZTowers.BonkChoyTower.Upgrades;
using HarmonyLib;

[assembly: MelonInfo(typeof(PVZTowers.PVZTowers), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace PVZTowers;

public class PVZTowers : BloonsTD6Mod
{
    public override void OnTowerUpgraded(Tower tower, string upgradeName, TowerModel newBaseTowerModel)
    {
        if (tower.towerModel.name.Contains("BonkChoy"))
        {
            if (upgradeName.Contains("Paragon"))
            {
                tower.AddMutator<BonkChoyMutator>(isParagonMutator: true);
            }
        }
        if (tower.towerModel.GetTowerSet().Contains("PVZ"))
        {
            if (upgradeName.Contains("Paragon"))
            {
                patches.TowerHealth[tower.Id] = 500f;
            }
        }
    }
    public static readonly ModSettingBool Mode = new ModSettingBool(true)
    {
        displayName = "PVZ Mode",
        description = "If disabled you simply place plants like normal towers. If enabled you can place plants on the track and bloons will have to stop and eat them, tower health is shown as their cash earned value (pops for sunflower)",
        requiresRestart = true,
        button = true,
        disabledText = "Normal",
        enabledText = "PVZ",
        icon = "Button"
    };
    public static readonly ModSettingBool Peashooter = new ModSettingBool(true)
    {
        displayName = "PeaShooter Mode",
        description = "If enabled Peashooters shoot like dartling gunners, allowing you to aim them. If disabled they shoot more like dart monkeys",
        requiresRestart = true,
        button = true,
        disabledText = "Dart Monkey",
        enabledText = "Dartling",
        icon = "PeashooterDisplay"
    };
}