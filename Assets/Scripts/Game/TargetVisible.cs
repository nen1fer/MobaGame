using UnityEngine;

namespace Assets.Scripts.Game
{
    public class TargetVisible : MonoBehaviour
    {
        public void SetVisible(bool visible)
        {
            gameObject.SetActive(visible);
        }
    }
}