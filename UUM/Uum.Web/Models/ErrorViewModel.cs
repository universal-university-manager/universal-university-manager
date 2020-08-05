namespace Uum.Web.Models
{
    public class ErrorViewModel
    {
        /// <summary>
        /// Request Id properties
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
