using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Trafikverket.EventArgs;
using Trafikverket.Transfer;
using Trafikverket.Util;

namespace Trafikverket
{
	public class Trafikinfo
	{
		private static readonly Uri _address = new Uri("http://api.trafikinfo.trafikverket.se/v1.3/data.json");
		private Configuration _configuration { get; set; }

		public event FailureEventHandler FailureHandler;

		public event ResponseEventHandler ResponseHandler;

		protected void OnFailureEvent(FailureEventArgs e)
		{
			FailureHandler?.Invoke(this, e);
		}

		protected void OnResponseEvent(SuccessEventArgs e)
		{
			ResponseHandler?.Invoke(this, e);
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

		public Trafikinfo(Configuration config)
		{
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

		private void SetLogin(ref Request request)
		{
			if (request.Login == null)
			{
				request.Login = new Login(_configuration.Key);
			}
		}

		public async Task<bool> SendRequestAsync(Request request)
		{
			SetLogin(ref request);

			try
			{
				using (var webclient = GetWebClient(_configuration.Referer))
				{
					var response = await webclient.UploadStringTaskAsync(_address, "POST", request.Build());
					var data = JsonConvert.DeserializeObject<QueryResponse>(response);

					Success(data.Response, request);

					return true;
				}
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

		public bool SendRequest(Request request)
		{
			SetLogin(ref request);

			try
			{
				using (var webclient = GetWebClient(_configuration.Referer))
				{
					var response = webclient.UploadString(_address, "POST", request.Build());
					var data = JsonConvert.DeserializeObject<QueryResponse>(response);

					Success(data.Response, request);

					return true;
				}
			}
			catch(WebException e)
			{
				Failure(Utils.GetErrorResponse(e), request, e);
			}
			catch (Exception e)
			{
				Failure(null, request, e);
			}

			return false;
		}

		public Response MakeRequest(Request request)
		{
			SetLogin(ref request);

			try
			{
				using (var webclient = GetWebClient(_configuration.Referer))
				{
					var response = webclient.UploadString(_address, "POST", request.Build());
					var data = JsonConvert.DeserializeObject<QueryResponse>(response);

					return data.Response;
				}
			}
			catch (WebException e)
			{
				Failure(Utils.GetErrorResponse(e), request, e);
			}
			catch (Exception e)
			{
				Failure(null, request, e);
			}

			return null;
		}

		public static WebClient GetWebClient(string referer)
		{
			var webclient = new WebClient
			{
				Encoding = Encoding.UTF8
			};

			webclient.Headers.Add("Referer", referer);
			webclient.Headers["Content-Type"] = "text/xml";

			return webclient;
		}
	}
}