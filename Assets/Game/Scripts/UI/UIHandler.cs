using UnityEngine;

namespace Runner.UI
{
    public class UIHandler : MonoBehaviour 
    {
        [SerializeField] private RectTransform _runnerPanel;
        [SerializeField] private RectTransform _paintPanel;
        [SerializeField] private RectTransform _gameFinishedPanel;
        

        private void Start() 
        {
            Singleton.Instance.PhaseManager.onRunnerPhaseStart += RunnerPhaseUI;
            Singleton.Instance.PhaseManager.onPaintingPhaseStart += PaintPhaseUI;
            Singleton.Instance.PhaseManager.onGameFinished += GameFinishedUI;
            _runnerPanel.gameObject.SetActive(false);
            _paintPanel.gameObject.SetActive(false);
            _gameFinishedPanel.gameObject.SetActive(false);
        }

        private void RunnerPhaseUI()
        {
            _runnerPanel.gameObject.SetActive(true);
        }

        private void PaintPhaseUI()
        {
            _runnerPanel.gameObject.SetActive(false);
            _paintPanel.gameObject.SetActive(true);
        }

        private void GameFinishedUI()
        {
            _paintPanel.gameObject.SetActive(false);
            _gameFinishedPanel.gameObject.SetActive(true);
        }
    }
}