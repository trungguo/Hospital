// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Hospital.Utilities
{
    public class ImageOperations
    {
        IWebHostEnvironment _env;
        public ImageOperations(IWebHostEnvironment env)
        {
            _env=env;
        }

        public string ImageUpload(IFormFile file)
        {
            string filename = null;
            if(file!=null)
            {
                string fileDirectory= Path.Combine(_env.WebRootPath, "Image");
                filename = Guid.NewGuid() + "_" + file.FileName;
                string filepath= Path.Combine(fileDirectory, filename);
                using (FileStream fs = new FileStream(filepath, FileMode.Create))
                {
                    file.CopyToAsync(fs);
                }
            }
            return filename;

        }
    }
}