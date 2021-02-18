using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayObjectives : MonoBehaviour
{
    [SerializeField] GameObject objectiveListItem;
    [SerializeField] GameObject objectiveParent;
    private GameObject[] objectiveListItems;

    public float initialOffset = 50f;
    public float offset = 100f;

    private void Start()
    {
        Objective[] objectives = GameManager.Instance.GetObjectives().GetObjectives();
        objectiveListItems = new GameObject[objectives.Length];

        Vector3 initialPosition = new Vector3(objectiveParent.transform.position.x, objectiveParent.transform.position.y - initialOffset, objectiveParent.transform.position.z);

        for (int i = 0; i < objectives.Length; i++)
        {
            objectiveListItems[i] = Instantiate(objectiveListItem, objectiveParent.transform);
            objectiveListItems[i].transform.position = new Vector3(initialPosition.x, initialPosition.y - (offset * i), initialPosition.z);
            TextMeshProUGUI[] textFields = objectiveListItems[i].GetComponentsInChildren<TextMeshProUGUI>();
            for (int j = 0; j < textFields.Length; j++)
            {
                if (textFields[j].name == "Title")
                {
                    textFields[j].SetText(objectives[i].name);
                }
                else if (textFields[j].name == "Text")
                {
                    textFields[j].SetText(objectives[i].text);
                }
            }

            Image[] checkImages = objectiveListItems[i].GetComponentsInChildren<Image>();
            for (int j = 0; j < checkImages.Length; j++)
            {
                if (checkImages[j].name == "Checkmark")
                {
                    checkImages[j].color = Color.clear;
                }
            }
        }
    }

    public void MarkComplete(int index)
    {
        Image[] checkImages = objectiveListItems[index].GetComponentsInChildren<Image>();
        for (int i = 0; i < checkImages.Length; i++)
        {
            checkImages[i].color = Color.white;
        }
    }
}
