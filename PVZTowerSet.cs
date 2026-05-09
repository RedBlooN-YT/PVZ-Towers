using System;
using BTD_Mod_Helper.Api.Towers;

namespace PVZTowers;

public class PVZTowerSet : ModTowerSet
{
    public override string Name => "Pvz Towers";
    public override bool AllowInRestrictedModes => true;
    public override string Button => "Button";
    public override string Container => "Container";
    public override string ContainerLarge => "Container";
    public override string Portrait => "Container";
}
