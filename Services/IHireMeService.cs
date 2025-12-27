using ResumeApi.Dtos;

namespace ResumeApi.Services
{
    public interface IHireMeService
    {
        void Submit(HireMeRequestDto request);
        IReadOnlyList<HireMeRequestDto> GetAll();
    }
}
