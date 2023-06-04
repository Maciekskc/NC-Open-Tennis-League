public static class ApiRoutes
{
    public const string Base = "api";

    public static class Games
    {
        public const string Base = "games";
        public const string Create = Base;
        public const string Finalize = Base + "/finalize";
        public const string GetById = Base + "/{id}";
        public const string GetViewModelById = Base + "/viewmodel/{id}";
        public const string GetAllPlayerGames = Base + "/player/{playerId}";
        public const string GetAll = Base;
        public const string Update = Base + "/{id}";
        public const string Delete = Base + "/{id}";
    }

    public static class Messages
    {
        public const string Base = "messages";
        public const string GetMessages = Base;
    }

    public static class TennisPlayers
    {
        public const string Base = "tennisplayers";
        public const string Create = Base;
        public const string GetById = Base + "/{id}";
        public const string GetAll = Base;
        public const string Update = Base + "/{id}";
        public const string Delete = Base + "/{id}";
        public const string GetRanking = Base + "/ranking";
    }
}
