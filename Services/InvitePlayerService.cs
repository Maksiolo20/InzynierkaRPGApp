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
                List<string>? Players = _context.UserRoles.Where(x => x.RoleId != GameMasterRoleId).Select(x => x.UserId).Intersect(sessionToGet.Users.Select(x => x.UserIdsFK)).ToList();
                foreach (var item in Players)
                {
                    result.Add(new PlayerModel()
                    {
                        PlayerId = item,
                        PlayerName = _context.Users.First(x => x.Id == item).UserName
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
            bool flag = false;
            List<string>? Players = new List<string>();
            if (_context.UserSessions.Where(x => x.SessionIdsFK == currentSessionId).Count() > 1)
                flag = true;
            if (flag)
            {
                Players = _context.UserRoles.Where(x => x.RoleId != GameMasterRoleId).Select(x => x.UserId).Except(sessionToGet.Users.Select(x => x.UserIdsFK)).ToList();
            }
            else
            {
                Players = _context.UserRoles.Where(x => x.RoleId != GameMasterRoleId).Select(x => x.UserId).ToList();
            }
            foreach (var item in Players)
            {
                result.PlayerNameList.Add(new PlayerModel()
                {
                    PlayerId = item,
                    PlayerName = _context.Users.First(x => x.Id == item).UserName
                });
            }
            return result;
        }

        [HttpPost]
        public void AddPlayer(PlayerViewModel Player)
        {
            UserSession player = new UserSession();
            player.SessionIdsFK = _context.Users.First(x => x.Id == UserId).CurrentSessionId;
            player.UserIdsFK = Player.Player.Id;
            _context.UserSessions.Add(player);
            _context.SaveChanges();
        }

    }
}
