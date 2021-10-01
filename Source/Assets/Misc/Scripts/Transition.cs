using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Misc
{
    public class Transition : MonoBehaviour
    {
        public static Transition Instance { get; private set; }
        public static float Speed { get; private set; }
        public static bool Transitioning { get; private set; }

        private RawImage ima;

        private void Awake()
        {
            ima = GetComponent<RawImage>();
            Instance = this;
            Speed = 1;
            DontDestroyOnLoad(transform.parent.gameObject);
        }
        private void Update() { if (!Transitioning) ima.color = new Color(ima.color.r, ima.color.r, ima.color.g, Mathf.Clamp(ima.color.a - (Time.deltaTime * Speed), 0, 1)); }
    
        public void FadeTransition(string sceneName, float speed = 1, Color? color = null, float startDelay = 0, float afterSpeed = -1, float afterDelay = 0) { if (!Transitioning) StartCoroutine(IFadeTransition(sceneName, speed, color ?? Color.black, startDelay, afterSpeed, afterDelay)); }
        public void ImageTransition(string sceneName, float speed = 1, Texture image = null, float startDelay = 0, float afterSpeed = -1, float afterDelay = 0) { if (!Transitioning) StartCoroutine(IImageTransition(sceneName, speed, image, startDelay, afterSpeed, afterDelay)); }
        public void InstantTransition(string sceneName, float delay = 0) { if (!Transitioning) StartCoroutine(IInstantTransition(sceneName, delay)); }

        private IEnumerator IFadeTransition(string sceneName, float speed, Color color, float startDelay, float afterSpeed, float afterDelay)
        {
            Transitioning = true;
            ima.color = new Color(color.r, color.g, color.b, 0);
            ima.texture = null;

            for (float f = 0; f < startDelay; f += Time.deltaTime) yield return null;

            while (ima.color.a < color.a)
            {
                ima.color += Color.black * (Time.deltaTime * speed);
                yield return null;
            }
            ima.color = color;
            yield return null;

            SceneManager.LoadScene(sceneName);

            for (float f = 0; f < afterDelay; f += Time.deltaTime) yield return null;

            Speed = afterSpeed == -1 ? speed : afterSpeed;

            Transitioning = false;
            yield return null;
        }
        private IEnumerator IImageTransition(string sceneName, float speed, Texture image, float startDelay, float afterSpeed, float afterDelay)
        {
            Transitioning = true;
            ima.color = new Color(1, 1, 1, 0);
            ima.texture = image;

            for (float f = 0; f < startDelay; f += Time.deltaTime) yield return null;

            while (ima.color.a < 1)
            {
                ima.color += Color.black * (Time.deltaTime * speed);
                yield return null;
            }
            ima.color = Color.white;
            yield return null;

            SceneManager.LoadScene(sceneName);

            for (float f = 0; f < afterDelay; f += Time.deltaTime) yield return null;

            Speed = afterSpeed == -1 ? speed : afterSpeed;

            Transitioning = false;
            yield return null;
        }        
        private IEnumerator IInstantTransition(string sceneName, float delay)
        {
            Transitioning = true;

            for (float f = 0; f < delay; f += Time.deltaTime) yield return null;

            SceneManager.LoadScene(sceneName);

            Transitioning = false;
            yield return null;
        }
    }
}
