using System;
using System.Collections.Generic;
using System.Text;

namespace DutchPurpleFiat.Data.DataStores
{
    public static class DataHelper
    {
        public static string GenerateUniqueId()
        {
            return Guid.NewGuid().ToString();
        }

    }
}
