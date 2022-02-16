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
    [SerializeField] Image buttonImage;
    [SerializeField] Sprite[] circleOptions;
    [SerializeField] Sprite[] buttonOptions;
    [SerializeField] Sprite deadIcon;

    public void SetPlayer(int playerIndex)
    {
        circleImage.sprite = circleOptions[playerIndex];
        buttonImage.sprite = buttonOptions[playerIndex];
    }

    public void SetWeapon(Sprite weaponSprite)
    {
        weaponImage.sprite = weaponSprite;
    }

    public void SetHP(int newHp)
    {
        hp.text = newHp.ToString();
        if (newHp == 0)
        {
            weaponImage.sprite = deadIcon;
        }
    }
}
