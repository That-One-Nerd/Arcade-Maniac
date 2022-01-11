using System;
using System.Linq;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.HackerMagic.ObjectModels;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.HackerMagic
{
    public class SyntaxManager : MonoBehaviour
    {
        public static string WhitespaceChars => " \n\t";

        public string allowedAdjacent;
        public MarkupComponent[] components;
        public bool debugMode;
        public MarkupComponent markupContainers;
        public MarkupInfo markupNumbers;
        public MarkupComponent markupOperators;
        public MarkupComponent markupDoubleQuotes;
        public MarkupComponent markupSingleQuotes;

        private Text display;
        private InputField input;

        private void Awake()
        {
            display = transform.Find("Display").GetComponent<Text>();
            input = GetComponent<InputField>();

            input.onValueChanged.AddListener(OnValueChanged);
        }

        public void OnValueChanged(string newVal)
        {
            if (debugMode) display.text = Markup(newVal);
            else
            {
                try { display.text = Markup(newVal); }
                catch { display.text = newVal; }
            }
        }

        public string FormatNewChar(char newChar) => newChar switch
        {
            _ => newChar.ToString()
        };

        public string Markup(string text)
        {
            string allowedChars = allowedAdjacent + WhitespaceChars;

            text.Trim();

            for (int i = 0, sinceWhite = 0; i < text.Length; i++, sinceWhite++)
            {
                if (WhitespaceChars.Contains(text[i]))
                {
                    sinceWhite = 0;
                    continue;
                }

                Numbers();
                void Numbers()
                {
                    if (markupNumbers.Color.a <= 0 || !double.TryParse(text[i].ToString(), out _)) return;

                    string add = text[i].ToString();
                    for (int j = i + 1; j < text.Length; j++)
                    {
                        string newAdd = add + text[j];
                        if (!double.TryParse(newAdd, out _)) break;
                        add = newAdd;
                    }

                    if (!IsAllowed(add.Length)) return;
                    (string, string) chunks = GetMarkupChunks(markupNumbers);
                    text = InsertMarkup(chunks.Item1, chunks.Item2, add);
                }

                if (i >= text.Length) break;

                CustomComponents();
                void CustomComponents()
                {
                    MarkupComponent markup = components.FirstOrDefault(x => text.ContainsAt(i, x.Text));
                    if (markup.Color.a == 0 || string.IsNullOrEmpty(markup.Text) || string.IsNullOrWhiteSpace(markup.Text))
                        return;

                    if (!IsAllowed(markup.Text.Length)) return;
                    (string, string) chunks = GetMarkupChunks(markup.ToMarkupInfo());
                    text = InsertMarkup(chunks.Item1, chunks.Item2, markup.Text);
                }

                if (i >= text.Length) break;

                Quotes();
                void Quotes()
                {
                    if (markupDoubleQuotes.Text.Contains(text[i]) && markupDoubleQuotes.Color.a > 0)
                    {
                        string add = "";
                        for (int j = i; j < text.Length; j++)
                        {
                            add += text[j];
                            if (text[j] == '"' && j > i) break;
                        }

                        (string, string) chunks = GetMarkupChunks(markupDoubleQuotes.ToMarkupInfo());
                        text = InsertMarkup(chunks.Item1, chunks.Item2, add);
                    }

                    if (i >= text.Length) return;

                    if (markupSingleQuotes.Text.Contains(text[i]) && markupSingleQuotes.Color.a > 0)
                    {
                        string add = "";
                        for (int j = i; j < text.Length; j++)
                        {
                            add += text[j];
                            if (text[j] == '\'' && j > i) break;
                        }

                        (string, string) chunks = GetMarkupChunks(markupSingleQuotes.ToMarkupInfo());
                        text = InsertMarkup(chunks.Item1, chunks.Item2, add);
                    }
                }

                if (i >= text.Length) break;

                OperatorsAndContainers();
                void OperatorsAndContainers()
                {
                    if (markupOperators.Text.Contains(text[i]) && markupOperators.Color.a > 0)
                    {
                        (string, string) chunks = GetMarkupChunks(markupOperators.ToMarkupInfo());
                        text = InsertMarkup(chunks.Item1, chunks.Item2, text[i].ToString());
                    }

                    if (markupContainers.Text.Contains(text[i]) && markupContainers.Color.a > 0)
                    {
                        (string, string) chunks = GetMarkupChunks(markupContainers.ToMarkupInfo());
                        text = InsertMarkup(chunks.Item1, chunks.Item2, text[i].ToString());
                    }
                }

                bool IsAllowed(int length) => (i == 0 || allowedChars.Contains(text[i - 1])) &&
                    (text.Length <= i + length || allowedChars.Contains(text[i + length]));
                string InsertMarkup(string a, string b, string over)
                {
                    string replaceB = b.Replace("<", "</") + "</color>";
                    int oldI = i;
                    i += a.Length + b.Length + over.Length + replaceB.Length - 1;

                    return text.Insert(oldI, a + b).Insert(oldI + a.Length + b.Length + over.Length, replaceB);
                }
                (string, string) GetMarkupChunks(MarkupInfo info) => 
                    ("<color=#" + ColorUtility.ToHtmlStringRGBA(info.Color) + ">",
                    (info.MarkBold ? "<b>" : "") + (info.MarkItalic ? "<i>" : ""));
            }

            return text;
        }
    }
}
