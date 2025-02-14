using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;



namespace moredrill.Projectiles //������������ ������������</span>

{

    public class moltendrillproj : ModProjectile //�������� ������������ � � ����� ������ ���������</span>
    {
        public override void SetStaticDefaults()
        {
            // Prevents jitter when stepping up and down blocks and half blocks
            ProjectileID.Sets.HeldProjDoesNotUsePlayerGfxOffY[Type] = true;
        }


        //������ �������� � �������������</span>
        public override void SetDefaults()
        {
            Projectile.width = 22;                   //������ ������������ � ���������</span
            Projectile.height = 22;                  //������ ������������ � �����������</span>
            Projectile.aiStyle = ProjAIStyleID.Drill;                            //����� ������������</span>
            Projectile.friendly = true;                      //�����������? �� ���� �� ������� �����?</span>
            Projectile.penetrate = -1;                    //�������� ����������</span>
            Projectile.tileCollide = false;                  //������������ � ����������?
            Projectile.hide = true;               //�������� �����������?
            Projectile.ownerHitCheck = true;              //������� ���������? � �������� TRUE - ���
            Projectile.DamageType = DamageClass.Melee;                            //������ �������� ���? 
            Projectile.aiStyle = -1;
            //Projectile.scale = 0.93f;
        }


        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            Projectile.timeLeft = 60;

            // Animation code could go here if the projectile was animated. 

            // Plays a sound every 20 ticks. In aiStyle 20, soundDelay is set to 30 ticks.
            if (Projectile.soundDelay <= 0)
            {
                SoundEngine.PlaySound(SoundID.Item22, Projectile.Center);
                Projectile.soundDelay = 20;
            }

            Vector2 playerCenter = player.RotatedRelativePoint(player.MountedCenter);
            if (Main.myPlayer == Projectile.owner)
            {
                // This code must only be ran on the client of the projectile owner
                if (player.channel)
                {
                    float holdoutDistance = player.HeldItem.shootSpeed * Projectile.scale;
                    // Calculate a normalized vector from player to mouse and multiply by holdoutDistance to determine resulting holdoutOffset
                    Vector2 holdoutOffset = holdoutDistance * Vector2.Normalize(Main.MouseWorld - playerCenter);
                    if (holdoutOffset.X != Projectile.velocity.X || holdoutOffset.Y != Projectile.velocity.Y)
                    {
                        // This will sync the projectile, most importantly, the velocity.
                        Projectile.netUpdate = true;
                    }

                    // Projectile.velocity acts as a holdoutOffset for held projectiles.
                    Projectile.velocity = holdoutOffset;
                }
                else
                {
                    Projectile.Kill();
                }
            }

            if (Projectile.velocity.X > 0f)
            {
                player.ChangeDir(1);
            }
            else if (Projectile.velocity.X < 0f)
            {
                player.ChangeDir(-1);
            }

            Projectile.spriteDirection = Projectile.direction;
            player.ChangeDir(Projectile.direction); // Change the player's direction based on the projectile's own
            player.heldProj = Projectile.whoAmI; // We tell the player that the drill is the held projectile, so it will draw in their hand
            player.SetDummyItemTime(2); // Make sure the player's item time does not change while the projectile is out
            Projectile.Center = playerCenter; // Centers the projectile on the player. Projectile.velocity will be added to this in later Terraria code causing the projectile to be held away from the player at a set distance.
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            player.itemRotation = (Projectile.velocity * Projectile.direction).ToRotation();

            // Gives the drill a slight jiggle
            Projectile.velocity.X *= 1f + Main.rand.Next(-3, 4) * 0.01f;
            Vector2 mousePosition = Main.MouseWorld;

            // ������� ���� ����� �������� ������ � ��������
            Vector2 direction = mousePosition - player.position;
            direction.Normalize();

            // Spawning dust
            if (Main.rand.NextBool(10))
            {
                Vector2 dustPosition = player.position + new Vector2(10 * direction.X, 10 * direction.Y);
                Dust dust = Dust.NewDustPerfect(dustPosition, DustID.Smoke);
                dust.scale = 1.5f;
                dust.velocity = direction * 2f;
            }
        }
    }
}


