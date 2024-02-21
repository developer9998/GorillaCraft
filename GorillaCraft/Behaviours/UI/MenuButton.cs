using UnityEngine;

namespace GorillaCraft.Behaviours.UI
{
    public abstract class MenuButton : MonoBehaviour
    {
        private float pressTime;
        public float pressDebounce = 0.25f;

        public void Start()
        {
            gameObject.layer = 18;
            GetComponent<Collider>().isTrigger = true;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out GorillaTriggerColliderHandIndicator indicator) || pressTime > Time.unscaledTime || indicator != null && indicator.isLeftHand) return;
            pressTime = Time.unscaledTime + pressDebounce;

            GorillaTagger.Instance.StartVibration(indicator.isLeftHand, 0.15f, 0.05f);
            OnPress();
        }

        public abstract void OnPress();
    }
}
