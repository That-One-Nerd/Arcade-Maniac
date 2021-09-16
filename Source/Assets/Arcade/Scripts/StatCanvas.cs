using System.Linq;
using System.Reflection;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.ObjectModels;
using UnityEngine;
using UnityEngine.UI;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Arcade
{
    public class StatCanvas : MonoBehaviour
    {
        private MethodInfo[] childMethods;
        private GameObject[] children;

        private void Awake()
        {
            children = new GameObject[transform.childCount];
            for (int i = 0; i < transform.childCount; i++) children[i] = transform.GetChild(i).gameObject;

            childMethods = typeof(StatCanvas).GetMethods().Where(
                x => x.Name.StartsWith("Child") &&
                !x.IsGenericMethod &&
                !x.IsAbstract &&
                x.GetParameters().Length == 1 &&
                x.GetParameters()[0].ParameterType == typeof(GameObject)).ToArray();
        }
        
        private void Update()
        {
            foreach (GameObject child in children)
            {
#pragma warning disable UNT0018
                MethodInfo method = childMethods.FirstOrDefault(x => x.Name == "Child" + child.name.Combine());
                // Since I really only run the method calculations in the `Awake()` method, using "MethodInfo" here
                // doesn't waste any time, which `UNT0018` was yelling at me about. If I were to run some code like:
                /// MethodInfo[] methods = typeof(StatCanvas).GetMethods();
                // That would waste time loading it every time. But I am not doing that, so I can ignore this message.
#pragma warning restore UNT0018
                if (method == null) continue;
                method.Invoke(method.IsStatic ? null : this, new object[] { child });
            }
        }

        public void ChildGamesCompleted(GameObject g) => g.GetComponent<Text>().text = "Completed Games: " +
                                                             Statistics.instance.completedGames + " / " +
                                                             Statistics.instance.requiredGames + " (" +
                                                             Statistics.instance.CompletedPercent.ToString("0.00") + "%)";
    }
}
