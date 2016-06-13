using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace PartyStarter.Models {
    public class GuidIdentityUserClaim : IdentityUserClaim<Guid> {
    }
}