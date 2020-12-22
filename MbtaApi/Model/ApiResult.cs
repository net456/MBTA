namespace MbtaApi.Model
{
    /// <summary>
    /// Generic class containing:
    /// 1. a model representing API response, for example routes API response.
    /// 2. Success failure indicator.
    /// 3. Generic message with any failure or success information
    ///
    /// This class can be easily extended to contain more result information, exception details, etc.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        
        public T Result { get; set; }
        
        public string Message { get; set; }
    }
}
