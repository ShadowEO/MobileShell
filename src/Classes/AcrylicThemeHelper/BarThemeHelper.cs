using System;
using Windows.UI;
//using Windows.UI.Xaml.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using MobileShell.Classes.AcrylicThemeHelper;

namespace MobileShell.Classes
{
    class BarThemeHelper
    {
        public const int WINDOWS_THEME_LIGHT = 0;
        public const int WINDOWS_THEME_DARK = 1;
        public const int WINDOWS_THEME_AUTO = 2;

        public void updateTheme(Window windowObj, int theme = BarThemeHelper.WINDOWS_THEME_LIGHT)
        {
            if (SystemParameters.IsGlassEnabled == true)
            {
                
                new AcrylicBlur(windowObj).EnableBlur();
                if(theme == WINDOWS_THEME_AUTO)
                {
                    WindowsThemeHelper.WindowsTheme currentSystemTheme = MobileShell.Classes.AcrylicThemeHelper.WindowsThemeHelper.GetWindowsTheme();
                    if (currentSystemTheme == WindowsThemeHelper.WindowsTheme.Light)
                    {
                        theme = 0;
                    } else
                    {
                        theme = 1;
                    }
                }
                switch (theme)
                {
                    case WINDOWS_THEME_LIGHT:
                        // Update Status bar elements
                        App.stBar.gridAcrylicBackground.Background = SystemParameters.WindowGlassBrush;
                        App.stBar.gridAcrylicBackground.Opacity = 0.25;
                        App.stBar.batteryGlyph.Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
                        App.stBar.roamingGlyph.Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
                        //TODO: 6/3/2019 finish this!
                        // Other elements need their colors changed.
                        break;
                    case WINDOWS_THEME_DARK:
                        windowObj.gridAcrylicBackground.Background = new SolidColorBrush(Colors.White);
                        windowObj.gridAcrylicBackground.Opacity = 0.70;
                        // Other elements need their colors changed.
                        break;
                    default:
                        break;
                }
            }
            else
            {
                // We're not in the mode to allow use of Acrylics.
                gridTaskbarAcrylicBackground.Background = new SolidColorBrush(Colors.Black);
                gridTaskbarAcrylicBackground.Opacity = 1;

                windowsLogo.Fill = SystemParameters.WindowGlassBrush;
            }
        }
    }
}
