using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCharacterStats : MonoBehaviour
{
    private GameObject[] players;

    [SerializeField] CharacterCircle[] charCircle;

    private void Start()
    {
        players = GameManager.Instance.GetPlayers();
        for (int i = 0; i < charCircle.Length; i++)
        {
            charCircle[i].SetPlayer(i);
            charCircle[i].SetWeapon(players[i].GetComponentInChildren<Weapon>().GetWeaponTemplate().GetIcon());
        }
    }

    public void UpdatePlayerHP(int player, int hp)
    {
        charCircle[player].SetHP(hp);
    }
}
