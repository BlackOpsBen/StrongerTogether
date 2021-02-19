using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour, IDie
{
    public void Die()
    {
        AudioManager.Instance.PlayDialog(4, AudioManager.DIALOG_DEAD, false); // TODO make not play 100%
        gameObject.SetActive(false);
        GameManager.Instance.IncreaseKillCount();
    }
}
