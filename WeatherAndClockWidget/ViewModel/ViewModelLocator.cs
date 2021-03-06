using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using WeatherAndClockWidget.Service;
using WeatherAndClockWidget.Service.Interface;
using WeatherAndClockWidget.Service.Mock;

namespace WeatherAndClockWidget.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                SimpleIoc.Default.Register<IStatePersister, StatePersisterMock>();
                SimpleIoc.Default.Register<IGetWeatherFunction, GetWeatherFunctionMock>();
                SimpleIoc.Default.Register<IWeatherDataDownloader, WeatherDataDownloaderMock>();
                SimpleIoc.Default.Register<IConfigReader, ConfigReaderMock>();
            }
            else
            {
                // Create run time view services and models
                SimpleIoc.Default.Register<IStatePersister, StatePersister>();
                SimpleIoc.Default.Register<IGetWeatherFunction, GetWeatherFunction>();
                SimpleIoc.Default.Register<IWeatherDataDownloader, WeatherDataDownloader>();
                SimpleIoc.Default.Register<IConfigReader, ConfigReader>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public static void Cleanup()
        {
        }
    }
}