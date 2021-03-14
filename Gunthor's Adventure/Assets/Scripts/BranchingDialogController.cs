using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class BranchingDialogController : MonoBehaviour
{
    [SerializeField] private GameObject branchingCanvas;
    [SerializeField] private GameObject dialogPrefab;
    [SerializeField] private GameObject choicePrefab;
    [SerializeField] private TextAssetValue dialogValue;
    [SerializeField] private Story myStory;
    [SerializeField] private GameObject dialogHolder;
    [SerializeField] private GameObject choiceHolder;
    [SerializeField] private ScrollRect dialogScroll;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnableCanvas()
    {
        branchingCanvas.SetActive(true);
        SetStory();
        RefreshView();
    }

    public void SetStory()
    {
        if (dialogValue.value)
        {
            myStory = new Story(dialogValue.value.text);
        }
        else
        {
            Debug.Log("Something went wrong with the story setup.");
        }
    }

    public void RefreshView()
    {
        while (myStory.canContinue)
        {
            MakeNewDialog(myStory.Continue());
        }

        if (myStory.currentChoices.Count > 0)
        {
            MakeNewChoices();
        }
        else
        {
            branchingCanvas.SetActive(false);
        }

        StartCoroutine(ScrollCo());
    }

    IEnumerator ScrollCo()
    {
        yield return null;
        dialogScroll.verticalNormalizedPosition = 0f;
    }

    void MakeNewDialog(string newDialog)
    {
        DialogObject newDialogObject = Instantiate(dialogPrefab, dialogHolder.transform).GetComponent<DialogObject>();
        newDialogObject.Setup(newDialog);
    }

    void MakeNewChoices()
    {
        for (int i = 0; i < choiceHolder.transform.childCount; i++)
        {
            Destroy(choiceHolder.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < myStory.currentChoices.Count; i++)
        {
            MakeNewResponse(myStory.currentChoices[i].text, i);
        }
    }

    void MakeNewResponse(string newDialog, int choiceValue)
    {
        ButtonObject newButtonObject = Instantiate(choicePrefab, choiceHolder.transform).GetComponent<ButtonObject>();
        newButtonObject.Setup(newDialog, choiceValue);
        Button responseButton = newButtonObject.gameObject.GetComponent<Button>();
        if (responseButton)
        {
            responseButton.onClick.AddListener(delegate { ChooseChoice(choiceValue); });
        }
    }

    void ChooseChoice(int choice)
    {
        myStory.ChooseChoiceIndex(choice);
        RefreshView();
    }
}