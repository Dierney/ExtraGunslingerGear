using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Audio;
using System.Threading;
using System.Diagnostics;

namespace ExtraGunGear.Items.Weapons //Such namescape
{
    public class VortexAR : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Pulse Rifle");
            Tooltip.SetDefault("Five round burst"
                + "\nOnly the first shot consumes ammo"
                + "\n'I love the smell of pulse munitions in the morning'");
            
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            spriteBatch.Draw
            (
                mod.GetTexture("Items/Weapons/VortexAR_Glow"),
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - mod.GetTexture("Items/Weapons/VortexAR_Glow").Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, mod.GetTexture("Items/Weapons/VortexAR_Glow").Width, mod.GetTexture("Items/Weapons/VortexAR_Glow").Height),
                Color.White,
                rotation,
                mod.GetTexture("Items/Weapons/VortexAR_Glow").Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
            base.PostDrawInWorld(spriteBatch, lightColor, alphaColor, rotation, scale, whoAmI);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            //Vector2 position2 = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y + 10f + player.velocity.Y), true);
            //Lighting.AddLight(position2, .5f, .7f, 1f);
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3f));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            if (!(player.itemAnimation < item.useAnimation - 2))
            {
                int numberProjectiles = 1;    //Fires extra projectile
                for (int i = 1; i == numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5f));
                    speedX = perturbedSpeed2.X;
                    speedY = perturbedSpeed2.Y;
                    Vector2 perturbedSpeed3 = new Vector2(speedX / 3.5f, speedY / 3.5f);
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed3.X, perturbedSpeed3.Y, 616, 20, 0, player.whoAmI);
                }
                //}
                
            }
            return true;
        }
        

        public override bool ConsumeAmmo(Player player)
        {
            return !(player.itemAnimation < item.useAnimation - 2);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-7, 0);
        }

        public override void SetDefaults()
        {
            item.damage = 52;
            item.crit = 2;
            item.ranged = true;
            item.width = 72;
            item.height = 34;
            item.useAnimation = (101 / 10);
            item.useTime = (5 / 2);
            item.reuseDelay = 14;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1;
            item.value = 165000;
            item.rare = 10;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 20f;
            item.useAmmo = AmmoID.Bullet;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Item_31_5");
            item.scale = .9f;
            //item.noUseGraphic = true;
            //item.glowMask = (short) mod.ItemType("VortexAR_Glow");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentVortex, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}