using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.UserAudit.Infra.Data
{
    public class UserAuditDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string UserAuditCollectionName { get; set; }
    }
}
