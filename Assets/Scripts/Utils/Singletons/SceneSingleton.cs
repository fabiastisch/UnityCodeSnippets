using UnityEngine;
namespace Utils
{
    /*
     * http://answers.unity.com/answers/1408687/view.html
     */
    public class SceneSingleton<T> : MonoBehaviour where T : SceneSingleton<T>
    {
        private static T _instance = null;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                        DontDestroyOnLoad(_instance.gameObject);
                    }
                }
                return _instance;
            }
        }

    }
}