using System;

namespace GHOST.UTILS
{
    public class Timer
    {
        private Action _onTimeUp;
        private readonly float _duration;
        private float _currentTime;
        private bool _timerActive;

        public Timer(float duration)
        {
            _duration = duration;
        }
    
        public void Begin(Action OnComplete)
        {
            _onTimeUp = OnComplete;
            _timerActive = true;
        }

        public void Reset()
        {
            _currentTime = 0;
            _timerActive = false;
        }

        public void Run(float delta)
        {
            if(!_timerActive) return;
        
            _currentTime += delta;

            if (_currentTime >= _duration)
            {
                _onTimeUp?.Invoke();
                _timerActive = false;
            }
        }
    }
}
