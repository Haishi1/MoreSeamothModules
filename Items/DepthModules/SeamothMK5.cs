using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nautilus.Assets.Gadgets;
using Nautilus.Crafting;

namespace MoreSeamothModules.Items.DepthModules
{
    public class SeamothMK5
    {
        public static PrefabInfo Info { get; private set; }

        public static void Register()
        {
            Info = PrefabInfo.WithTechType("SeamothDepthModuleMK5", "Seamoth Depth Module MK5", "Enhances safe diving depth by 1500m. Does not stack.")
            .WithIcon(SpriteManager.Get(TechType.VehicleHullModule1));
            var MK5Prefab = new CustomPrefab(Info);

            var MK5Obj = new CloneTemplate(Info, TechType.VehicleHullModule1);
            MK5Prefab.SetGameObject(MK5Obj);

            MK5Prefab.SetRecipe(new RecipeData()
            {
                craftAmount = 1,
                Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(SeamothMK4.Info.TechType,1),
                new CraftData.Ingredient(TechType.PlasteelIngot),
                new CraftData.Ingredient(TechType.Kyanite,3)
            }
            }).WithFabricatorType(CraftTree.Type.Workbench).WithCraftingTime(5f);
            MK5Prefab.SetVehicleUpgradeModule(EquipmentType.SeamothModule, QuickSlotType.Passive).WithDepthUpgrade(1700f, true);
            MK5Prefab.Register();
        }
    }
}
