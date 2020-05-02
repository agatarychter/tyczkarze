using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.BusinessLogic.Services.Interface;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;
using Tyczkarze.DataAccess.Repository;
using Tyczkarze.DataAccess.Repository.Interface;

namespace Tyczkarze.BusinessLogic.Services
{
    public class JumpService : IJumpService
    {
        private readonly ApplicationDbContext _context;
        private readonly IJumpRepository jumpRepository;
        private readonly IJumpTypeRepository jumpTypeRepository;
        private readonly IJumpStatusRepository jumpStatusRepository;

        public JumpService(ApplicationDbContext context)
        {
            _context = context;
            jumpRepository = new JumpRepository(context);
            jumpStatusRepository = new JumpStatusRepository(context);
            jumpTypeRepository = new JumpTypeRepository(context);
        }

        public Jump Add(Jump jump)
        {
            var obj = jump;
            obj.IdPole1 = jump.IdPole1 == 0 ? null : jump.IdPole1;
            obj.IdPole2 = jump.IdPole2 == 0 ? null : jump.IdPole2;
            obj.IdPole3 = jump.IdPole3 == 0 ? null : jump.IdPole3;
            obj.IdJumpStatus1 = jump.IdJumpStatus1 == 0 ? null : jump.IdJumpStatus1;
            obj.IdJumpStatus2 = jump.IdJumpStatus2 == 0 ? null : jump.IdJumpStatus2;
            obj.IdJumpStatus3 = jump.IdJumpStatus3 == 0 ? null : jump.IdJumpStatus3;
            obj.IdJumpType = jump.IdJumpType == 0 ? null : jump.IdJumpType;
            var result = jumpRepository.Add(jump);
            return result;
        }

        public void Delete(int Id)
        {
            jumpRepository.Delete(Id);
        }

        public Jump FindById(int Id)
        {
            return jumpRepository.FindById(Id);
        }

        public IEnumerable<Jump> GetAll()
        {
            return jumpRepository.GetAll();
        }

        public IEnumerable<JumpStatus> GetAllJumpStatuses()
        {
            return jumpStatusRepository.GetAll();
        }

        public IEnumerable<JumpType> GetAllJumpTypes()
        {
            return jumpTypeRepository.GetAll();
        }

        public IEnumerable<Jump> GetAllForContest(int idContest)
        {
            return jumpRepository.GetAllForContest(idContest).OrderBy(x => x.Height).ToList();
        }

        public IEnumerable<Jump> GetAllForElimination(int idElimination)
        {
            return jumpRepository.GetAllForElimination(idElimination).OrderBy(x => x.Height).ToList();
        }

        public Jump Update(Jump jump)
        {
            var obj = FindById(jump.IdJump);
            if (obj == null)
                return null;
            obj.Height = jump.Height;
            obj.IdContest = obj.IdContest;
            obj.IdElimination = obj.IdElimination;
            obj.IdJumpType = jump.IdJumpType;
            obj.Note = jump.Note;
            obj.StepsCount = jump.StepsCount;
            obj.IdJump = obj.IdJump;
            obj.IdPole1 = jump.IdPole1 == 0 ? null : jump.IdPole1;
            obj.IdPole2 = jump.IdPole2 == 0 ? null : jump.IdPole2;
            obj.IdPole3 = jump.IdPole3 == 0 ? null : jump.IdPole3;
            obj.IdJumpStatus1 = jump.IdJumpStatus1 == 0 ? null : jump.IdJumpStatus1;
            obj.IdJumpStatus2 = jump.IdJumpStatus2 == 0 ? null : jump.IdJumpStatus2;
            obj.IdJumpStatus3 = jump.IdJumpStatus3 == 0 ? null : jump.IdJumpStatus3;
            var result = jumpRepository.Update(obj);
            return result;
        }

