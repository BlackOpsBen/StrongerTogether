using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCharacterStats : MonoBehaviour
{
    [SerializeField] RectTransform charOrigin;
    [SerializeField] GameObject charCircleObject;
    [SerializeField] float offset = 100f;
    private GameObject[] players;

    private CharacterCircle[] charCircle = new CharacterCircle[4];

    private void Start()
    {
        players = GameManager.Instance.GetPlayers();
        for (int i = 0; i < charCircle.Length; i++)
        {
            float actualOffset = offset * i;
            Vector3 newPos = new Vector3(charOrigin.transform.position.x + actualOffset, charOrigin.transform.position.y);
            charCircle[i] = Instantiate(charCircleObject, charOrigin).GetComponent<CharacterCircle>();
            charCircle[i].GetComponent<RectTransform>().transform.position = newPos;
            charCircle[i].SetPlayer(i);
            charCircle[i].SetWeapon(players[i].GetComponentInChildren<Weapon>().GetWeaponTemplate().GetIcon());
        }
    }
}
