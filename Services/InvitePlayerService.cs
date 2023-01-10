using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RPGApp.Data;
using RPGApp.Data.Migrations;
using RPGApp.Interfaces;
using RPGApp.Models;
using System.Linq;
using System.Security.Claims;

namespace RPGApp.Services
{
    public class InvitePlayerService : IPlayer
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string UserId;


        public InvitePlayerService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        [HttpGet]
        public List<PlayerModel> GetPlayers()
        {
            List<PlayerModel> result = new List<PlayerModel>();
            var currentSessionId = _context.Users.First(x => x.Id == UserId).CurrentSessionId;
            var sessionToGet = _context.Sessions.First(x => x.Id == currentSessionId);
            var GameMasterRoleId = _context.Roles
                .First(x => x.Name == "GameMaster").Id;

            if (_context.UserSessions.Where(x => x.SessionIdsFK == currentSessionId).Count() > 1)
            {
                List<User>? Players = _context.UserSessions.Where(x => x.SessionIdsFK == currentSessionId).Select(x => x.User).ToList();
                //.Intersect(sessionToGet.Users.Select(x => x.UserIdsFK))
                foreach (var item in Players)
                {
                    result.Add(new PlayerModel()
                    {
                        PlayerId = item.Id,
                        PlayerName = item.UserName
                    });
                }
            }
            return result;
        }
        [HttpGet]
        public PlayerViewModel GetPlayersEligibleToJoin()
        {
            PlayerViewModel result = new PlayerViewModel();
            var currentSessionId = _context.Users.First(x => x.Id == UserId).CurrentSessionId;
            var sessionToGet = _context.Sessions.First(x => x.Id == currentSessionId);
            var GameMasterRoleId = _context.Roles
                .First(x => x.Name == "GameMaster").Id;

            //if (_context.UserSessions.Where(x => x.SessionIdsFK == currentSessionId).Count() > 1)
            //{
            List<User>? Players = new List<User>();
            Players = _context.Users.Except(_context.UserSessions.Where(x => x.SessionIdsFK == currentSessionId).Select(x => x.User)).ToList();

            foreach (var item in Players)
            {
                result.PlayerNameList.Add(new PlayerModel()
                {
                    PlayerId = item.Id,
                    PlayerName = item.UserName
                });
            }
            return result;
        }

        [HttpPost]
        public void AddPlayer(string playeId)
        {
            UserSession player = new UserSession();
            player.SessionIdsFK = _context.Users.First(x => x.Id == UserId).CurrentSessionId;
            player.UserIdsFK = playeId;
            _context.UserSessions.Add(player);
            _context.SaveChanges();
        }

    }
}
