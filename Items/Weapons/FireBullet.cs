using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExtraGunGear.Items.Weapons
{
	public class FireBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Incendiary Bullet");
			Tooltip.SetDefault("'You best head for the hills, I'm on fire'");
		}

		public override void SetDefaults()
		{
			item.damage = 8;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 2f;
			item.value = 2;
			item.rare = 1;
			item.shoot = mod.ProjectileType("FireBullet");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 3.5f;                  //The speed of the projectile
			item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 20);
			recipe.AddIngredient(ItemID.Torch, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 20);
			recipe.AddRecipe();
		}
	}
}
