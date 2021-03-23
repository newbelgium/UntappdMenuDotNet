using Newtonsoft.Json;
using System;

namespace UntappdMenuDotNet
{
    public class UntappdException : Exception
    {
        public UntappdException()
        {
        }

        public UntappdException(string message) : base(message)
        {
        }

        public UntappdException(string message, UntappdError untappdError) : base(message)
        {
            UntappdError = untappdError;
        }

        public UntappdException(string message, Exception inner) : base(message, inner)
        {
        }

        public UntappdException(string message, Exception inner, UntappdError untappdError) : base(message, inner)
        {
            UntappdError = untappdError;
        }

        public UntappdError UntappdError { get; private set; }
    }

    public class UntappdError
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
