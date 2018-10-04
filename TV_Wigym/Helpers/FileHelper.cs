using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using TV.Controllers;
using TV.Models;

namespace TV.Helpers
{
    internal class FileHelper
    {
        public IFormFile TryGetImageFromRequestForm(HttpRequest request)
        {
            if (request.Form.Files.Count != 1)
                throw new Exception("No file submited!");

            var file = request.Form.Files.First();
            if (!_extensionHelpers.TestFileExtension(file.FileName))
                throw new Exception("Not supported extension!");
            return file;
        }

        public Image SaveImage(IFormFile file, Position position, string rootPath)
        {
            var id = ++LastImageId;

            var path = $"{rootPath}\\{id}-{file.FileName}";

            var image = new Image
            {
                Id = id,
                FileName = file.FileName,
                Url = $"{_config.ImagesPath}{id}-{file.FileName}"
            };

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            LastImageId = id;
            SaveNewImageToJson(image, position);
            return image;
        }

        public void SaveNewImageToJson(Image image, Position position)
        {
            var data = GetDataFromJson();
            var section = data.Sections.First(x => x.Position == position);
            section.Images.Add(image);
            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText(_config.JsonPath, json);
        }

        public DisplayData GetDataFromJson()
        {
            var json = File.ReadAllText(_config.JsonPath);
            return JsonConvert.DeserializeObject<DisplayData>(json);
        }


        public void DeleteImage(int id)
        {
            var data = GetDataFromJson();
            var images = data.Sections.SelectMany(x => x.Images);
            var img = images.Single(x => x.Id == id);
            images.ToList().Remove(img);
            SaveData(data);
        }

        #region Props and ctor

        private readonly ExtensionHelper _extensionHelpers;
        private readonly WigymTvConfig _config;

        public FileHelper(WigymTvConfig config)
        {
            _config = config;
            _extensionHelpers = new ExtensionHelper();
        }

        #endregion

        #region Private Methods

        private int LastImageId
        {
            get => Convert.ToInt32(File.ReadAllText(_config.LastImageIdPath));
            set => File.WriteAllText(_config.LastImageIdPath, value.ToString());
        }

        private void SaveData(DisplayData data)
        {
            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText(_config.JsonPath, json);
        }

        #endregion
    }
}