using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    [SerializeField] Objective[] objectives;

    public void CompleteObjective(Objective objective)
    {
        for (int i = 0; i < objectives.Length; i++)
        {
            if (objectives[i].name == objective.name)
            {
                objectives[i].Complete();
                return;
            }
        }
        Debug.LogError("Objective complete, but it was not found in the list of required Objectives. See GameManager.");
    }

    public Objective GetObjective(Objective likeThis)
    {
        for (int i = 0; i < objectives.Length; i++)
        {
            if (objectives[i].name == likeThis.name)
            {
                return objectives[i];
            }
        }
        return null;
    }
}
