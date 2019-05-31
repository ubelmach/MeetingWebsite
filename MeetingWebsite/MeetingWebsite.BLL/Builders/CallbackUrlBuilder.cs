using System.Collections.Generic;
using System.Text;

namespace MeetingWebsite.BLL.Builders
{
    public class CallbackUrlBuilder
    {
        private const string HttpsProtocol = "https://";
        private const string ParametersIndicator = "?";
        private const string ParametersDelimiter = "&";

        private readonly StringBuilder _callbackUrl;

        public CallbackUrlBuilder()
        {
            _callbackUrl = new StringBuilder();
        }

        private CallbackUrlBuilder Https()
        {
            _callbackUrl.Append(HttpsProtocol);
            return this;
        }

        private CallbackUrlBuilder SiteName(string siteName)
        {
            _callbackUrl.AppendFormat(siteName);
            return this;
        }

        private CallbackUrlBuilder Controller(string controllerUrl)
        {
            _callbackUrl.AppendFormat(controllerUrl);
            return this;
        }

        private CallbackUrlBuilder Params(Dictionary<string, string> paramsDictionary)
        {
            if (paramsDictionary.Count != 0)
            {
                _callbackUrl.AppendFormat(ParametersIndicator);
                foreach (var parameter in paramsDictionary)
                {
                    _callbackUrl.AppendFormat($"{parameter.Key}={parameter.Value}");
                    _callbackUrl.AppendFormat(ParametersDelimiter);
                }

                _callbackUrl.Remove(_callbackUrl.Length - 1, 1);
            }
            return this;
        }

        public StringBuilder Build(string siteName, string controllerUrl, Dictionary<string, string> parameters)
        {
            Https().SiteName(siteName).Controller(controllerUrl).Params(parameters);
            return _callbackUrl;
        }
    }
}