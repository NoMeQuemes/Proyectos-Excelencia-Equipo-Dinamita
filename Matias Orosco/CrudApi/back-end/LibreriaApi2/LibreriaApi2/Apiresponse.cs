using System.Net;

namespace LibreriaApi2
{
    public class Apiresponse
    {
        internal HttpStatusCode statusCode;

        public HttpStatusCode status {get; set;}
        public bool IsExitoso { get; set;}
        //public bool IsExitoso = true;
        public List<string> Errors { get; set;}
        public object Resultado { get; set;}    
    }
}
