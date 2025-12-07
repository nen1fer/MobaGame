using UnityEngine;

namespace Assets.Scripts.GUI
{
    public class TargetVisible : MonoBehaviour
    {
        public void SetVisible(bool visible)
        {
            gameObject.SetActive(visible);
        }
    }
}