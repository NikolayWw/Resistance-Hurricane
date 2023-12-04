using System;
using UnityEngine;

namespace CodeBase.StaticData.Items.Weapon.MeleeWeapon
{
    [Serializable]
    public class MeleeWeaponConfig : BaseItemConfig
    {
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float AttackRadius { get; private set; } = 0.5f;
        [field: SerializeField] public float DelayBeforeAttack { get; private set; } = 1f;
        [field: SerializeField] public float DelayBeforeApplyDamage { get; private set; } = 0.4f;
        [field: SerializeField] public string AttackAnimationName { get; private set; } = "AttackSword";

        public override void OnValidate()
        {
            base.OnValidate();

            if (Damage < 0)
                Damage = 0;
        }
    }
}