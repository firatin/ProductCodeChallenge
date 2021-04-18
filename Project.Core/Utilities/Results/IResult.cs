namespace Project.Core.Utilities.Results {
    public interface IResult {
        string Message { get; }
        bool Status { get; }
    }
}
