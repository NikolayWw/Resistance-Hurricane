using CodeBase.StaticData.Enemy;
using CodeBase.StaticData.Items;
using CodeBase.StaticData.Items.Weapon.MeleeWeapon;
using CodeBase.StaticData.Level;
using CodeBase.StaticData.Player;
using CodeBase.StaticData.Windows;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string WindowStaticDataPath = "Windows/WindowStaticData";
        private const string PlayerStaticDataPath = "Player/PlayerStaticData";
        private const string MeleeWeaponStaticDataPath = "Items/MeleeWeapon/MeleeWeaponStaticData";
        private const string EnemyStaticDataPath = "Enemy/EnemyStaticData";
        private const string LevelStaticDataPath = "Level/LevelStaticData";

        public WindowStaticData WindowData { get; private set; }
        public PlayerStaticData PlayerData { get; private set; }
        public LevelStaticData LevelStaticData { get; private set; }
        private Dictionary<EnemyId, EnemyConfig> _enemyConfigs;

        private Dictionary<ItemId, MeleeWeaponConfig> _meleeWeaponConfigs;

        public void Load()
        {
            PlayerData = Resources.Load<PlayerStaticData>(PlayerStaticDataPath);
            _meleeWeaponConfigs = Resources.Load<MeleeWeaponStaticData>(MeleeWeaponStaticDataPath).ItemConfigs.ToDictionary(x => x.ItemId, x => x);
            _enemyConfigs = Resources.Load<EnemyStaticData>(EnemyStaticDataPath).EnemyConfigs.ToDictionary(x => x.Id, x => x);
            LevelStaticData = Resources.Load<LevelStaticData>(LevelStaticDataPath);
            WindowData = Resources.Load<WindowStaticData>(WindowStaticDataPath);
        }

        public MeleeWeaponConfig ForMeleeWeapon(ItemId itemId) =>
            _meleeWeaponConfigs.TryGetValue(itemId, out MeleeWeaponConfig cfg) ? cfg : null;

        public EnemyConfig ForEnemy(EnemyId id) =>
            _enemyConfigs.TryGetValue(id, out EnemyConfig cfg) ? cfg : null;
    }
}