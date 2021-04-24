using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
    public int cardType;

    private GameObject player;

    private void Start() {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void HealPlayer() {
        player.GetComponent<PlayerLifeManager>().Heal(30);
    }

    public void onPress() {
        if (!player) return;

        if (cardType == 0)
            HealPlayer();
    }
}
