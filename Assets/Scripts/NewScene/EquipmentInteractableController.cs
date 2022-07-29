using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInteractableController : MonoBehaviour
{
	 [SerializeField] private EquipmentDataSO equipmentData;

	 public EquipmentDataSO ReturnEquipmentData()
	 {
			return equipmentData;
	 }
}
