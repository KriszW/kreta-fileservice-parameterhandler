namespace Kreta.FileService.ParameterHandler.Library.Abstractions
{
    public interface IParameterHandlerCommandBase : IParameterHandlerBase
    {
        /// <summary>
        /// Az URL query paraméter értéke pl: ?type=Normal -> normal
        /// </summary>
        public string QueryParameterValue { get; }
    }
}
