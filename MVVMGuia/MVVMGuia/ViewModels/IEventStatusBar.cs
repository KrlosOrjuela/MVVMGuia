using System;
namespace MVVMGuia.ViewModels
{
    public interface IEventStatusBar
    {
        void HideStatusBar();
        void ShowStatusBar();
        void Translucent();
        void ChangeColor(string color);
    }
}

