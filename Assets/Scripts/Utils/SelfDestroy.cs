using UnityEngine;
namespace Utils
{
    public class SelfDestroy : MonoBehaviour
    {
        [SerializeField] private float timeToDestroy;

        private void Update()
        {
            timeToDestroy -= timeToDestroy;
            if (timeToDestroy <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }
}