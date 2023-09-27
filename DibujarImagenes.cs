using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if IOS || ANDROID || MACCATALYST
using Microsoft.Maui.Graphics.Platform;
#elif WINDOWS
using Microsoft.Maui.Graphics.Win2D;
#endif
using System.Reflection;
using IImage = Microsoft.Maui.Graphics.IImage;

using System.Security.Cryptography.X509Certificates;

namespace GraficosImagenes 
{
    public class DibujarImagenes  : IDrawable
    {
        IImage image;
        public DibujarImagenes()
        {
            
            
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("GraficosImagenes.Resources.Images.DibujoPrueba.jpg"))
            {
#if IOS || ANDROID || MACCATALYST
                // PlatformImage isn't currently supported on Windows.
                image = PlatformImage.FromStream(stream);
#elif WINDOWS
    image = new W2DImageLoadingService().FromStream(stream);
#endif
            }
        }

        public void Draw(ICanvas canvas, Microsoft.Maui.Graphics.RectF dirtyRect)
        {


            IImage newImage = image.Downsize(100, true);
            //IImage newImage = image.Resize(100, 60, ResizeMode.Bleed, true);
                //canvas.DrawImage(newImage, 10, 10, newImage.Width, newImage.Height);
                //canvas.DrawImage(image,10,10, image.Width, image.Height);
                using (MemoryStream memStream = new MemoryStream())
                {
                    newImage.Save(memStream);
                }
            

        }
    }
}
