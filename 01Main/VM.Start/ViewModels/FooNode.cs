namespace VM.Start.ViewModels
{
    public class FooNode
    {
        public FooEnum FooType { get; set; }

        public string Name
        {
            get { return this.FooType.ToString(); }
        }
    }
}
