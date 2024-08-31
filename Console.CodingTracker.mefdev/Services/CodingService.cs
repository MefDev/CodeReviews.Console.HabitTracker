using CodingLogger.Models;
using CodingLogger.Data;
using CodingLogger.Shared;

namespace CodingLogger.Services
{
    public class CodingService: IMaintanable<CodingSession>
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
        public async Task<CodingSession> Get(int id)
        {
            return await _repository.Retrieve(id);
        }
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
        public async Task<List<CodingSession>> GetAll()
        {
            return await _repository.RetrieveAll();
        }
        public async Task Update(CodingSession newSession)
        {
            await _repository.Update(newSession);
        }
    }
}