using UnityEngine;

namespace CodeBase.StaticData.Items
{
    public abstract class BaseItemConfig
    {
        [SerializeField] private string _inspectorName;
        [field: SerializeField] public ItemId ItemId { get; private set; }

        public virtual void OnValidate()
        {
            _inspectorName = ItemId.ToString();
        }

        protected void ResetItemId()
        {
            ItemId = ItemId.None;
            _inspectorName = "none";
        }
    }
}