using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.TemplateGeneral
{
    public static class RepositoryGen
    {
        public static string GenerateIRepositoryContent(string projectName, string nameRepoDir)
        {
            return $@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace {projectName}.{nameRepoDir}
{{
    public interface IRepository<T> where T : class
    {{
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }}
}}
            ";
        }
    }
}
