// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace UTStoreDemo.UI
{
    [Register ("CountryNavigationCell")]
    partial class CountryNavigationCell
    {
        [Outlet]
        UIKit.UILabel CountryDescription { get; set; }


        [Outlet]
        UIKit.UIImageView CountryImage { get; set; }


        [Outlet]
        UIKit.UILabel CountryName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CountryDescription != null) {
                CountryDescription.Dispose ();
                CountryDescription = null;
            }

            if (CountryImage != null) {
                CountryImage.Dispose ();
                CountryImage = null;
            }

            if (CountryName != null) {
                CountryName.Dispose ();
                CountryName = null;
            }
        }
    }
}