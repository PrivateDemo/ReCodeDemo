using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Utility
{
    public static class IdentityUtility
    {
        public static string NewClientIdentity()
        {
            string id = Guid.NewGuid().ToString();
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long stamp = Convert.ToInt64(ts.TotalMilliseconds);

            string iden = string.Format("{0}-{1}", id.Replace("-", ""), stamp);
            return iden;
        }
    }
}
