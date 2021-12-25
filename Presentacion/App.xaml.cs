using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Protectora
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ResourceDictionary DefineIdioma(string idioma)
        {
            var resourceDictionary = new ResourceDictionary();
            switch (idioma)
            {
                case "en-UK":
                    resourceDictionary.Source = new Uri(@"C:\Users\laura\source\repos\Protectora\idiomas\StringResources.en-UK.xaml", UriKind.Absolute);
                    break;
                case "es-ES":
                    resourceDictionary.Source = new Uri(@"C:\Users\laura\source\repos\Protectora\idiomas\StringResources.es-ES.xaml", UriKind.Absolute);
                    break;
            }
            return resourceDictionary;
        }
    }

}
