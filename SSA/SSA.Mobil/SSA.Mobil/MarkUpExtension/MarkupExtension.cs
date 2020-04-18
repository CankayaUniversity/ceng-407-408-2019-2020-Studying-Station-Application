using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSA.Mobil.MarkUpExtension
{
    [ContentProperty(nameof(Source))]
    public class MarkupExtension:IMarkupExtension
    {
        public string Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            var imageSource = ImageSource.FromResource(Source, typeof(MarkupExtension).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}