        public JumpDTO GetBestResultForAthlete(int idAthlete)
        {
            ICompetitionRepository competitionRepository = new CompetitionRepository(context: _context);
            IEliminationRepository eliminationRepository = new EliminationRepository(_context);
            IContestRepository contestRepository = new ContestRepository(_context);

            JumpDTO jump = new JumpDTO();
            var jumps = GetAllForAthlete(idAthlete).OrderByDescending(x => x.Height);
            var onlyGoodJumps = jumps.Where(x => x.IdJumpStatus1 == 1 || x.IdJumpStatus2 == 1 || x.IdJumpStatus3 == 1).FirstOrDefault();

            if(onlyGoodJumps == null)
            {
                return null;
            }

            jump.Height = onlyGoodJumps.Height;
            if(onlyGoodJumps.IdContest != null)
            {
                jump.IsContest = true;
                jump.IsElimination = false;
                var contest = contestRepository.FindById(onlyGoodJumps.IdContest.Value);
                var competition = competitionRepository.GetAllForAthlete(idAthlete).Where(x => x.IdCompetition == contest.IdCompetition).FirstOrDefault();

                jump.DateOfRecord = contest.ContestDate;
                jump.CompetitionName = competition.Name;

            }
            else if (onlyGoodJumps.IdElimination != null)
            {
                jump.IsContest = false;
                jump.IsElimination = true;
                var elimination = eliminationRepository.FindById(onlyGoodJumps.IdElimination.Value);
                var competition = competitionRepository.GetAllForAthlete(idAthlete).Where(x => x.IdCompetition == elimination.IdCompetition).FirstOrDefault();

                jump.DateOfRecord = elimination.EliminationDate;
                jump.CompetitionName = competition.Name;

            }
            return jump;
        }

        public IEnumerable<Jump> GetAllForAthlete(int idAthlete)
        {
            ICompetitionRepository competitionRepository = new CompetitionRepository(context: _context);
            IEliminationRepository eliminationRepository = new EliminationRepository(_context);
            IContestRepository contestRepository = new ContestRepository(_context);

            var competitions = competitionRepository.GetAllForAthlete(idAthlete);
            List<Jump> result = new List<Jump>();

            foreach(var competition in competitions)
            {
                var elimination = eliminationRepository.GetEliminationByCompetitionID(competition.IdCompetition);
                var contest = contestRepository.GetContestByCompetitionID(competition.IdCompetition);

                if(elimination != null)
                {
                    var jumps = GetAllForElimination(elimination.IdElimination).ToList();
                    result = result.Concat(second: jumps).ToList();
                }
                if(contest != null)
                {
                    var jumps = GetAllForContest(contest.IdContest).ToList();
                    result = result.Concat(second: jumps).ToList();
                }

            }

            return result;
        }

        public IEnumerable<JumpChartDTO> GetJumpsForChartWinter(int id)
        {
            DateTime beginDate = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime endDate = new DateTime(DateTime.Now.Year, 3, 31);

            var result = GetJumpsForChart(beginDate, endDate, id);

            return result;
        }

        public IEnumerable<JumpChartDTO> GetJumpsforChartSummer(int idAthlete)
        {
            DateTime beginDate = new DateTime(DateTime.Now.Year, 4, 1);
            DateTime endDate = new DateTime(DateTime.Now.Year, 8, 31);

            var result = GetJumpsForChart(beginDate, endDate, id: idAthlete);

            return result;
        }

        public IEnumerable<JumpChartDTO> GetJumpsForChartAutumn(int idAthlete)
        {
            DateTime beginDate = new DateTime(DateTime.Now.Year, 9, 1);
            DateTime endDate = new DateTime(DateTime.Now.Year, 10, 31);

            var result = GetJumpsForChart(beginDate, endDate, idAthlete);

            return result;
        }

        private IEnumerable<JumpChartDTO> GetJumpsForChart(DateTime beginDate, DateTime endDate, int id)
        {
            ICompetitionRepository competitionRepository = new CompetitionRepository(context: _context);
            IEliminationRepository eliminationRepository = new EliminationRepository(_context);
            IContestRepository contestRepository = new ContestRepository(_context);

            List<JumpChartDTO> result = new List<JumpChartDTO>();

            var competitions = competitionRepository.GetAllForAthlete(id).Where(x => x.BeginDate >= beginDate && x.EndDate <= endDate).ToList();
            foreach (var competition in competitions)
            {
                var elimination = eliminationRepository.GetEliminationByCompetitionID(competition.IdCompetition);
                var contest = contestRepository.GetContestByCompetitionID(competition.IdCompetition);

                if (elimination != null)
                {
                    var jump = GetAllForElimination(elimination.IdElimination).Where(x => x.IdJumpStatus1 == 1 || x.IdJumpStatus2 == 1 || x.IdJumpStatus3 == 1).OrderByDescending(x => x.Height).FirstOrDefault();
                    if (jump != null)
                        result.Add(new JumpChartDTO() { DateOfCompetition = elimination.EliminationDate, MaxHeight = jump.Height });
                }
                if (contest != null)
                {

                    var jump = GetAllForContest(contest.IdContest).Where(x => x.IdJumpStatus1 == 1 || x.IdJumpStatus2 == 1 || x.IdJumpStatus3 == 1).OrderByDescending(x => x.Height).FirstOrDefault();
                    if (jump != null)
                        result.Add(new JumpChartDTO() { DateOfCompetition = contest.ContestDate, MaxHeight = jump.Height });
                }
            }
            return result;
        }

