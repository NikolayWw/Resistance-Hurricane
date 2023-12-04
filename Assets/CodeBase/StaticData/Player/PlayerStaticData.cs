using CodeBase.StaticData.Items;
using UnityEngine;

namespace CodeBase.StaticData.Player
{
    [CreateAssetMenu(menuName = "Static Data/Player Static Data", order = 0)]
    public class PlayerStaticData : ScriptableObject
    {
        [field: SerializeField] public GameObject PlayerPrefab { get; private set; }
        [field: SerializeField] public ItemId StartItem { get; private set; }
        [field: SerializeField] public float StartHealth { get; private set; } = 5;
    }
}