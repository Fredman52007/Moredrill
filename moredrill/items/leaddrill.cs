using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace moredrill.items
{
    public class leaddrill : ModItem
    {
        public override void SetStaticDefaults()
        {
             ItemID.Sets.IsDrill[Type] = true;
        }


        public override void SetDefaults()
        {
            Item.damage = 5;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.width = 46;
            Item.height = 22;
            Item.useTime = 9;
            Item.useAnimation = 9;
            Item.pick = 43;    //�������� ����
            Item.knockBack = 6;
            Item.tileBoost += 1;

            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item23;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.leaddrillproj>();            //������������ ������������ (��������� ����)</span>
            Item.shootSpeed = 32f;
            Item.noMelee = true;
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Shoot;

        }
        
        
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Type); // ������� ����� ������
            recipe.AddIngredient(ItemID.LeadBar, 15);// ���������� �������
            recipe.AddTile(TileID.Anvils); // ����� ��� ������
            recipe.Register(); // ����������� �������
        }

    }
}