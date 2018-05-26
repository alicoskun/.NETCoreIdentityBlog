namespace CoreIdentity.Extensions
{
    public static class Utility
    {
        public static class Identity
        {
            public enum SignInStatus
            {
                Success,
                LockedOut,
                RequiresTwoFactorAuthentication,
                Failure
            }
        }
    }
}
