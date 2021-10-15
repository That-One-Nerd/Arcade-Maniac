using System;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Misc.ObjectModels
{
    [Serializable]
    public struct ShakeData
    {
        public Vector3 intensity;
        public bool slowOverTime;
        public float time;
    }
}
