using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalAssetManagementSep28
{
    public class AppUser : System.Web.Security.MembershipUser, IComparable<AppUser>
    {
        public int appuserid { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string userLogin { get; set; }
        public string userPassword { get; set; }
        public bool isAdmin { get; set; }
        public bool isActive { get; set; }
        public List<Category> categories { get; set; }

        public AppUser()
        {

        }

        public AppUser(String name)
            : base(
                providerName: "AccountMembershipProvider",
                name: name,
                providerUserKey: null,
                email: "",
                passwordQuestion: "",
                comment: "",
                isApproved: true,
                isLockedOut: false,
                creationDate: DateTime.UtcNow,
                lastLoginDate: DateTime.UtcNow,
                lastActivityDate: DateTime.UtcNow,
                lastPasswordChangedDate: DateTime.UtcNow,
                lastLockoutDate: DateTime.UtcNow)
        {
            userLogin = name;
        }

        #region IComparable<AppUser> Members

        public int CompareTo(AppUser other)
        {
            return String.Compare(this.lastName, other.lastName);

        }

        #endregion


    }
}