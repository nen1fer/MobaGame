using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Effect
{
    public class BubbleShoot : MonoBehaviour
    {
        [SerializeField] private GameObject _bubble;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private float _spacing = 0.4f;

        private Vector3 _from;
        private Vector3 _to;

        public void Init(Vector3 from, Vector3 to)
        {
            _from = from;
            _to = to;
            StartCoroutine(Play());
        }

        private IEnumerator Play()
        {
            GameObject[] bubbles = new GameObject[3];
            Vector3 direction = (_to - _from).normalized;
            float totalOffset = _spacing * 2f;

            for (int i = 0; i < 3; i++)
            {
                float offset = (2 - i) * _spacing;
                Vector3 startPos = _from + direction * offset;
                bubbles[i] = Instantiate(_bubble, startPos, Quaternion.identity, transform);
            }

            float time = 0f;
            while (time < _duration)
            {
                time += Time.deltaTime;
                float progress = time / _duration;

                for (int i = 0; i < 3; i++)
                {
                    float offset = (2 - i) * _spacing;
                    Vector3 start = _from + direction * offset;
                    Vector3 end = _to + direction * offset;
                    bubbles[i].transform.position = Vector3.Lerp(start, end, progress);
                }

                yield return null;
            }

            foreach (var bubble in bubbles)
                Destroy(bubble);

            Destroy(gameObject);
        }
    }
}
