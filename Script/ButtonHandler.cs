using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class ButtonHandler : MonoBehaviour
    {
        GameObject player;
        public string Name;

        Animator ani;

        void OnEnable()
        {

        }

        public void SetDownState()
        {
            player = GameObject.Find("character" + (GameData.player_order[GameData.playing_player - 1]).ToString());
            ani = player.GetComponent<Animator>();
            ani.SetBool("jump", true);
            //print("jump");
            CrossPlatformInputManager.SetButtonDown(Name);
        }


        public void SetUpState()
        {
            player = GameObject.Find("character" + (GameData.player_order[GameData.playing_player - 1]).ToString());
            ani = player.GetComponent<Animator>();
            ani.SetBool("jump", false);
            //print("jump off");
            CrossPlatformInputManager.SetButtonUp(Name);
        }


        public void SetAxisPositiveState()
        {
            CrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            CrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            CrossPlatformInputManager.SetAxisNegative(Name);
        }

        public void Update()
        {

        }
    }
}