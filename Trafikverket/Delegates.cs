using Trafikverket.EventArgs;

namespace Trafikverket
{
	public delegate void FailureEventHandler(object sender, FailureEventArgs e);

	public delegate void ResponseEventHandler(object sender, SuccessEventArgs e);
}