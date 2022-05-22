using UnityEngine;
namespace Utils
{
    /*
     * http://answers.unity.com/answers/1408687/view.html
     */
    public class SOSingleton<T> : ScriptableObject where T : SOSingleton<T>
    {
        private const string m_AssetPath = "Singletons/";
        private static T m_Instance = null;
        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = FindObjectOfType<T>();
                    if (m_Instance == null)
                    {
                        var m_Instance = Resources.Load<T>(m_AssetPath + typeof(T).Name);
                        if (m_Instance == null)
                            Debug.LogError("Singleton asset missing: " + m_AssetPath + typeof(T).Name);
                    }
                }
                return m_Instance;
            }
        }
    }
}