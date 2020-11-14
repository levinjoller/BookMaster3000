namespace BookMaster3000.Models
{
    public static class DB
    {
        private static ictskills2017Entities Context;
        public static User ApplicationUser;

        public static ictskills2017Entities GetCtx()
        {
            return Context ?? (Context = new ictskills2017Entities());
        }
    }
}
