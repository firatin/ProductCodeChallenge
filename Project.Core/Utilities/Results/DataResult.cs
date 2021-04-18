namespace Project.Core.Utilities.Results {
    public class DataResult<T> : Result, IDataResult<T> {
        public DataResult(T data, bool status, string message) : base(status, message) {
            Data = data;
        }
        public DataResult(bool status, string message) : base(status, message) {

        }
        public T Data { get; }
    }

}
