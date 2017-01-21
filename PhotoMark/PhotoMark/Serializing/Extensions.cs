using PhotoMark.Files;
using System.Xml.Linq;
using System;
using PhotoMark.Annotations;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace PhotoMark.Serializing
{
    public static class Extensions
    {

        public static File LoadAnnotations(this File file)
        {
            try
            {
                var annotationsList = new List<Annotation>();
                var document = XDocument.Load(file.GetAnnotationFileName());
                var annotations = document.Element("root").Elements("annotation");
                foreach (var annotation in annotations)
                {
                    var position = annotation.Element("position");
                    var marker = new Marker();
                    marker.Position = new Point
                    {
                        X = Int32.Parse(position.Element("x").Value),
                        Y = Int32.Parse(position.Element("y").Value)
                    };

                    annotationsList.Add(marker);
                }
                file.Annotations = annotationsList;
            }
            catch(Exception)
            {
            }
            return file;
        }

        public static File SaveAnnotations(this File file)
        {
            try
            {
                var document = new XDocument(
                    new XElement("root",
                        file.Annotations.Cast<Marker>().Select(a => new XElement("annotation",
                            new XElement("type").Value("marker"),
                            new XElement("position",
                                new XElement("x").Value(a.Position.X.ToString()),
                                new XElement("y").Value(a.Position.Y.ToString()))))));
                document.Save(file.GetAnnotationFileName());
            }
            catch(Exception)
            {
            }
            return file;
        }

        private static XElement Value(this XElement element, string value)
        {
            element.Value = value;
            return element;
        }

        private static string GetAnnotationFileName(this File file)
        {
            var nameTokens = file.Name.Split('.');
            nameTokens[nameTokens.Length - 1] = ".xml";
            return String.Join(null, nameTokens);
        }
    }
}
