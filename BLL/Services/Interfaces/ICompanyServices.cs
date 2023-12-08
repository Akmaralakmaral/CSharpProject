
using Domain.Models.DTO;

namespace BLL.Services.Interfaces
{
    public interface ICompanyServices
    {
        CompanyDTO GetCompanyById(int companyId);
        void CreateCompany(CompanyDTO companyDTO);
        void UpdateCompany(CompanyDTO companyDTO);
        void DeleteCompany(int companyId);
        List<CompanyDTO> GetCompaniesByName(string companyName);
        List<CompanyDTO> GetCompaniesSortedByName();
        List<CompanyDTO> GetAllCompanies();
    }
}
