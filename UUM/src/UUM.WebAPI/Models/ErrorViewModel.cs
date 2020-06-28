namespace UUM.WebAPI.Models
{
    /// <summary>
    /// Error View model
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Id properties
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Validate Request Id
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
