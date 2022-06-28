
using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using AdminDashboard.Server.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Repository.Implementation
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _env;
        public FileUpload(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void RemoveFile(string picName)
        {
            var path = $"{_env.WebRootPath}\\images\\{picName}";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public async Task UploadFile(IFileListEntry file, string picName)
        {

            var ms = new MemoryStream();
            await file.Data.CopyToAsync(ms);

            var path = $"{_env.WebRootPath}\\images\\{picName}";
            try
            {
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                ms.WriteTo(fs);
            }

        }
        public void UploadFile(IFileListEntry file, MemoryStream msFile, string picName)
        {
            try
            {
                var path = $"{_env.WebRootPath}\\images";
                var pathUpdated = $"{_env.WebRootPath}\\images\\{picName}";
                try
                {
                    if (!Directory.Exists(path))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(path);
                    }
                }
                catch (IOException ioex)
                {
                    Console.WriteLine(ioex.Message);
                }
                using (FileStream fs = new FileStream(pathUpdated, FileMode.Create,FileAccess.Write))
                {
                    msFile.WriteTo(fs);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
