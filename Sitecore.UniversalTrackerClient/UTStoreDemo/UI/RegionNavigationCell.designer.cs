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
    [Register ("RegionNavigationCell")]
    partial class RegionNavigationCell
    {
        [Outlet]
        UIKit.UIImageView RegionIcon { get; set; }


        [Outlet]
        UIKit.UILabel RegionName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (RegionIcon != null) {
                RegionIcon.Dispose ();
                RegionIcon = null;
            }

            if (RegionName != null) {
                RegionName.Dispose ();
                RegionName = null;
            }
        }
    }
}