        public string VerifyJumps(IEnumerable<Jump> jumps)
        {
            string result = null;

            var jumpsFiltered = jumps.Where(x => x.IdJumpType == 3 && !(x.IdJumpStatus1 == 3 && x.IdJumpStatus2 == 3 && x.IdJumpStatus3 == 3)).OrderByDescending(x => x.Height).ToList();
            var length = jumpsFiltered.Count;
            if(length == 1)
            {
                return null;
            }
            else
            {
                var previous = jumpsFiltered.ElementAt(1);
                var current = jumpsFiltered.ElementAt(0);
                
                //poprzedni skok niezaliczony całkowicie
                if(previous.IdJumpStatus1 == 2 && previous.IdJumpStatus2 == 2 && previous.IdJumpStatus3 == 2)
                {
                    return "Nie można definiować nowych skoków. Poprzednia wysokość niezaliczona.";
                }
                //obecnie nie zdefiniowano żadnego statusu
                if (current.IdJumpStatus1 == 0 && current.IdJumpStatus2 == 0 && current.IdJumpStatus3 == 0)
                {
                    return "Zdefiniuj przynajmniej jeden status";
                }
                //poprzedni skok jest zaliczony
                if (previous.IdJumpStatus1 == 1 || previous.IdJumpStatus2 == 1 || previous.IdJumpStatus3 == 1)
                {
                    //sprawdzenie czy uzupełnił poprawnie obecny skok
                    if (current.IdJumpStatus1 == 0 && current.IdJumpStatus2 == 0 && current.IdJumpStatus3 == 0)
                    {
                        return "Nie zdefiniowano statusów skoku";
                    }
                    if (current.IdJumpStatus1 == 0 && (current.IdJumpStatus2 != 0 || current.IdJumpStatus3 != 0))
                    {
                        return "Nie zdefiniowano pierwszego statusu skoku";
                    }
                    else if (current.IdJumpStatus1 == 1 && (current.IdJumpStatus2 != 0 || current.IdJumpStatus3 != 0))
                    {
                        return "Skok zaliczony w pierwszej próbie. Nie definiuj pozostałych statusów";
                    }
                    else if (current.IdJumpStatus1 == 3 && current.IdJumpStatus2 == 3 && current.IdJumpStatus3 == 3)
                    {
                        return null;
                    }
                    else if (current.IdJumpStatus1 == 3 && current.IdJumpStatus2 == 0 && current.IdJumpStatus3 == 0)
                    {
                        return "OK23";
                    }
                    else if (current.IdJumpStatus1 == 3 && current.IdJumpStatus2 == 3 && current.IdJumpStatus3 == 0)
                    {
                        return "OK3";
                    }
                    else if (current.IdJumpStatus1 == 3 && (current.IdJumpStatus2 != 0 || current.IdJumpStatus3 != 0))
                    {
                        return "Skok przeniesiony w pierwszej próbie. Nie definiuj pozostałych statusów";
                    }
                    else if (current.IdJumpStatus1 == 2)
                    {
                        if (current.IdJumpStatus2 == 1 && current.IdJumpStatus3 != 0)
                        {
                            return "Skok zaliczony w drugiej próbie. Nie definiuj trzeciego statusu";
                        }
                        if (current.IdJumpStatus2 == 0 && current.IdJumpStatus3 == 0)
                        {
                            return "Zdefiniuj drugi i trzeci status";
                        }
                        if (current.IdJumpStatus2 == 2 && current.IdJumpStatus3 == 0)
                        {
                            return "Zdefiniuj trzeci status";
                        }
                        if (current.IdJumpStatus2 == 3 && current.IdJumpStatus3 == 0)
                        {
                            return "OK3";
                        }
                        if (current.IdJumpStatus2 == 3 && current.IdJumpStatus3 == 3)
                        {
                            return null;
                        }
                        if (current.IdJumpStatus2 == 3 && current.IdJumpStatus3 != 0)
                        {
                            return "Skok przeniesiony w drugiej próbie. Nie definiuj trzeciego statusu";
                        }
                        if (current.IdJumpStatus2 == 3 && current.IdJumpStatus3 == 0)
                        {
                            return "OK3";
                        }
                    }
                    return null;
                }
                //poprzedni skok x__
                if (previous.IdJumpStatus1 == 2 && previous.IdJumpStatus2 == 0 && previous.IdJumpStatus3 == 0)
                {
                    return "Poprzednia wysokość była ostanią";
                }
                //poprzedni skok xx_
                if (previous.IdJumpStatus1 == 2 && previous.IdJumpStatus2 == 2 && previous.IdJumpStatus3 == 0)
                {
                    return "Poprzednia wysokość była ostanią";
                }
                //poprzedni skok xx-
                if (previous.IdJumpStatus1==2 && previous.IdJumpStatus2 == 2)
                {
                
                    //jeżeli był poprzedni xx_ to znaczy że już koniec skakania
                    if(previous.IdJumpStatus3 == 0)
                    {
                        return "Poprzednia wysokość była ostatnią.";
                    }

                    //obecny nie ma nic zdefiniowanego
                    if(current.IdJumpStatus1 == 0 && current.IdJumpStatus2 == 0 && current.IdJumpStatus3 == 0)
                    {
                        return "Zdefiniuj pierwszy status. Poprzedni skok przeniesiony w drugiej próbie"; 
                    }
                    //obecny przenosi
                    else if (current.IdJumpStatus1 == 3 && current.IdJumpStatus2 == 0 && current.IdJumpStatus3 == 0)
                    {
                        return "OK23";
                    }
                    //obecny ma 2 i 3 zdefiniowany ale nie ma pierwszego
                    else if(current.IdJumpStatus1 == 0 && (current.IdJumpStatus2 != 0 || current.IdJumpStatus3 != 0))
                    {
                        return "Zdefiniuj tylko pierwszy status. Poprzedni skok przeniesiony w drugiej próbie";
                    }
                    //obecnt ma pierwszy i któryś z pozostałych zdefiniowanych
                    else if (current.IdJumpStatus1 != 0 && (current.IdJumpStatus2 != 0 || current.IdJumpStatus3 != 0))
                    {
                        return "Zdefiniuj tylko pierwszy status. Poprzedni skok przeniesiony w drugiej próbie";
                    }
                    //obecny ma pierwszy i nie ma żadnego z pozostałych
                    else if (current.IdJumpStatus1 != 0 && (current.IdJumpStatus2 == 0 && current.IdJumpStatus3 == 0))
                    {
                        return null;
                    }

                }
                //poprzedni skok x--
                if(previous.IdJumpStatus1 == 2 && previous.IdJumpStatus2 == 3 && previous.IdJumpStatus3 == 3)
                {
                    //sprawdz czy są 3 skoki 
                   if(length >= 3)
                    {
                        
                        var previousPrevious = jumpsFiltered.ElementAt(2);
                        //i 3 od końca x--
                        if (previousPrevious.IdJumpStatus1 == 2 && previousPrevious.IdJumpStatus2 == 3 && previousPrevious.IdJumpStatus3 == 3)
                        {
                            //logika taka jak w przypadku xx-
                            //obecny nie ma nic zdefiniowanego
                            if (current.IdJumpStatus1 == 0 && current.IdJumpStatus2 == 0 && current.IdJumpStatus3 == 0)
                            {
                                return "Zdefiniuj pierwszy status. Dwa poprzednie skoki przeniesione w pierwszej próbie. ";
                            }
                            //obecny przenosi
                            else if (current.IdJumpStatus1 == 3 && current.IdJumpStatus2 == 0 && current.IdJumpStatus3 == 0)
                            {
                                return "OK23";
                            }
                            //obecny ma 2 i 3 zdefiniowany ale nie ma pierwszego
                            else if (current.IdJumpStatus1 == 0 && (current.IdJumpStatus2 != 0 || current.IdJumpStatus3 != 0))
                            {
                                return "Zdefiniuj tylko pierwszy status. Dwa poprzednie skoki przeniesione w pierwszej próbie.";
                            }
                            //obecnt ma pierwszy i któryś z pozostałych zdefiniowanych
                            else if (current.IdJumpStatus1 != 0 && (current.IdJumpStatus2 != 0 || current.IdJumpStatus3 != 0))
                            {
                                return "Zdefiniuj tylko pierwszy status. Dwa poprzednie skoki przeniesione w pierwszej próbie.";
                            }
                            //obecny ma pierwszy i nie ma żadnego z pozostałych
                            else if (current.IdJumpStatus1 != 0 && (current.IdJumpStatus2 == 0 && current.IdJumpStatus3 == 0))
                            {
                                return null;
                            }

                        }
                    }
                    //obecny nie ma nic zdefiniowanego
                    if (current.IdJumpStatus1 == 0 && current.IdJumpStatus2 == 0 && current.IdJumpStatus3 == 0)
                    {
                        return "Zdefiniuj pierwszy i drugi status. Poprzedni skok przeniesiony w pierwszej próbie";
                    }
                    //obecny przenosi
                    else if (current.IdJumpStatus1 == 3 && current.IdJumpStatus2 == 3 && current.IdJumpStatus3 == 3)
                    {
                        return null;
                    }
                    //obecny przenosi
                    else if (current.IdJumpStatus1 == 3 && current.IdJumpStatus2 == 3 && current.IdJumpStatus3 == 0)
                    {
                        return "OK3";
                    }
                    //obecny przenosi
                    else if (current.IdJumpStatus1 == 3 && current.IdJumpStatus2 == 0 && current.IdJumpStatus3 == 0)
                    {
                        return "OK23";
                    }
                    //obecny przenosi ale z błędem --?
                    else if (current.IdJumpStatus1 == 3 && current.IdJumpStatus2 == 3 && current.IdJumpStatus3 != 0)
                    {
                        return "Błędnie zdefiniowano trzeci status. Poprzedni skok przeniesiony w pierwszej próbie. Aby przenieść tą próbę ustaw trzeci status na Przeniesiony. ";
                    }
                    //obecny przenosi ale z błędem -??
                    else if (current.IdJumpStatus1 == 3 && (current.IdJumpStatus2 !=0  || current.IdJumpStatus3 != 0))
                    {
                        return "Błędnie zdefiniowano status drugi lub trzeci. Poprzedni skok przeniesiony w pierwszej próbie. Popraw je lub przenieś wysokość ";
                    }
                    //obecny z błędem O??
                    else if (current.IdJumpStatus1 == 1 && (current.IdJumpStatus2 != 0 || current.IdJumpStatus3 != 0))
                    {
                        return "Zdefiniuj tylko pierwszy status.";
                    }
                    //obecny przenosi ale z błędem Onicnic
                    else if (current.IdJumpStatus1 == 1 && current.IdJumpStatus2 == 0 && current.IdJumpStatus3 == 0)
                    {
                        return null;
                    }
                    //obecny X-nic
                    else if (current.IdJumpStatus1 == 2 && current.IdJumpStatus2 == 3 && current.IdJumpStatus3 == 0)
                    {
                        return "OK3";
                    }
                    //obecny  XXnic
                    else if (current.IdJumpStatus1 == 2 && current.IdJumpStatus2 == 2 && current.IdJumpStatus3 == 0)
                    {
                        return null;
                    }
                    //obecny  X0nic
                    else if (current.IdJumpStatus1 == 2 && current.IdJumpStatus2 == 1 && current.IdJumpStatus3 == 0)
                    {
                        return null;
                    }
                    //obecny  X-cos
                    else if (current.IdJumpStatus1 == 2 && current.IdJumpStatus2 == 3 && current.IdJumpStatus3 != 0)
                    {
                        return "Nie można definiować trzeciego statusu.Poprzedni skok przeniesiony w pierwszej próbie.";
                    }
                    //obecny  Xnicnic
                    else if (current.IdJumpStatus1 == 2 && current.IdJumpStatus2 == 0  && current.IdJumpStatus3 == 0)
                    {
                        return "Zdefiniuj drugi status.Poprzedni skok przeniesiony w pierwszej próbie.";
                    }
                    //obecny  XXcos
                    else if (current.IdJumpStatus1 == 2 && current.IdJumpStatus2 == 2 && current.IdJumpStatus3 != 0)
                    {
                        return "Nie można definiować trzeciego statusu.Poprzedni skok przeniesiony w pierwszej próbie.";
                    }
                    //obecny  XOcos
                    else if (current.IdJumpStatus1 == 2 && current.IdJumpStatus2 == 1 && current.IdJumpStatus3 != 0)
                    {
                        return "Nie można definiować trzeciego statusu.";
                    }
                    //obecny  niccoscos
                    else if (current.IdJumpStatus1 == 0 && (current.IdJumpStatus2 != 0 || current.IdJumpStatus3 != 0))
                    {
                        return "Zdefiniuj pierwszy status.";
                    }
                    //obecny  Xniccos
                    else if (current.IdJumpStatus1 == 2 && current.IdJumpStatus2 == 0 && current.IdJumpStatus3 != 0)
                    {
                        return "Błędnie zdefiniowano statusy.";
                    }
                }
                
            }



            return result;
        }
    }
}
