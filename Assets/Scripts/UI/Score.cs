using TMPro;
using UnityEngine;

namespace FallingBalls.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class Score : MonoBehaviour
    {
        private TMP_Text _scoreText;
        private int _value;

        private void Awake()
        {
            _scoreText = GetComponent<TMP_Text>();
        }

        public void AddScore(int value)
        {
            _value += value;
            _scoreText.SetText($"Score: {_value}");
        }

        public void Reset()
        {
            _value = 0;
            _scoreText.SetText($"Score: {_value}");
        }
    }
}