using UnityEngine;

namespace GorillaCraft.Behaviours.UI
{
    public abstract class MenuButton : MonoBehaviour
    {
        private const float Debounce = 0.125f;

        private float _pressTime;

        private GorillaTriggerColliderHandIndicator _current;

        private void Awake()
        {
            gameObject.layer = 18;
            GetComponent<Collider>().isTrigger = true;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out GorillaTriggerColliderHandIndicator indicator) && _current != indicator && !indicator.isLeftHand && Time.realtimeSinceStartup > _pressTime)
            {
                _current = indicator;
                _pressTime = Time.realtimeSinceStartup + Debounce;

                GorillaTagger.Instance.StartVibration(indicator.isLeftHand, 0.3f, 0.04f);
                OnButtonActivation(true);
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out GorillaTriggerColliderHandIndicator indicator) && _current == indicator)
            {
                _current = null;
                OnButtonActivation(false);
            }
        }

        public abstract void OnButtonActivation(bool select);
    }
}
