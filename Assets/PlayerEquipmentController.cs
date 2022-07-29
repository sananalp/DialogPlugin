using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentController : MonoBehaviour
{
	 [SerializeField] private SkinnedMeshRenderer characterSMR;

	 [Header("Equipment Pieces")]
	 [SerializeField] private GameObject headEquipment;
	 [SerializeField] private GameObject bodyEquipment;
	 [SerializeField] private GameObject legsEquipment;
	 [SerializeField] private GameObject feetEquipment;

	 [Header("Equipment Data")]
	 [SerializeField] private EquipmentDataSO headData;
	 [SerializeField] private EquipmentDataSO bodyData;
	 [SerializeField] private EquipmentDataSO legsData;
	 [SerializeField] private EquipmentDataSO feetData;

	 public void EquipItem(EquipmentDataSO equipmentData)
	 {
			GameObject equipmentInstance = Instantiate(equipmentData.equipmentSMR, transform);

			SkinnedMeshRenderer equipmentSMR = equipmentInstance.GetComponent<SkinnedMeshRenderer>();

			equipmentSMR.rootBone = characterSMR.rootBone;

			equipmentSMR.bones = characterSMR.bones;


			switch (equipmentData.equipmentType)
			{
			case EquipmentType.HEAD:
				headEquipment = equipmentInstance;

				headData = equipmentData;

				break;
			case EquipmentType.BODY:
				bodyEquipment = equipmentInstance;

				bodyData = equipmentData;

				break;
			case EquipmentType.LEGS:
				legsEquipment = equipmentInstance;

				legsData = equipmentData;

				break;
			case EquipmentType.FEET:
				feetEquipment = equipmentInstance;

				feetData = equipmentData;

				break;
		}
	 }
}
