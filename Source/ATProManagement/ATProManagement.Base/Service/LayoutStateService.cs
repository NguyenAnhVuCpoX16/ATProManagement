
namespace ATProManagement.Base
{
    public class LayoutStateService
    {
        public bool IsDesktop  = true;

        public event Action? OnChange;

        public void SetDesktop(bool value)
        {
            if (IsDesktop == value)
                return;

            IsDesktop = value;

            OnChange?.Invoke();
        }
    }
}
