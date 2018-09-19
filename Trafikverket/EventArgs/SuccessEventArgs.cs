using Trafikverket.Transfer;

namespace Trafikverket.EventArgs
{
	public class SuccessEventArgs : System.EventArgs
	{
		public Response Response { get; set; }
		public Request Request { get; internal set; }

		public SuccessEventArgs(Response response, Request request)
		{
			Response = response;
			Request = request;
		}
	}
}