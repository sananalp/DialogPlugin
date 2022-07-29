using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
	 private void OnTriggerEnter(Collider other)
	 {
			if (other.CompareTag("DialogueNPC"))
			{
				 DialogueDataSO dialogueData = other.GetComponent<NPCDialogueHolder>().ReturnDialogueData();

				 EventManager.Instance.Raise(new OnDialogueEnterEvent(dialogueData));
			}
	 }
}
