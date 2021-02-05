using FinalProject.Dto;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repository
{
    public interface ITeamLeaderRep
    {
        public List<TeamLeader> GetTeamLeaders();
        public Task InsertTeamLeader(UserDto TeamLeaderDto);
        public TeamLeader GetTeamLeader(String TeamLeaderID);
        public Task UpdateTeamLeader(UserDto TeamLeaderDto);
        public Task DeletTeamLeader(String TeamLeaderID);
        public List<TeamLeader> GetAnotherTeamLeaders(String TeamLeaderId);
        public TeamLeader GetTeamLeaderFroSprintId(int SprintId);
        

    }
}
