using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.TheAverage9To5Job
{
    public class TextRenderer : MonoBehaviour
    {
        private Text txt;

        private void Awake()
        {
            txt = GetComponent<Text>();
            Flush();
        }

        public void Flush() => txt.text = "";
        public async void WriteText(string content, int msDelay = 100, int mouseDownDelay = 20)
        {
            for (int i = 0; i < content.Length; i++)
            {
                await Task.Delay(Input.GetMouseButton(0) ? mouseDownDelay : msDelay);
                txt.text += content[i];
            }
        }
    }
}
