using UnityEngine;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.RocketMayhem.Abstract;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.RocketMayhem
{
    public class ProjectileExploding : Projectile
    {
        protected override void Update()
        {
            speed -= Time.deltaTime * speedIncrease;
            base.Update();
        }

        protected override void MoveIdle() => HitPlayer();
        protected override void HitPlayer()
        {
            Debug.Log("explode");
            base.HitPlayer();
        }
    }
}
