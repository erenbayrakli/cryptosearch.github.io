using CryptoPrices.Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPrices.Infra.Services.Abstract
{
    public interface ICryptoService
    {
        string GetData(string coin);
        CryptoResponseModel SearchCoin(CryptoRequestModel request);
        CryptoResponseModel GetCoinByCode(string request);
    }
}
