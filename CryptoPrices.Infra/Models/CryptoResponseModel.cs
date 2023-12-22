using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPrices.Infra.Models
{
    public class CryptoResponseModel
    {
        public string Code { get; set; }
        public string Value { get; set; }
        public string Error { get; set; }
    }
}
