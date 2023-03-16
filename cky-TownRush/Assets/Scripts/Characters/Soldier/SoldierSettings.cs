using UnityEngine;

namespace TownRush.Characters.Soldier
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Characters/Soldier Settings")]
    public class SoldierSettings : ScriptableObject
    {
        [field: SerializeField] public Transform PrefabTr { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; } = 3.0f;
        [field: SerializeField] public int Damage { get; private set; } = 1;
    }
}