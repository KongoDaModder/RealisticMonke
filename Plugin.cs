using BepInEx;
using HarmonyLib;
using System;
using System.ComponentModel;
using UnityEngine;
using Utilla;
using BepInEx.Configuration;
using System.IO;
using System.Reflection;
using Photon.Pun;

namespace BigRipples
{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin("com.kongo.gorillatag.realisticmonke", "RealisticMonke", "1.0.0")]
    public class BigRipples : BaseUnityPlugin
    {
        bool enable;
        bool inRoom;
        void OnEnable()
        {
            enable = true;
            if (!inRoom)
                return;
            {
               if (enable)
                {
                    
                    float burntimer = GorillaTagger.Instance.taggedTime;
                    bool drown = false;
                    bool starttimerwater = GorillaLocomotion.Player.Instance.HeadInWater;
                    if (starttimerwater)
                    {
                        (drown) = true;
                        {
                            if (drown == true)
                            { 
                                Thread.Sleep(30000);
                                {
                                    Application.Quit();
                                }
                            }
                        }
                    }
                    if (starttimerwater == false)
                    {
                        (drown) = false;
                    }
                    if (burntimer == 30f)
                    {
                        PhotonNetwork.Disconnect();
                    }
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 1f;
                    
                }
            }
        }

        void OnDisable()
        {
            GorillaLocomotion.Player.Instance.maxJumpSpeed = 6.5f;
            bool enable = false;
        }

        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)

        {
            inRoom = true;
        }

        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            inRoom = false;
        }
    }
}
class PluginInfo
{
}

