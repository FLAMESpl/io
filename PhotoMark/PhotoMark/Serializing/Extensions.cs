using IO = System.IO;
using PhotoMark.Files;
using System.Xml.Linq;
using System;
using PhotoMark.Annotations;
using System.Drawing;
using System.Collections.Generic;

namespace PhotoMark.Serializing
{
    public static class Extensions
    {
        public static File LoadAnnotations(this File file)
        {
            var nameTokens = file.Name.Split('.');
            nameTokens[nameTokens.Length - 1] = ".xml";
            var annotationsFileName = String.Join(null, nameTokens);
            try
            {
                var annotationsList = new List<Annotation>();
                var document = XDocument.Load(annotationsFileName);
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
    }
}
