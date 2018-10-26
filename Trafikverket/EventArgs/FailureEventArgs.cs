using Apparent.Trafikverket.Transfer;

namespace Apparent.Trafikverket.EventArgs
{
	public class FailureEventArgs : System.EventArgs
	{
		public Response Response { get; internal set; }
		public Request Request { get; internal set; }
		public System.Exception Exception { get; internal set; }

		public FailureEventArgs(Response response, Request request, System.Exception exception)
		{
			Response = response;
			Request = request;
			Exception = exception;
		}
	}
}