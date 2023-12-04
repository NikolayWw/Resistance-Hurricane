using CodeBase.Data.Items;
using CodeBase.Player.ItemInHandStates;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Player;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerChangeItemInHand : MonoBehaviour
    {
        [SerializeField] private PlayerItemInHandStateMachine _itemInHandMachine;
        private PlayerStaticData _playerConfig;

        public void Construct(IStaticDataService dataService)
        {
            _playerConfig = dataService.PlayerData;
        }

        private void Start()
        {
            _itemInHandMachine.EnterMeleeWeapon(new MeleeWeaponInventoryData(_playerConfig.StartItem));
        }
    }
}