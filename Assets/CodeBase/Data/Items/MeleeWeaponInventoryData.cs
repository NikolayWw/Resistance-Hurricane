using CodeBase.StaticData.Items;
using System;

namespace CodeBase.Data.Items
{
    [Serializable]
    public class MeleeWeaponInventoryData : BaseItemInventoryData
    {
        public MeleeWeaponInventoryData(ItemId id) : base(id)
        {
        }
    }
}