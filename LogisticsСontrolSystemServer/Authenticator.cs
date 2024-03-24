using LogisticsСontrolSystemServer.DataAccessLayer.Repositories;
using LogisticsСontrolSystemServer.Models;
using System.Timers;

namespace LogisticsСontrolSystemServer
{
    public class Authenticator
    {
        private readonly ILogger<Authenticator> _logger;

        private List<Token> tokens = new List<Token>();
        private UserRepository userRepository = new UserRepository();
        private DateTime countdown = new DateTime(1, 1, 1, 0, 10, 0);

        public Authenticator(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory?.CreateLogger<Authenticator>() ??
                throw new ArgumentNullException(nameof(loggerFactory));

            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
        }

        public bool IsAuthenticated(Guid tokenId)
        {
            var token = tokens.FirstOrDefault(x => x.TokenId == tokenId);

            if (token != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Guid? Authentication(string username, string password)
        {
            var user = userRepository.Get(username, password);

            if (user != null )
            {
                var tokenUser = tokens.FirstOrDefault(x => x.User.UserId == user.UserId);

                if (tokenUser == null)
                {
                    Token token = new Token()
                    {
                        TokenId = Guid.NewGuid(),
                        LifeTime = countdown,
                        User = user
                    };
                    tokens.Add(token);
                    _logger.LogInformation($"Created token: {token.TokenId}, life time: {token.LifeTime.ToString("HH:mm:ss")}, user: {user.UserName}");
                    return token.TokenId;
                }
                else
                {
                    return tokenUser.TokenId;
                }
            }
            else
            {
                return null;
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            List<Token> removeTokens = new List<Token>();

            foreach (var token in tokens)
            {
                token.LifeTime = token.LifeTime.AddSeconds(-1);

                if (token.LifeTime.TimeOfDay.TotalSeconds == 0)
                {
                    _logger.LogInformation($"Deleted token: {token.TokenId}, life time: {token.LifeTime.ToString("HH:mm:ss")}");
                    removeTokens.Add(token);
                }
            }

            foreach (var token in removeTokens)
            {
                tokens.Remove(token);
            }
            removeTokens.Clear();
        }
    }
}
