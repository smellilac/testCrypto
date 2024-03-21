using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testingCrypto;

public interface IExchange
{
    Task<string> GetBtcUsdtPair();
}
