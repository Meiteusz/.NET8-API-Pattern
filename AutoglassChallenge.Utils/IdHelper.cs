namespace AutoglassChallenge.Utils
{
    public static class IdHelper
    {
        public const long INVALID_ID = -1;

        public static bool IsIdInvalid(this long id)
            => id < 1;
    }
}
