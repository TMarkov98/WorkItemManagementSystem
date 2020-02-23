using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Core
{
    public static class DatabaseControls
    {
        public static List<IMember> LoadMembers(this IEngine e)
        {
            string membersJson = File.ReadAllText(@"..\..\..\Database\Members.json");
            return new List<IMember>(JsonConvert.DeserializeObject<List<Member>>(membersJson));
        }
        public static void SaveMembers(this IEngine e)
        {
            var newMembers = JsonConvert.SerializeObject(e.Members);
            File.WriteAllText(@"..\..\..\Database\Members.json", newMembers);
        }
        public static List<ITeam> LoadTeams(this IEngine e)
        {
            string teamsJson = File.ReadAllText(@"..\..\..\Database\Teams.json");
            return new List<ITeam>(JsonConvert.DeserializeObject<List<Team>>(teamsJson));
        }
        public static void SaveTeams(this IEngine e)
        {
            var newTeams = JsonConvert.SerializeObject(e.Teams);
            File.WriteAllText(@"..\..\..\Database\Teams.json", newTeams);
        }
    }
}
