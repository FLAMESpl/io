namespace PhotoMark.Annotations
{
    public abstract class Annotation
    {
        public string Label { get; set; }
        public long StartFrame { get; set; }
        public long StopFrame { get; set; }
    }
}
