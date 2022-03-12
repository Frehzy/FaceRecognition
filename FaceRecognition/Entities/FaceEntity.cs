using Emgu.CV;
using Emgu.CV.Structure;
using FaceRecognition.Enums;
using System;
using System.Drawing;

namespace FaceRecognition.Entities;

public class FaceEntity
{
    public string Name { get; private set; }

    public Image<Gray, byte> Face { get; private set; }

    public double DetectValue { get; private set; }

    public FaceDetectStatusEnum FaceDetectStatus { get; private set; }

    public FaceEntity(string name, Image face, double detectValue = default)
    {
        if (face is null)
            throw new ArgumentNullException(nameof(face));

        Name = name;
        Face = new Image<Gray, byte>(new Bitmap(face));
        DetectValue = detectValue;
    }

    public void SetDetectValue(double value) => DetectValue = Math.Round(value, 1);

    public void SetStatus(FaceDetectStatusEnum status) => FaceDetectStatus = status;
}