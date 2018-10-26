using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Apparent.Trafikverket.EventArgs;
using Apparent.Trafikverket.Transfer;
using Apparent.Trafikverket.Util;

namespace Apparent.Trafikverket
{
	/// <summary>
	/// The Trafikinfo class handles the communication with Trafikverkets Trafikinfo API.
	/// </summary>
	/// <example>
	/// using(var api = new Trafikinfo(new Configuration { Key = "yoursecretkey", Referer = "https://www.yourdomain.com" }))
	/// {
	/// 	var request = new Request();
	/// 	request.AddQuery(new Query(ObjectType.TrainStation));
	/// 	request.Queries[0].Filter.AddOperator(new FilterOperator(OperatorType.Equals, "LocationSignature", "cst"));
	///
	/// 	var response = api.Request(request);
	/// }
	/// </example>
	public class Trafikinfo : IDisposable
	{
		private static readonly Uri _address = new Uri("http://api.trafikinfo.trafikverket.se/v1.3/data.json");
		private readonly Configuration _configuration;
		private readonly WebClient _webClient;
		private bool _disposedValue;

		public event FailureEventHandler FailureHandler;

		public event ResponseEventHandler ResponseHandler;

		/// <summary>
		/// Called when an error occur.
		/// </summary>
		/// <param name="e"></param>
		protected void OnFailureEvent(FailureEventArgs e)
		{
			FailureHandler?.Invoke(this, e);
		}

		/// <summary>
		/// Called when an async result is returned.
		/// </summary>
		/// <param name="e"></param>
		protected void OnResponseEvent(SuccessEventArgs e)
		{
			ResponseHandler?.Invoke(this, e);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Trafikinfo`1"/> class.
		/// </summary>
		/// <param name="config"></param>
		public Trafikinfo(Configuration config)
		{
			_configuration = config;
			_webClient = GetWebClient(_configuration.Referer);

			if (config == null)
			{
				throw new Exception("Configuration must be provided");
			}

			if (string.IsNullOrWhiteSpace(config?.Key) || string.IsNullOrWhiteSpace(config?.Referer))
			{
				throw new Exception("Key and Referer must be set in configuration");
			}

			_configuration = config;
		}

		/// <summary>
		/// Send a request asynchronously to Trafikverket API.
		/// A successful request will have the data delivered through the OnResponseEvent handler.
		/// Errors will be delivered through OnFailureEvent.
		/// </summary>
		/// <param name="request"></param>
		/// <returns>Task<bool></returns>
		public async Task<bool> RequestAsync(Request request)
		{
			SetLogin(ref request);

			try
			{
				var response = await _webClient.UploadStringTaskAsync(_address, "POST", request.Build());
				var data = JsonConvert.DeserializeObject<QueryResponse>(response);

				Success(data.Response, request);

				return true;
			}
			catch (WebException e)
			{
				Failure(Utils.GetErrorResponse(e), request, e);
			}
			catch (Exception e)
			{
				Failure(null, request, e);
			}

			return false;
		}

		/// <summary>
		/// Send a request to Trafikverket API.
		/// </summary>
		/// <param name="request"></param>
		/// <returns>Response</returns>
		public Response Request(Request request)
		{
			SetLogin(ref request);

			try
			{
				var response = _webClient.UploadString(_address, "POST", request.Build());
				var data = JsonConvert.DeserializeObject<QueryResponse>(response);

				return data.Response;
			}
			catch (WebException e)
			{
				return Utils.GetErrorResponse(e);
			}
			catch
			{
				throw;
			}
		}

		private void Failure(Response response, Request request, Exception exception)
		{
			var args = new FailureEventArgs(response, request, exception);
			OnFailureEvent(args);
		}

		private void Success(Response response, Request request)
		{
			var args = new SuccessEventArgs(response, request);
			OnResponseEvent(args);
		}

		private void SetLogin(ref Request request)
		{
			if (request.Login == null)
			{
				request.Login = new Login(_configuration.Key);
			}
		}

		private static WebClient GetWebClient(string referer)
		{
			var webclient = new WebClient
			{
				Encoding = Encoding.UTF8
			};

			webclient.Headers.Add("Referer", referer);
			webclient.Headers["Content-Type"] = "text/xml";

			return webclient;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposedValue)
			{
				if (disposing)
				{
					_webClient.Dispose();
				}

				_disposedValue = true;
			}
		}

		~Trafikinfo()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}