namespace DeskFlowApi.Exceptions
{
    public class IDNaoExistenteOuInvalidoException : Exception
    {
        public IDNaoExistenteOuInvalidoException(string message) : base(message) { }
    }
}