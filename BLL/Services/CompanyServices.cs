

using AutoMapper;
using Domain.Models.DTO;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain.Models.Entities;

namespace BLL.Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyServices(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public CompanyDTO GetCompanyById(int companyId)
        {
            Company company = _companyRepository.GetCompanyById(companyId);
            return _mapper.Map<CompanyDTO>(company);
        }

        public void CreateCompany(CompanyDTO companyDTO)
        {
            Company company = _mapper.Map<Company>(companyDTO);
            _companyRepository.CreateCompany(company);
        }

        public void UpdateCompany(CompanyDTO companyDTO)
        {
            Company company = _mapper.Map<Company>(companyDTO);
            _companyRepository.UpdateCompany(company);
        }

        public void DeleteCompany(int companyId)
        {
            _companyRepository.DeleteCompany(companyId);
        }

        public List<CompanyDTO> GetCompaniesByName(string companyName)
        {
            List<Company> companies = _companyRepository.GetCompaniesByName(companyName);
            return _mapper.Map<List<CompanyDTO>>(companies);
        }

        public List<CompanyDTO> GetCompaniesSortedByName()
        {
            List<Company> companies = _companyRepository.GetCompaniesSortedByName();
            return _mapper.Map<List<CompanyDTO>>(companies);
        }

        public List<CompanyDTO> GetAllCompanies()
        {
            var companies = _companyRepository.GetAllCompanies();
            return _mapper.Map<List<CompanyDTO>>(companies);
        }


    }
}
   