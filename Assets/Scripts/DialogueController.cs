using DynamicBox.EventManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
	 [Header("Links")]
	 [SerializeField] private TMP_Text dialogueText;
	 [SerializeField] private TMP_Text mainCharacterText;
	 [SerializeField] private TMP_Text npcText;
	 [SerializeField] private Image mainCharacterImage;
	 [SerializeField] private Image npcImage;

	 [Header("Parameters")]
	 [Range(0.0001f,0.9999f)]
	 [SerializeField] private float dialogueWriteDelay;

	 private void OnEnable()
	 {
			EventManager.Instance.AddListener<OnDialogueEnterEvent>(OnDialogueEnterEventHandler);
	 }
	 private void OnDisable()
	 {
			EventManager.Instance.RemoveListener<OnDialogueEnterEvent>(OnDialogueEnterEventHandler);
	 }

	 private IEnumerator PlayDialogueCoroutine(DialogueDataSO dialogueData)
	 {
			for (int i = 0; i < dialogueData.dialogueLines.Length; i++)
			{
				 dialogueText.text = "";

				 DialogueLine currentLine = dialogueData.dialogueLines[i];

				 if (currentLine.isMainCharacter)
				 {
						mainCharacterText.gameObject.SetActive(true);

						npcText.gameObject.SetActive(false);

						mainCharacterText.text = currentLine.characterName;
				 }
				 else
				 {
						mainCharacterText.gameObject.SetActive(false);

						npcText.gameObject.SetActive(true);

						npcText.text = currentLine.characterName;
				 }

				 for (int j = 0; j < currentLine.characterQuote.Length; j++)
				 {
						dialogueText.text += currentLine.characterQuote[j];

						yield return new WaitForSeconds(dialogueWriteDelay);
				 }

				 yield return new WaitForSeconds(currentLine.dialogueLineDelay);
			}
	 }

	 private void OnDialogueEnterEventHandler(OnDialogueEnterEvent eventDetails)
	 {
			StartCoroutine(PlayDialogueCoroutine(eventDetails.DialogueData));
	 }
}
