using CodeBase.Data;
using CodeBase.Services.Input;
using CodeBase.Services.LogicFactory;
using CodeBase.Services.PersistentProgress;
using CodeBase.Services.StaticData;

namespace CodeBase.Services.Cleanup
{
    public class CleanupService : ICleanupService
    {
        private readonly IInputService _inputService;
        private readonly ILogicFactory _logicFactory;
        private readonly IPersistentProgressService _progressService;
        private readonly IStaticDataService _dataService;

        public CleanupService(IInputService inputService, ILogicFactory logicFactory, IPersistentProgressService progressService, IStaticDataService dataService)
        {
            _inputService = inputService;
            _logicFactory = logicFactory;
            _progressService = progressService;
            _dataService = dataService;
        }

        public void Cleanup()
        {
            _inputService.Cleanup();
            _logicFactory.Cleanup();

            _progressService.PlayerProgress = new PlayerProgress(_dataService.PlayerData.StartHealth);
        }
    }
}