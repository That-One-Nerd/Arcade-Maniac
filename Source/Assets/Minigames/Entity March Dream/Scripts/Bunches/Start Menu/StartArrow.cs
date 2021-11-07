using System;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc;
using UnityEngine;
using UnityEngine.Events;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.StartMenu
{
    public class StartArrow : MonoBehaviour
    {
        public UnityEvent[] methods;
        public Vector2[] positions;

        private Camera cam;
        private Vector2 oldAxis;
        private int position;

        private void Awake() => cam = FindObjectOfType<Camera>();
        private void Update()
        {
            if (positions.Length != methods.Length) throw new Exception(nameof(methods) + " and " + nameof(positions) + " must have the same length.");

            Vector2 axis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            float changed = axis.x != oldAxis.x ? axis.x : axis.y != oldAxis.y ? axis.y : float.NegativeInfinity;
            if (!float.IsNegativeInfinity(changed)) position += changed < 0 ? 1 : changed > 0 ? -1 : 0;

            position = position >= positions.Length ? 0 : position < 0 ? positions.Length - 1 : position;

            transform.position = cam.WorldToScreenPoint(positions[position]);
            if (Input.GetButtonDown("Submit")) methods[position].Invoke();

            oldAxis = axis;
        }

        public void NewGameSelection()
        {
            SaveData.DeleteSaveFile();
            Transition.Instance.FadeTransition("EMD Level 1-1");
        }
        public void ContinueSelection()
        {
            if (!SaveData.Saved) return;
            SaveData save = SaveData.LoadFromFile();

            Transition.Instance.FadeTransition(save.levelName);
        }
        public void ReturnSelection() => Transition.Instance.FadeTransition("Arcade");
    }
}
