using System;
using System.Collections.Generic;
using System.Linq;

namespace TV.Helpers
{
    internal class ExtensionHelper
    {
        private readonly List<string> Supported = new List<string>
        {
            "jpg",
            "jpeg",
            "png",
            "gif",
            "svg"
        };

        internal bool TestFileExtension(string fileName)
        {
            var extension = GetExtension(fileName);
            return Supported.Contains(extension);
        }

        private string GetExtension(string fileName)
        {
            if (!fileName.Contains("."))
                throw new ArgumentException(nameof(fileName));
            return fileName.Split(".").Last();
        }
    }
}