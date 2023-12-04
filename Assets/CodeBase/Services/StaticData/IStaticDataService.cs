using CodeBase.StaticData.Enemy;
using CodeBase.StaticData.Items;
using CodeBase.StaticData.Items.Weapon.MeleeWeapon;
using CodeBase.StaticData.Level;
using CodeBase.StaticData.Player;
using CodeBase.StaticData.Windows;

namespace CodeBase.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();

        WindowStaticData WindowData { get; }
        PlayerStaticData PlayerData { get; }
        LevelStaticData LevelStaticData { get; }

        MeleeWeaponConfig ForMeleeWeapon(ItemId itemId);

        EnemyConfig ForEnemy(EnemyId id);
    }
}