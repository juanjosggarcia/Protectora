using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Protectora
{
    public partial class App : Application
    {
        public static ResourceDictionary DefineIdioma(string idioma)
        {
            var resourceDictionary = new ResourceDictionary();
            switch (idioma)
            {
                case "en-UK":
                    resourceDictionary.Source = new Uri(@"..\idiomas\StringResources.en-UK.xaml", UriKind.Relative);
                    break;
                case "es-ES":
                    resourceDictionary.Source = new Uri(@"..\idiomas\StringResources.es-ES.xaml", UriKind.Relative);
                    break;
            }
            return resourceDictionary;
        }
    }

}
