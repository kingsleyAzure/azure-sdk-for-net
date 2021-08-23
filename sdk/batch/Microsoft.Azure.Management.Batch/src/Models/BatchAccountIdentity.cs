using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Batch.Models
{
    public partial class BatchAccountIdentity
    {
        public BatchAccountIdentity(ResourceIdentityType type, string principalId, string tenantId, IDictionary<string, BatchAccountIdentityUserAssignedIdentitiesValue> userAssignedIdentities)
        : this(type, principalId, tenantId, userAssignedIdentities as IDictionary<string, UserAssignedIdentities>)
        {
        }
    }
}
