using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SaveHalbe.Utility;
using SaveHalbe.Core.Model;

namespace SaveHalbe
{
    [Activity(Label = "AnalyzedPictureActivity")]
    public class AnalyzedPictureActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AnalyzedPicture);

            string id = Intent.GetStringExtra("faceId");
            string key = Intent.GetStringExtra("faceKey");

            var byteImage = ImageHelper.GetBytePicture(id, key);
            var data = FaceDetectHelper.MakeRequest(byteImage);

            FindViews(data);
        }

        private void FindViews(DetectedFace data)
        {
            //Initializing button from layout
            FindViewById<TextView>(Resource.Id.age).Text = "Age: " + data.faceAttributes.age.ToString();
            FindViewById<TextView>(Resource.Id.gender).Text = "Gender: " + data.faceAttributes.gender.ToString();
            FindViewById<TextView>(Resource.Id.smile).Text = "Smile: " + data.faceAttributes.smile.ToString();
        }
    }
}