using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soccer.Web.Data.Entities;
using Soccer.Web.Models;

namespace Soccer.Web.Helpers
{
    public interface IConverterHelper
    {
        Team ToTeam(TeamViewModel model, string path,bool isNew);
        TeamViewModel ToTeamViewModel(Team team);
    }
}
