using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityTypes
{
    Speed,
    Battery,
    Shield
}

public class AbilityPickup : MonoBehaviour
{
    [SerializeField] private AbilityTypes abilityType;
    public AbilityTypes AbilityTypes { get { return abilityType; } }


    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerController playerController);

        if (!playerController)
            return;

        playerController.UpgradeAbility(abilityType);

        Destroy(gameObject);
    }
}
