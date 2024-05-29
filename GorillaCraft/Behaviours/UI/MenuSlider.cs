using UnityEngine;

namespace GorillaCraft.Behaviours.UI
{
    public abstract class MenuSlider : MonoBehaviour
    {
        /// <summary>
        /// The current hand-indicator using the slider.
        /// </summary>
        public GorillaTriggerColliderHandIndicator Current;

        /// <summary>
        /// The amount of pieces the slider is divided up into.
        /// </summary>
        public int Split = 6;

        /// <summary>
        /// The current value of the slider.
        /// </summary>
        public float Value;

        private Transform slider, min, max;

        public abstract void OnSliderAdjust(bool select);

        public void Awake()
        {
            slider = transform.Find("Slider");
            min = transform.Find("Min");
            max = transform.Find("Max");

            gameObject.SetLayer(UnityLayer.GorillaInteractable);
            GetComponent<Collider>().isTrigger = true;
        }

        public void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out GorillaTriggerColliderHandIndicator component) && !component.isLeftHand && (Current == null || Current == component))
            {
                Vector3 local = transform.InverseTransformPoint(component.transform.position);
                float tbaValue = Mathf.RoundToInt(Mathf.Clamp01((local.x - min.localPosition.x) / (max.localPosition.x * 2f)) * Split) / (float)Split;
                slider.transform.localPosition = Vector3.Lerp(min.localPosition, max.localPosition, tbaValue);

                if (tbaValue != Value)
                {
                    Value = tbaValue;
                    OnSliderAdjust(true);

                    if (Current != null) GorillaTagger.Instance.StartVibration(component.isLeftHand, 0.1f, 0.015f);
                }

                if (Current == null)
                {
                    Current = component;
                    GorillaTagger.Instance.StartVibration(component.isLeftHand, 0.25f, 0.05f);
                }
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out GorillaTriggerColliderHandIndicator component) && Current == component)
            {
                Current = null;
                OnSliderAdjust(false);
            }
        }
    }
}
