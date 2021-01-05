using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreNPC.Items
{
    public class SteveSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This is Steve's sword.");
        } 

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.useTime = 5;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.value = 100;
            item.rare = 1;
            // On use should allow Steve (Temp Blue Dye Trader) to spawn
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            bool alreadySpawned = NPC.AnyNPCs(mod.NPCType("NPC1"));
            return !alreadySpawned;
        }

        // Got no clue what to place here
        public override bool UseItem(Player player)
        //{
        //    return true;
        //}


        // For now crafted with 1 dirt
        // Will later make non craftable and be sold by an NPC *most likly Guild he seems board.
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}