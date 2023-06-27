using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillfactory.Module18.YoutubeVideoDownloader.CustomExtensionMethods
{
    public static class StringExtension
    {
        public static string GetSafeFileName(this string str)
        {
            StringBuilder result = new StringBuilder();
            var invalidChars = Path.GetInvalidFileNameChars();
            foreach (char c in str)
            {
                if (invalidChars.Contains(c))
                {
                    result.Append('_');
                } else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
    }
}
