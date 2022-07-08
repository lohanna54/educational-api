using System.Net;

namespace Educational_Api.Models.Response
{
	public class ApiResponse<T>
	{
		public bool IsSuccessful { get; set; }

		public HttpStatusCode StatusCode { get; set; }

		public T Response { get; set; }

		public ApiResponse() { }

		public ApiResponse(bool isSuccessful) => IsSuccessful = isSuccessful;
	}
}
