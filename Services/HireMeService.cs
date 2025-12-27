using ResumeApi.Dtos;

namespace ResumeApi.Services
{
    public class HireMeService : IHireMeService
    {
        public readonly List<HireMeRequestDto> _requests = new();

        public void Submit(HireMeRequestDto request)
        {
            _requests.Add(request); 
        }
        public IReadOnlyList<HireMeRequestDto> GetAll() => _requests;
    }
}
