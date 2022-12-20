using System;
namespace MVVMGuia.Interfaces
{
    public interface IEventStatusBar
    {
        void HideStatusBar();
        void ShowStatusBar();
        void Translucent();
        void ChangeColor(string color);
    }
}

