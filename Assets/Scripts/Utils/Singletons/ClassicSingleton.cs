namespace Utils
{
    /*
     * http://answers.unity.com/answers/1408687/view.html
     */
    public class ClassicSingleton<T> where T : ClassicSingleton<T>
    {
        public static readonly T Instance = (T) new ClassicSingleton<T>();
        private ClassicSingleton() { }
        

    }
}