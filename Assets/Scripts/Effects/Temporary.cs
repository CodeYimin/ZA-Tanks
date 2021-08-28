using UnityEngine;

namespace Effects
{
    public class Temporary : MonoBehaviour
    {
        [SerializeField] private float duration;
        private float _durationPassed;

        private void Update()
        {
            if (_durationPassed < duration)
            {
                _durationPassed += Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    
        public void SetDuration(float newDuration)
        {
            duration = newDuration;
        }
    }
}
