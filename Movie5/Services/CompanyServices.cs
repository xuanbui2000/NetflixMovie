using Movie5.Models;

namespace Movie5.Services
{
    public interface ICompanyService
    {

        Task<IList<Company>> GetAllCompanyAsync();
        Movie GetMovie(int? id);
        Boolean CreateCompany(Company company);
        Boolean EditCompany(Company company);
        Boolean DeleteCompany(int? id);
        Boolean CompanyExists(int id);
    }
    public class CompanyServices : ICompanyService
    {
        public bool CompanyExists(int id)
        {
            throw new NotImplementedException();
        }

        public bool CreateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCompany(int? id)
        {
            throw new NotImplementedException();
        }

        public bool EditCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Company>> GetAllCompanyAsync()
        {
            throw new NotImplementedException();
        }

        public Movie GetMovie(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
