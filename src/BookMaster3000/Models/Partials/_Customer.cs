using System;
using System.Linq;

namespace BookMaster3000.Models
{
    public partial class Customer
    {
        public string GenerateId()
        {
            var maxId = DB.GetCtx().Customer.Select(x => x.ID).Max();

            if (maxId == null || maxId == "")
            {
                return "C1000";
            }
            maxId = maxId.Substring(1, maxId.Length - 1);

            var IdNumeric = Convert.ToInt32(maxId);

            return ("C" + (IdNumeric + 1)).ToString();
        }
    }
}
