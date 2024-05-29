using GorillaLocomotion;
using UnityEngine;

namespace GorillaCraft.Behaviours.UI
{
    public abstract class MenuButton : MonoBehaviour
    {
        private bool Viewed => Vector3.Dot(Player.Instance.headCollider.transform.forward, (transform.position - Player.Instance.headCollider.transform.position).normalized) > 0.64f;

        private float _pressTime;

        private GorillaTriggerColliderHandIndicator _current;

        public void Awake()
        {
            gameObject.SetLayer(UnityLayer.GorillaInteractable);
            GetComponent<Collider>().isTrigger = true;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out GorillaTriggerColliderHandIndicator indicator) && _current != indicator && !indicator.isLeftHand && Time.realtimeSinceStartup > (_pressTime + 0.125f) && Viewed)
            {
                _current = indicator;
                _pressTime = Time.realtimeSinceStartup;

                GorillaTagger.Instance.StartVibration(indicator.isLeftHand, 0.4f, 0.04f);
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
