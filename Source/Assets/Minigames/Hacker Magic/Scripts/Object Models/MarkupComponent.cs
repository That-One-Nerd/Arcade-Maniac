using System;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.HackerMagic.ObjectModels
{
    [Serializable]
    public struct MarkupComponent
    {
        public Color Color;
        public bool MarkBold;
        public bool MarkItalic;
        public string Text;

        public MarkupInfo ToMarkupInfo() => new MarkupInfo
        {
            Color = Color,
            MarkBold = MarkBold,
            MarkItalic = MarkItalic
        };
    }
}
