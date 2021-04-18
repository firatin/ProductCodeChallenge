namespace Project.Core.Utilities.Results {
    public class Result : IResult {
        public Result(bool status, string message) {
            Message = message;
            Status = status;
        }
        public string Message { get; }

        public bool Status { get; }
    }

}
