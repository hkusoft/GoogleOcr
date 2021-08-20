# GoogleOcr

This repository showcases how to perform OCR using Google Vision API.


## PDF OCR Example
https://github.com/hkusoft/GoogleOcr/blob/main/GoogleOcrLibTests/Samples/PDF/Abc.pdf

```CSharp
var text = GoogleOcr.Load("Samples/TIFF/Abc.tif");
Assert.IsNotNull(text);
Assert.IsTrue(text.Contains("Abc"));
Assert.IsTrue(text.Contains("This is a text"));
```

## GIF OCR Example

![GIF OCR](https://github.com/hkusoft/GoogleOcr/blob/main/GoogleOcrLibTests/Samples/GIF/TestClass.gif?raw=true)
```CSharp
    var text = GoogleOcr.Load("Samples/Gif/TestClass.gif");
    Assert.IsNotNull(text);
    Assert.IsTrue(text.Contains("TestClass"));
    Assert.IsTrue(text.Contains("GoogleOcrTests"));
```

------

## Method I: Set up a project in Google Cloud Console 

1. Follow [Quickstart: Using client libraries](https://cloud.google.com/vision/docs/quickstart-client-libraries) to create a Google Cloud project. 
2. After setup, you will get a key json file, download it and save it to a local file, e.g. c:\abc\key.json
3. Set the environment variable GOOGLE_APPLICATION_CREDENTIALS to the path of the JSON file that contains your service account key. 

## Method II: Set up a project using Google Cloud Shell (Recommended)

1. Follow this [CodeLabs tutorial](https://codelabs.developers.google.com/codelabs/cloud-vision-api-csharp#0) to create a new project
2. Open a Cloud Shell and type below code

```
gcloud auth list
gcloud services enable vision.googleapis.com
export GOOGLE_CLOUD_PROJECT=$(gcloud config get-value core/project)
gcloud iam service-accounts create my-vision-sa --display-name "my vision service account"
gcloud iam service-accounts keys create ~/key.json --iam-account my-vision-sa@${GOOGLE_CLOUD_PROJECT}.iam.gserviceaccount.com
export GOOGLE_APPLICATION_CREDENTIALS=~/key.json
```

Then run below code and copy the `key.json` file content to the clipboard
```
cat ~/key.json | pbcopy
```

- In your develop machine (not Google Cloud Shell), paste the content and save it to a file key.json
- Set the environment variable GOOGLE_APPLICATION_CREDENTIALS to the path of the JSON file that contains your service account key. 


## References

- [.NET reference documentation for the Cloud Vision API.](https://googleapis.dev/dotnet/Google.Apis.Vision.v1/latest/api/Google.Apis.Vision.v1.html)
- [Using the Vision API with C#](https://codelabs.developers.google.com/codelabs/cloud-vision-api-csharp#0)
