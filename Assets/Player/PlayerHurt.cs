using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour, IHurt
{
    public void TriggerHurtBehavior()
    {
        AudioManager.Instance.PlayDialog(int.Parse(gameObject.name), AudioManager.DIALOG_HURT, false);
    }
}
