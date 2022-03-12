using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FaceRecognition;

public static class WebcamHelper
{
    public static List<string> TakeAllWebCamera()
    {
        FilterInfoCollection filter = new(FilterCategory.VideoInputDevice);
        List<string> listCamera = new();
        listCamera.AddRange(from FilterInfo f in filter
                            select f.Name.ToString());

        return listCamera.Count >= 1
            ? listCamera
            : throw new NullReferenceException("No cameras found.");
    }
}