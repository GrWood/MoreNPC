using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;


namespace MoreNPC.NPCs
{
    [AutoloadHead]
    public class DryadRed : ModNPC
    {
        public override string Texture
        {
            get { return "MoreNPC/NPCs/DryadRed"; }
        }

        //public override string[] AltTextures
        //{
        //    get { return new[] { "MoreNPC/NPCs/NPC1_Alt_1" }; }
        //}

        // NPC Title
        public override bool Autoload(ref string name)
        {
            name = "Dryad";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 21;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 150;
            NPCID.Sets.AttackType[npc.type] = 2;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Dryad;
        }

        // Spawn Conditions
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }

                // Currently I have an item that will allow spawning when it is in my inventory.
                // I want to make the item a consumable.
                foreach (Item item in player.inventory)
                {
                    if (item.type == mod.ItemType("SteveSword"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // NPC Name (first)
        public override string TownNPCName()
        {
            return "Rose";
        }

        // NPC Chat Diologe
        public override string GetChat()
        {
            switch (Main.rand.Next(4))
            {
                case 0:
                    return "You wanna buy something?";
                case 1:
                    return "What you want?";
                case 2:
                    return "I like this house.";
                case 3:
                    return "<I'm blue dabu di dabu dai>....OH HELLO THERE..";
                default:
                    return "Go kill Skeletron.";

            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            base.TownNPCAttackStrength(ref damage, ref knockback);
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            base.TownNPCAttackCooldown(ref cooldown, ref randExtraCooldown);
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.DryadsWardCircle;
            attackDelay = 1;
        }


    }
}
