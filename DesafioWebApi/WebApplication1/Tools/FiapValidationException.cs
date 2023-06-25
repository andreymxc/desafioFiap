namespace DWFIAP.WebApp.Tools
{
    public class FiapValidationException : Exception
    {
        public FiapValidationException(string error) : base(error) { }
    }
}
