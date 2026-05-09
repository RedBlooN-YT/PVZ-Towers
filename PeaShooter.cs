using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppSystem.Linq;
using PVZTowers.Displays;
using UnityEngine;
using static Il2CppAssets.Scripts.Models.Towers.Behaviors.RateSupportModel;



namespace PVZTowers.Peashooter;

public class PeaShooter : ModTower<PVZTowerSet>
{
    public override bool DoesTick => true;
    public override string BaseTower => TowerType.DartlingGunner;

    public override int Cost => 250;

    public override ParagonMode ParagonMode => ParagonMode.Base000;

    public override bool IncludeInRogueLegends => true;

    public override string Description => "Shoots peas at the bloons";

    public override string DisplayName => "Pea Shooter";

    public override string Icon => "PeashooterDisplay";

    public override string Portrait => "PeashooterDisplay";
    protected override void Tick(int ticks, Simulation sim, Tower tower)
    {
        if (tower.towerModel.tiers[0] == 0 && tower.towerModel.tiers[1] == 0 && tower.towerModel.tiers[2] == 0)
        {
            foreach (var mut in tower.mutators)
            {
                if (mut.mutator.id == "PlantFoodBuff")
                {
                    /*tower.towerModel.range = 999999f;
                    tower.towerModel.GetAttackModel().range = 999999f;
                    sim.AbilitiesChanged();
                    var abilities = InGame.instance.bridge.GetAllAbilities(false);
                    foreach (var ability in abilities)
                    {
                        if (ability.ability.tower == tower)
                        {
                            ability.ResetCooldown();
                        }
                    }*/
                    tower.towerModel.GetAttackModel().weapons[0].rate = 0;
                }
            }
        }
    }

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        var travelmodel = projectileModel.GetBehavior<TravelStraitModel>();

        travelmodel.lifespan = 0.25f;
        projectileModel.pierce = 1;
        projectileModel.GetDamageModel().damage = 1;
        weaponModel.rate = 2f;

        weaponModel.emission = new ArcEmissionModel("ArcEmissionModel_", 1, 0, 10, null, false, false);

        var projectile = attackModel.weapons[0].projectile;
        projectile.ApplyDisplay<PeaDisplay>();
    }

    // Ultimate Crosspathing
    public override bool IsValidCrosspath(int[] tiers) => ModHelper.HasMod("UltimateCrosspathing") || base.IsValidCrosspath(tiers);

}
