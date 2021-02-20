using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCircle : MonoBehaviour
{
    [SerializeField] Image circleImage;
    [SerializeField] Image weaponImage;
    [SerializeField] TextMeshProUGUI hp;
    [SerializeField] Sprite[] circleOptions;

    public void SetPlayer(int playerIndex)
    {
        circleImage.sprite = circleOptions[playerIndex];
    }

    public void SetWeapon(Sprite weaponSprite)
    {
        weaponImage.sprite = weaponSprite;
    }

    public void SetHP(int newHp)
    {
        hp.text = newHp.ToString();
    }
}
