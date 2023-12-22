using CryptoPrices.Infra.Models;
using CryptoPrices.Infra.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPrices.Infra.Services
{
    public class CryptoService : ICryptoService
    {
        WebClient wb = new();
        CryptoResponseModel response = new();
        public string GetData(string coin)
        {
            string url = $"https://api.binance.com/api/v1/depth?symbol={coin}USDT&limit=20";
            string data = wb.DownloadString(url);
            string coinPrice = data.Substring(35, 8);
            char[] MyChar = { '"', '[' };
            string lastPrice = coinPrice.TrimStart(MyChar);
            string value = lastPrice + " " + "USDT";
            return value;
        }
        public CryptoResponseModel SearchCoin(CryptoRequestModel request)
        {
            try
            {
                string data = GetData(request.Code);
                response.Code = request.Code.ToUpper();
                response.Value = data;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = "Can't find this coin. Please check your coin code!";
                return response;
            }
        }
        public CryptoResponseModel GetCoinByCode(string request)
        {
            try
            {
                if (string.IsNullOrEmpty(request))
                    return response;
                string data = GetData(request.ToUpper());
                response.Code = request.ToString().ToUpper();
                response.Value = data;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = "Can't find this coin. Please check your coin code!";
                return response;
            }
        }
    }
}
