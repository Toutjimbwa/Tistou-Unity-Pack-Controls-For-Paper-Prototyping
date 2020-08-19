using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace TistouUnity
{
    namespace ControlsForPrototypingPack
    {
        public class Controls : MonoBehaviour
        {
            public readonly Dictionary<int, string> ControlContextDic = new Dictionary<int, string>
            {
                {0, "ThirdPersonControls"},
                {1, "InventoryControls"},
                {2, "ConversationControls"}
            };
            public string ControlContext;
            public float ResetTime = 1f;
            private Text OutputText = null;

            private void Start()
            {
                OutputText = GameObject.FindGameObjectWithTag("Player").GetComponent<Text>();
            }

            // Update is called once per frame
            void Update()
            {
                switch (ControlContextDic.FirstOrDefault(x => x.Value == ControlContext).Key)
                {
                    case 0:
                        ThirdPerson();
                        break;
                    case 1:
                        Inventory();
                        break;
                    case 2:
                        Conversation();
                        break;
                }
            }

            private void ThirdPerson()
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Output("USE");
                }else if (Input.GetMouseButtonDown(1))
                {
                    Output("DROP / THROW");
                }
                else if (Input.GetKeyDown(KeyCode.I))
                {
                    Output("INVENTORY");
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    Output("JUMP");
                }
                else if (Input.GetKeyDown(KeyCode.Tab))
                {
                    Output("SWTICH HANDS");
                }
                if (Input.GetKey(KeyCode.W))
                {
                    Output("^\n|");
                }else if (Input.GetKey(KeyCode.S))
                {
                    Output("|\nv");
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    Output("<--");
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    Output("-->");
                }
            }
            private void Inventory()
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Output("COMBINE");
                }
                else if (Input.GetKeyDown(KeyCode.Tab))
                {
                    Output("SWITCH HANDS");
                }
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Output("BACK");
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    Output("<- \n ->");
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    Output("-> \n <-");
                }
            }
            private void Conversation()
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Output("GIVE");
                }
                else if (Input.GetKeyDown(KeyCode.I))
                {
                    Output("INVENTORY");
                }
                else if (Input.GetKeyDown(KeyCode.Tab))
                {
                    Output("SWTICH HANDS");
                }
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Output("BACK");
                }
            }

            public void ChangeControlContext(int i)
            {
                ControlContext = ControlContextDic[i];
            }

            private void Output(string action)
            {
                OutputText.text = action;
                StartCoroutine(FadeTextToZeroAlpha(1f, OutputText));
            }
            public IEnumerator FadeTextToZeroAlpha(float t, Text i)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
                while (i.color.a > 0.0f)
                {
                    i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
                    yield return null;
                }
            }
        }
    }
}
