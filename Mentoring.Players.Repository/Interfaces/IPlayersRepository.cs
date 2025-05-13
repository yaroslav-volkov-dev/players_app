using Mentoring.Players.Repository.Models;

namespace Mentoring.Players.Repository.Interfaces;

public interface IPlayersRepository
{
    void AddPlayer(string name, int level);
    void RemovePlayer(Guid id);
    void BanPlayerById(Guid id);
    void UnbanPlayerById(Guid id);
    Player[] GetAllPlayers();
    Player GetPlayerById(Guid id);
}