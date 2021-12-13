using UnityEngine;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.RocketMayhem.Abstract;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.RocketMayhem
{
    public class ProjectileExploding : Projectile
    {
        protected override void Despawn()
        {
            Debug.Log("Explosion Moment");
            base.Despawn();
        }
    }
}
