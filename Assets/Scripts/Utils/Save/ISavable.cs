namespace Utils.Save
{
    public interface ISavable
    {
        object CaptureState();
        void RestoreState(object state);
    }
}