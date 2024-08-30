using CodingLogger.Models;
using CodingLogger.Data;

namespace CodingLogger.Services
{
    public class CodingService
    {
        public static CodingSessionRepository _repository;
        public CodingService(string connectionString)
        {
            _repository = new CodingSessionRepository(connectionString);
            
        }
        public async Task Add(CodingSession session)
        {
            await _repository.Create(session);
        }
    }
    
}



//        public void UpdateHabit(Habit habit)
//        {
//            _repository.Update(habit);
//        }

//        public Habit GetHabit(int id)
//        {
//            return _repository.Retrieve(id);
//        }
//        public List<Habit> GetAllHabits()
//        {
//            return _repository.RetrieveAllHabits();
//        }

//        public void DeleteHabit(int id)
//        {
//            _repository.Delete(id);
//        }
//        public bool DuplicateHabit(int id)
//        {
//            var duplicateHabit = GetHabit(id);
//            return duplicateHabit != null;

//        }
//        public Habit GetByName(string name)
//        {
//            return _repository.RetrieveByName(name);
//        }

//    }
//}

