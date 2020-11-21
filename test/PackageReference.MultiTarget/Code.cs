namespace Code
{
    public record RecordClass(string CtorProp)
    {
        public string NormalProp { get; init; }
    }

    public class NormalClass
    {
        public string NormalProp { get; init; }
    }

    public static class User
    {
        public static void UseExternalInit()
        {
            _ = typeof(System.Runtime.CompilerServices.IsExternalInit);
        }

        public static void UseRecordClass()
        {
            var instance = new RecordClass("CtorProp") { NormalProp = "NormalProp" };
            //instance.CtorProp = "Should be an error.";
            //instance.NormalProp = "Should be an error.";
        }

        public static void UseNormalClass()
        {
            var instance = new NormalClass() { NormalProp = "NormalProp" };
            //instance.NormalProp = "Should be an error.";
        }
    }
}
