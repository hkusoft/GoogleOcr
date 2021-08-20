using Google.Cloud.Vision.V1;
using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoogleOcrLib
{
    public class GoogleOcr
    {        
        private static string GetMimeType(string path)
        {
            if (Utility.IsImageFile(path))
                return "image/gif";
            else if (Utility.IsFileType(path, ".tif"))
                return "image/tiff";
            else if (Utility.IsFileType(path, ".pdf"))
                return "application/pdf";

            return null;
        }

        public static string Load(string path)
        {            
            try
            {
                string output = null;
                if (!File.Exists(path))
                    return null;

                var client = ImageAnnotatorClient.Create();
                Byte[] bytes = File.ReadAllBytes(path);
                var content_byte = ByteString.CopyFrom(bytes);

                var syncRequest = new AnnotateFileRequest
                {
                    InputConfig = new InputConfig
                    {
                        Content = content_byte,
                        MimeType = GetMimeType(path)
                    }
                };

                syncRequest.Features.Add(new Feature
                {                 
                    Type = Feature.Types.Type.TextDetection
                });

                List<AnnotateFileRequest> requests = new List<AnnotateFileRequest>();
                requests.Add(syncRequest);

                var response = client.BatchAnnotateFiles(requests).Responses.FirstOrDefault();
                output =  response?.Responses[0]?.FullTextAnnotation?.Text;
                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }            
        }
    }
}
