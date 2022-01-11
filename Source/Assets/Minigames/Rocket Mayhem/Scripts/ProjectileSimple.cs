using UnityEngine;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.RocketMayhem.Abstract;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.RocketMayhem
{
    public class ProjectileSimple : Projectile
    {
        protected override void MoveActive(Quaternion toRot) => MoveIdle();
        protected override void MoveActive(Vector2 toPos) => MoveIdle();
    }
}
