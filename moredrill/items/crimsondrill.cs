using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace moredrill.items
{
    public class crimsondrill : ModItem
    {
        public override void SetStaticDefaults()
        {
             ItemID.Sets.IsDrill[Type] = true;
        }


        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.width = 46;
            Item.height = 22;
            Item.useTime = 7;
            Item.useAnimation = 7;
            Item.pick = 70;    //�������� ����
            Item.knockBack = 6;
            Item.tileBoost += 1;

            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item23;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.crimsondrillproj>();            //������������ ������������ (��������� ����)</span>
            Item.shootSpeed = 32f;
            Item.noMelee = true;
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Shoot;

        }
        
        
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Type); // ������� ����� ������
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddIngredient(ItemID.TissueSample, 6);// ���������� �������
            recipe.AddTile(TileID.Anvils); // ����� ��� ������
            recipe.Register(); // ����������� �������
        }

    }
}