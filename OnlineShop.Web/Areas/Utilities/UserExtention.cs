using System.Security.Claims;

namespace OnlineShop.Web
{
    public static class UserExtension
    {
        public static long GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim != null)
            {
                var userId = Convert.ToInt32(userIdClaim.Value);

                return userId;
            }

            return 0;
        }

        public static string GetFullName(this ClaimsPrincipal user)
        {
            var userFullNameClaim = user.Claims.FirstOrDefault(c => c.Type == "FullName");

            if (userFullNameClaim != null)
            {
                return userFullNameClaim.Value;
            }

            return "";
        }

        public static int PlusOne(this int x)
        {
            return (x + 1);
        }
    }
}
