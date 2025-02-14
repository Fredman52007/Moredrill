using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace moredrill.items
{
    public class moltendrill : ModItem
    {
        public override void SetStaticDefaults()
        {
             ItemID.Sets.IsDrill[Type] = true;
        }


        public override void SetDefaults()
        {
            Item.damage = 17;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.width = 46;
            Item.height = 22;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.pick = 100;    //МОЩНОСТЬ бура
            Item.knockBack = 6;
            Item.tileBoost += 1;

            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item23;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.moltendrillproj>();            //расположение ПРОДЖЕКТАЙЛА
            Item.shootSpeed = 32f;
            Item.noMelee = true;
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Shoot;

        }
        
        
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Type); // Создаем новый рецепт
            recipe.AddIngredient(ItemID.HellstoneBar, 25);// Компоненты рецепта
            recipe.AddTile(TileID.Anvils); // Место для крафта
            recipe.Register(); // Регистрация рецепта
        }

    }
}