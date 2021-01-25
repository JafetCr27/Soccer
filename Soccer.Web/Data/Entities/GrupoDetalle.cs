using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Soccer.Web.Data.Entities
{
    public class GrupoDetalle
    {
        public int Id { get; set; }

        [Display(Name = "Equipo")]
        public Team Team { get; set; }

        [Display(Name = "Partidos jugados")]
        public int MatchesPlayed { get; set; }

        [Display(Name = "Partidos ganados")]
        public int MatchesWon { get; set; }

        [Display(Name = "Partidos empatados")]
        public int MatchesTied { get; set; }

        [Display(Name = "Partidos perdidos")]
        public int MatchesLost { get; set; }

        public int Points => MatchesWon * 3 + MatchesTied;

        [Display(Name = "Goals For")]
        public int GoalsFor { get; set; }

        [Display(Name = "Goals Against")]
        public int GoalsAgainst { get; set; }

        [Display(Name = "Gol diferencia")]
        public int GoalDifference => GoalsFor - GoalsAgainst;

        public Grupo Group { get; set; }
    }
}
