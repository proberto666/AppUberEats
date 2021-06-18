using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UberEats.Services
{
    public class ImageService
    {
        public ImageSource ConvertImageFromBase64ToImageSource(string imageBase64)
        {
            if (!string.IsNullOrEmpty(imageBase64))
            {
                return ImageSource.FromStream(() =>
                new MemoryStream(System.Convert.FromBase64String(imageBase64))
                );
            }
            else
            {
                return null;
            }
        }

        public async Task<string> ConvertImageFilePathToBase64(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                FileStream stream = File.Open(filePath, FileMode.Open);
                byte[] bytes = new byte[stream.Length];
                await stream.ReadAsync(bytes, 0, (int)stream.Length);
                return System.Convert.ToBase64String(bytes);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
