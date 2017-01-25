using System;
using System.Drawing;

namespace PhotoMark
{
    public static class Extensions
    {
        public static Point MapToImage(this Point mousePosition, Size componentSize, Size imageSize)
        {
            var scaleWidth = imageSize.Width / (double)componentSize.Width;
            var scaleHeight = imageSize.Height / (double)componentSize.Height;
            var scale = scaleWidth < scaleHeight ? scaleHeight : scaleWidth;
            var scaledImageSize = imageSize.GetScaled(1 / scale);
            var inBoxImagePosition = new Point(
                (componentSize.Width - scaledImageSize.Width) / 2,
                (componentSize.Height - scaledImageSize.Height) / 2);
            var relativeMousePosition = new Point(
                mousePosition.X - inBoxImagePosition.X,
                mousePosition.Y - inBoxImagePosition.Y);
            return relativeMousePosition.GetScaled(scale);
        }

        private static Size GetScaled(this Size size, double scaleFactor) 
            => new Size((int)(size.Width * scaleFactor), (int)(size.Height * scaleFactor));

        private static Point GetScaled(this Point point, double scaleFactor)
            => new Point((int)(point.X * scaleFactor), (int)(point.Y * scaleFactor));
    }
}
