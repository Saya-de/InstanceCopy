using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using VRC.UI;
using System.Windows.Forms;
using Button = UnityEngine.UI.Button;

namespace InstanceCopy
{
    public static class Main
    {
        public const string Name = "InstanceCopy";
        public const string Description = "A Button to Copy an InstanceID without joining";
        public const string Author = "Saya";
        public const string Company = null;
        public const string Version = "1.8.7";
        public const string DownloadLink = null;
    }

    public class InstanceCopy : MelonMod
    {
        protected static GameObject ButtonID;

        public static bool done = false;
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if(!done)
            {
                if (sceneName.Equals("ui"))
                {

                    MelonLogger.Msg("Setting up Button...");

                    MainInit();

                }
            }
            
        }      
      
        public static void MainInit()
        {
            
                       
            Transform WPage = GameObject.Find("UserInterface/MenuContent/Screens/WorldInfo").transform;
            GameObject Button = GameObject.Find("UserInterface/MenuContent/Screens/WorldInfo/Panels/DetailsPanel/AuthorText-Title/AuthorButton").gameObject;
            ButtonID = GameObject.Instantiate(Button, WPage, true);
            ButtonID.name = "InstanceIDButton";
            ButtonID.GetComponent<Image>().type = Image.Type.Tiled;
            ButtonID.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            SetAction(() => { CopyInstanceID(); });
            ButtonID.GetComponentInChildren<Text>().text = "InstanceID";
            ButtonID.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 66);
            ButtonID.GetComponent<RectTransform>().anchoredPosition = new Vector2(-585, 392);
            MelonLogger.Msg("Done!");
            done = true;
        }

        public static void CopyInstanceID()
        {
            GameObject WI = GameObject.Find("UserInterface/MenuContent/Screens/WorldInfo").gameObject;
            string ID = WI.GetComponent<PageWorldInfo>().field_Public_ApiWorldInstance_0.id;
            try
            {
                Clipboard.SetText(ID);
                MelonLogger.Msg($"Copied Instance ID: {ID}");
            }
            catch { MelonLogger.Msg(ConsoleColor.Red,"Error while copying the ID to your Clipboard. Try again!");}
                      
            
        }  
        public static void SetAction(Action buttonAction)
        {
            ButtonID.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
                ButtonID.GetComponent<Button>().onClick.AddListener(UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
        }

    }

    
    
}